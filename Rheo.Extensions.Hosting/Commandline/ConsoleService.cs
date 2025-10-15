using Microsoft.Extensions.Logging;
using Rheo.Extensions.Hosting.Argument;
using Rheo.Extensions.Hosting.Commandline;
using System.Text.RegularExpressions;

namespace IconTeX.Host.Commandline
{
    internal partial class ConsoleService : IConsoleService
    {
        private readonly List<Action<int>> _sizeChangeSubscribers = []; // Subscribers to size change events. Each action takes the new width as a parameter.
        private readonly ILogger<ConsoleService> _logger;

        [GeneratedRegex(@"(--?\w[\w-]*)(?:\s+(?:""([^""]*)""|([\d\w\.]+)))?", RegexOptions.Singleline)]
        private static partial Regex ParseArgumentsRegex();

        private Dictionary<string, string> _runtimeArguments = []; // Runtime arguments that can be added or modified during execution.

        public ConsoleService(ILogger<ConsoleService> logger)
        {
            _logger = logger;

            // Subscribe to size change event to notify all subscribers
            ConsoleAppHostService.ConsoleSizeChanged += OnSizeChanged;
        }

        public ConsoleSize CurrentSize { get; private set; }

        public void CenterText(string text)
        {
            if (string.IsNullOrEmpty(text) || CurrentSize.Width <= 0)
                return;

            // Remember the current cursor top position
            var cursorTop = Console.CursorTop;

            // Invoke the inner method to center the text once
            CenterTextInner(text, cursorTop, CurrentSize.Width);

            // Subscribe to size change event to re-center if size changes
            _sizeChangeSubscribers.Add((newWidth) =>
            {
                CenterTextInner(text, cursorTop, newWidth);
            });
        }

        public void HorizontallyRule(char ruleChar = '-')
        {
            // Remember the current cursor top position
            var cursorTop = Console.CursorTop;

            // Invoke the inner method to draw the horizontal rule once
            HorizontallyRuleInner(ruleChar, cursorTop, CurrentSize.Width);

            // Subscribe to size change event to redraw the rule if size changes
            _sizeChangeSubscribers.Add((newWidth) =>
            {
                HorizontallyRuleInner(ruleChar, cursorTop, newWidth);
            });
        }

        public void ReadLine()
        {
            var input = Console.ReadLine() ?? string.Empty;
            _runtimeArguments = ParseArguments(input);
        }

        public T? GetArgumentValue<T>(string key)
        {
            if (_runtimeArguments.Count == 0) return default;

            var stringValue = string.Empty;

            if (_runtimeArguments.TryGetValue(key, out string? valueForKey) && !string.IsNullOrWhiteSpace(valueForKey))
            {
                stringValue = valueForKey;
            }

            if (string.IsNullOrWhiteSpace(stringValue))
                return default;

            // Mimic IConfiguration.GetValue<T> conversion logic
            var targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            try
            {
                if (targetType == typeof(string))
                    return (T?)(object)stringValue;

                if (targetType.IsEnum)
                    return (T)Enum.Parse(targetType, stringValue, ignoreCase: true);

                if (targetType == typeof(bool))
                {
                    if (stringValue == "1" || stringValue.Equals("true", StringComparison.OrdinalIgnoreCase))
                        return (T)(object)true;
                    if (stringValue == "0" || stringValue.Equals("false", StringComparison.OrdinalIgnoreCase))
                        return (T)(object)false;
                }

                if (targetType == typeof(Guid))
                    return (T)(object)Guid.Parse(stringValue);

                if (targetType == typeof(TimeSpan))
                    return (T)(object)TimeSpan.Parse(stringValue);

                if (targetType == typeof(DateTime))
                    return (T)(object)DateTime.Parse(stringValue);

                // For other value types
                return (T)Convert.ChangeType(stringValue, targetType);
            }
            catch
            {
                return default;
            }
        }

        public T? GetArgumentValue<T>(ArgumentKeys keys)
        {
            return GetArgumentValue<T>(keys.Key) ?? GetArgumentValue<T>(keys.LongKey ?? string.Empty);
        }

        /// <summary>
        /// Parses a command-line string into a dictionary of argument keys and their corresponding values.
        /// </summary>
        /// <remarks>This method supports both quoted and unquoted values for arguments. Quoted values are
        /// parsed as-is, while unquoted values are treated as single tokens. If duplicate keys are encountered, the
        /// last occurrence overwrites the previous value.</remarks>
        /// <param name="commandline">The command-line string to parse. This string should contain arguments in the form of key-value pairs, where
        /// keys are prefixed with a delimiter (e.g., "--key=value" or "--key").</param>
        /// <returns>A dictionary containing the parsed arguments, where the keys are argument names and the values are their
        /// corresponding values. If an argument does not have an explicit value, the value is set to <see
        /// langword="true" />. Returns an empty dictionary if the input string is null, empty, or whitespace.</returns>
        private Dictionary<string, string> ParseArguments(string commandline)
        {
            Dictionary<string, string> argumants = [];

            if (string.IsNullOrWhiteSpace(commandline))
            {
                return argumants;
            }

            var matches = ParseArgumentsRegex().Matches(commandline);
            _logger.LogDebug("Parsing command line: {Commandline}, Total matches: {Count}", commandline, matches.Count);

            foreach (var match in matches)
            {
                // Ensure the match is valid
                if (match is not Match m)
                    continue;

                string key = m.Groups[1].Value;
                string value = "true";

                if (m.Groups[2].Success)
                {
                    value = m.Groups[2].Value; // Quoted string value
                }
                else if (m.Groups[3].Success)
                {
                    value = m.Groups[3].Value; // Unquoted value
                }

                argumants[key] = value;
                _logger.LogDebug("Parsed argument: {Key} = {Value}", key, value);
            }

            return argumants;
        }

        private static void CenterTextInner(string text, int cursorTop, int consoleWidth)
        {
            if (string.IsNullOrEmpty(text) || consoleWidth <= 0)
                return;

            // If the left cursor position is not at the start, move to the next line
            if (Console.CursorLeft != 0)
                Console.WriteLine();
            // Dynamically calculate the starting position
            int spaces = (consoleWidth - text.Length) / 2;
            // Ensure we don't have negative spaces
            spaces = Math.Max(0, spaces);
            // Set the cursor position to the original top position
            Console.SetCursorPosition(0, cursorTop);
            // Print the centered text
            Console.WriteLine(new string(' ', spaces) + text);
        }

        private static void HorizontallyRuleInner(char ruleChar, int cursorTop, int consoleWidth)
        {
            if (consoleWidth <= 0)
                return;

            // If the left cursor position is not at the start, move to the next line
            if (Console.CursorLeft != 0)
                Console.WriteLine();
            // Set the cursor position to the original top position
            Console.SetCursorPosition(0, cursorTop);
            // Print the horizontal rule
            Console.WriteLine(new string(ruleChar, consoleWidth));
        }

        private void OnSizeChanged(object? sender, ConsoleSizeChangedEventArgs e)
        {
            // Update the current size
            CurrentSize = e.NewSize;

            foreach (var subscriber in _sizeChangeSubscribers)
            {
                subscriber(e.NewSize.Width);
            }
        }
    }
}
