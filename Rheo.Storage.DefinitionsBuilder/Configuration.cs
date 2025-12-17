using System.Reflection;

namespace Rheo.Storage.DefinitionsBuilder
{
    internal static class Configuration
    {
        private const string ASSETS_PATH = "Assets";
        private const string DUMP_PATH = "Dumps";

        public const string FILEDEF_PACKAGE_NAME = "filedefs";

        /// <summary>
        /// Gets the absolute path to the assets directory.
        /// </summary>
        public static string AssetsPath => Path.GetFullPath(ASSETS_PATH);

        /// <summary>
        /// Gets the file system path to the TrID directory within the assets folder.
        /// </summary>
        public static string TridLocation => Path.Combine(AssetsPath, "TrID");

        /// <summary>
        /// Gets the version of the current executing assembly in the format "Major.Minor".
        /// </summary>
        public static string Version
        {
            get
            {
                var versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
                return versionInfo != null ? string.Concat(versionInfo.Major, '.', versionInfo.Minor) : "1.0";
            }
        }

        /// <summary>
        /// Gets the product name defined in the assembly's <see cref="AssemblyProductAttribute"/>.
        /// </summary>
        /// <remarks>If the assembly does not specify a product name, the value defaults to "Rheo
        /// Definitions Builder".</remarks>
        public static string ProductName
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length > 0)
                {
                    var productAttribute = (AssemblyProductAttribute)attributes[0];
                    return productAttribute.Product;
                }

                // Fallback product name if attribute is not found
                return "Rheo Definitions Builder";
            }
        }

        /// <summary>
        /// Determines the output path to use, defaulting to a directory named "Output" in the current working directory
        /// if none is provided.
        /// </summary>
        /// <param name="outputPath">The specified output path. If <see langword="null"/>, empty, or whitespace, a default path is used.</param>
        /// <returns>The resolved output path as a string.</returns>
        public static string GetOutputPath(string? outputPath = null)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            }
            return outputPath;
        }

        /// <summary>
        /// Constructs the full path for the memory dump directory based on the specified output path.
        /// </summary>
        /// <remarks>This method ensures that the dump path is constructed relative to the provided output
        /// path or a default location.</remarks>
        /// <param name="outputPath">The base output path to use for constructing the dump path. If <see langword="null"/> or empty, a default
        /// output path is used.</param>
        /// <returns>The full path to the memory dump directory, combining the specified or default output path with the dump directory
        /// name.</returns>
        public static string GetDumpPath(string? outputPath = null) => Path.Combine(GetOutputPath(outputPath), DUMP_PATH);
    }
}
