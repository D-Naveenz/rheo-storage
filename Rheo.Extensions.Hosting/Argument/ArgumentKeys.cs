namespace Rheo.Extensions.Hosting.Argument
{
    /// <summary>
    /// Represents a key used to identify an argument, consisting of a required short key and an optional long key.
    /// </summary>
    /// <remarks>The <see cref="ArgumentKeys"/> class provides multiple constructors to initialize an instance
    /// using different input formats: <list type="bullet"> <item> <description>A short key and an optional long key as
    /// separate parameters.</description> </item> <item> <description>A single comma-separated string containing the
    /// short key and optional long key.</description> </item> <item> <description>A collection of strings, where the
    /// first string is the short key and the second (if available) is the long key.</description> </item> </list> The
    /// short key is required and cannot be null, empty, or consist only of whitespace. The long key, if provided, must
    /// not consist only of whitespace.</remarks>
    public class ArgumentKeys : IEquatable<ArgumentKeys>
    {
        public string Key { get; }

        public string? LongKey { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentKeys"/> class with the specified key and optional long
        /// key.
        /// </summary>
        /// <param name="key">The required short key for the argument. This value cannot be null, empty, or consist only of whitespace.</param>
        /// <param name="longKey">The optional long key for the argument. If provided, this value cannot consist only of whitespace.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key"/> is null, empty, or consists only of whitespace.</exception>
        public ArgumentKeys(string key, string? longKey = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Argument key cannot be null or whitespace.", nameof(key));
            }
            Key = StripLeadingDashes(key);
            // LongKey is optional. But if provided, it should not be whitespace.
            if (!string.IsNullOrWhiteSpace(longKey))
            {
                LongKey = StripLeadingDashes(longKey);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentKeys"/> class with the specified key string.
        /// </summary>
        /// <remarks>The <paramref name="keyString"/> parameter should be formatted as a comma-separated
        /// string, where the first value  represents the short key and the second value (optional) represents the long
        /// key. For example: "k, key". If the long key is not provided, it will remain unset.</remarks>
        /// <param name="keyString">A string containing the short key and optional long key, separated by a comma.  The short key is required
        /// and cannot be null, empty, or whitespace. The long key, if provided, must not be whitespace.</param>
        /// <exception cref="ArgumentException">Thrown if the short key is null, empty, or consists only of whitespace.</exception>
        public ArgumentKeys(string keyString)
        {
            var keys = keyString.Split(',').Select(s => s.Trim());
            var key = keys.FirstOrDefault();
            var longKey = keys.Skip(1).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Argument key cannot be null or whitespace.");
            }
            Key = StripLeadingDashes(key);
            if (!string.IsNullOrWhiteSpace(longKey))
            {
                LongKey = StripLeadingDashes(longKey);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentKeys"/> class with the specified keys.
        /// </summary>
        /// <param name="keys">A collection of strings representing the keys. The first key in the collection is used as the primary key, 
        /// and the second key (if available) is used as the secondary key.</param>
        public ArgumentKeys(IEnumerable<string> keys) : this(keys.First(), keys.Skip(1).FirstOrDefault())
        {
        }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(LongKey))
            {
                return $"-{Key}/--{LongKey}";
            }

            return $"-{Key}";
        }

        /// <summary>
        /// Determines whether the specified object matches the current instance's key or long key.
        /// </summary>
        /// <remarks>The comparison is case-insensitive and checks against both the <c>Key</c> and
        /// <c>LongKey</c> properties.  If <paramref name="obj"/> is <see langword="null"/> or its string representation
        /// is empty or whitespace,  the method returns <see langword="false"/>.</remarks>
        /// <param name="obj">The object to compare. The object's string representation is used for the comparison.</param>
        /// <returns><see langword="true"/> if the string representation of <paramref name="obj"/> matches the key or long key 
        /// (case-insensitive); otherwise, <see langword="false"/>.</returns>
        public bool Matches(object obj)
        {
            // Get the string representation of the object
            var objString = obj?.ToString();

            if (string.IsNullOrWhiteSpace(objString))
            {
                return false;
            }

            // Compare against both Key and LongKey (if available)
            return string.Equals(objString, Key, StringComparison.OrdinalIgnoreCase) ||
                   !string.IsNullOrWhiteSpace(LongKey) && string.Equals(objString, LongKey, StringComparison.OrdinalIgnoreCase);
        }
        public bool Equals(ArgumentKeys? other)
        {
            if (other is null) return false;
            return string.Equals(Key, other.Key, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(LongKey, other.LongKey, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj) => Equals(obj as ArgumentKeys);

        public override int GetHashCode()
        {
            return HashCode.Combine(Key.ToLowerInvariant(), LongKey?.ToLowerInvariant());
        }

        public static bool operator ==(ArgumentKeys? left, ArgumentKeys? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(ArgumentKeys? left, ArgumentKeys? right)
        {
            return !(left == right);
        }

        // Helper method to strip leading dashes from a key string
        private static string StripLeadingDashes(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return key;
            return key.TrimStart('-');
        }
    }
}
