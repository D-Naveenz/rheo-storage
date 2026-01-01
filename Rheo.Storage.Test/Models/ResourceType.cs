namespace Rheo.Storage.Test.Models
{
    /// <summary>
    /// Specifies the type of resource represented, such as a document, video, text, image, or binary data.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the format or category of a resource when processing or
    /// categorizing content. The value <see cref="ResourceType.Unknown"/> can be used when the resource type cannot be
    /// determined.</remarks>
    public enum ResourceType
    {
        Unknown,
        Document,
        Video,
        Text,
        Image,
        Binary
    }
}
