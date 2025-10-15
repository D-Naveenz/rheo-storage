using Rheo.Extensions.Hosting.Argument;

namespace Rheo.Extensions.Hosting.Commandline
{
    /// <summary>
    /// Provides functionality for monitoring and interacting with the console window, including handling console size
    /// changes, centering text, and drawing horizontal rules.
    /// </summary>
    public interface IConsoleService
    {
        /// <summary>
        /// Gets the current size of the console, including its width and height.
        /// </summary>
        ConsoleSize CurrentSize { get; }

        /// <summary>
        /// Centers the specified text horizontally within the current console width.
        /// </summary>
        /// <remarks>This method centers the text based on the current console width at the time of
        /// invocation.  If the console width changes after the text is centered, the text will automatically be
        /// re-centered.</remarks>
        /// <param name="text">The text to be centered. If <paramref name="text"/> is <see langword="null"/> or empty, the method does
        /// nothing.</param>
        void CenterText(string text);

        /// <summary>
        /// Draws a horizontal rule at the current cursor position in the console.
        /// </summary>
        /// <remarks>The horizontal rule is drawn across the entire width of the current console size.  If
        /// the console size changes, the rule is automatically redrawn to match the new width.</remarks>
        /// <param name="ruleChar">The character used to draw the horizontal rule. The default is <c>'-'</c>.</param>
        void HorizontallyRule(char ruleChar = '-');

        /// <summary>
        /// Reads a line of input from the console and processes it into runtime arguments.
        /// </summary>
        /// <remarks>This method reads a single line of input from the standard input stream. If the input
        /// is null,  it defaults to an empty string. The input is then parsed into runtime arguments for further
        /// processing.</remarks>
        void ReadLine();

        /// <summary>
        /// Retrieves the value associated with the specified key from the runtime arguments and converts it to the
        /// specified type.
        /// </summary>
        /// <remarks>This method supports conversion to common types such as <see cref="string"/>, <see
        /// cref="bool"/>, <see cref="Guid"/>,  <see cref="TimeSpan"/>, <see cref="DateTime"/>, and enumeration types.
        /// For other types, it attempts to use  <see cref="Convert.ChangeType(object, Type)"/> for
        /// conversion.</remarks>
        /// <typeparam name="T">The type to which the value should be converted. This can be a nullable or non-nullable type.</typeparam>
        /// <param name="key">The key of the argument to retrieve. The key is case-sensitive.</param>
        /// <returns>The value associated with the specified key, converted to the specified type <typeparamref name="T"/>. 
        /// Returns <see langword="default"/> if the key does not exist, the value is null or whitespace, or the
        /// conversion fails.</returns>
        T? GetArgumentValue<T>(string key);

        /// <summary>
        /// Retrieves the value of an argument identified by the specified keys.
        /// </summary>
        /// <remarks>This method attempts to retrieve the argument value using the primary key specified
        /// in <paramref name="keys"/>.  If the value is not found, it will attempt to retrieve the value using the
        /// secondary key, if provided.</remarks>
        /// <typeparam name="T">The type of the argument value to retrieve.</typeparam>
        /// <param name="keys">An <see cref="ArgumentKeys"/> object containing the keys used to locate the argument value.</param>
        /// <returns>The value of the argument if found; otherwise, <see langword="null"/>.</returns>
        T? GetArgumentValue<T>(ArgumentKeys keys);
    }
}