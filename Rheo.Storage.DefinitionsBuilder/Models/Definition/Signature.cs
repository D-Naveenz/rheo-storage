namespace Rheo.Storage.DefinitionsBuilder.Models.Definition
{
    /// <summary>
    /// Represents a signature that contains collections of patterns and string data in byte array format.
    /// </summary>
    /// <remarks>This class provides properties to manage patterns for processing or validation, as well as
    /// string data stored in byte array format. Ensure proper encoding and decoding when working with the <see
    /// cref="Strings"/> property.</remarks>
    public class Signature
    {
        /// <summary>
        /// Gets or sets the collection of patterns used for processing or validation.
        /// </summary>
        public List<Pattern> Patterns { get; set; } = [];
        /// <summary>
        /// Gets or sets the collection of byte arrays representing string data.
        /// </summary>
        /// <remarks>This property can be used to store and retrieve string data in its byte array
        /// representation. Ensure proper encoding and decoding when converting between strings and byte
        /// arrays.</remarks>
        public List<byte[]> Strings { get; set; } = [];

        public override string ToString()
        {
            return $"Signature: {Patterns.Count} patterns, {Strings.Count} strings";
        }
    }
}
