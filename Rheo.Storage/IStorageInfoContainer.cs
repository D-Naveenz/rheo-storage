using Rheo.Storage.Info;
namespace Rheo.Storage
{
    internal interface IStorageInfoContainer<T> where T : InfomationProvider
    {
        /// <summary>
        /// Gets the storage information. This property will throw an exception if the information is not available.
        /// </summary>
        public T Information { get; }

        /// <inheritdoc cref="InfomationProvider.MimeType"/>
        public string ContentType { get; }

        /// <inheritdoc cref="InfomationProvider.DisplayName"/>
        public string? DisplayName { get; }

        /// <inheritdoc cref="InfomationProvider.TypeName"/>
        public string? DisplayType { get; }

        public bool IsReadOnly { get; }
        public bool IsHidden { get; }
        public bool IsSystem { get; }
        public bool IsTemporary { get; }
    }
}
