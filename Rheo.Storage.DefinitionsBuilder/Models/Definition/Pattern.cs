using System.Text;

namespace Rheo.Storage.DefinitionsBuilder.Models.Definition
{
    /// <summary>
    /// Represents a pattern with an associated position and data.
    /// </summary>
    /// <remarks>This class is used to store a pattern's offset position within a file and its corresponding
    /// data.</remarks>
    public class Pattern
    {
        /// <summary>
        /// The offset position of the pattern in the file.
        /// </summary>
        public ushort Position { get; set; }
        /// <summary>
        /// Gets or sets the prefix pattern data.
        /// </summary>
        public byte[] Data { get; set; } = [];

        public override string ToString()
        {
            return $"\"{Encoding.ASCII.GetString(Data)}\" at {Position}";
        }
    }
}
