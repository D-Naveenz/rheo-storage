namespace Rheo.Storage.DefinitionsBuilder.Models.Definition
{
    /// <summary>
    /// Represents a type definition that includes metadata such as file type, extension, MIME type, and additional
    /// context information.
    /// </summary>
    /// <remarks>This class is used to encapsulate metadata and properties associated with a specific type
    /// definition.  It includes details such as the file type, file extension, MIME type, and priority level, as well
    /// as a digital signature  and optional remarks for additional context.</remarks>
    public class Definition
    {
        /// <summary>
        /// Gets or sets the file type associated with the type definition.
        /// </summary>
        public string FileType { get; set; } = "";
        /// <summary>
        /// Gets or sets the file extension associated with the type definition.
        /// </summary>
        public string Extension { get; set; } = "";
        /// <summary>
        /// Gets or sets the MIME type associated with the content.
        /// </summary>
        public string MimeType { get; set; } = "";
        /// <summary>
        /// Gets or sets additional information or notes related to the current context.
        /// </summary>
        public string Remarks { get; set; } = "";
        /// <summary>
        /// Gets or sets the digital signature associated with the current object.
        /// </summary>
        public Signature Signature { get; set; } = new();
        /// <summary>
        /// Gets or sets the priority level of the definition.
        /// </summary>
        public int PriorityLevel { get; set; } = 0;
    }
}
