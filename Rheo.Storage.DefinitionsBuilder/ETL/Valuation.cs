using Rheo.Storage.DefinitionsBuilder.ETL.Sluice;
using Rheo.Storage.DefinitionsBuilder.Models.Definition;

namespace Rheo.Storage.DefinitionsBuilder.ETL
{
    internal class Valuation
    {
        private const int ExtensionLevelWeight = 30;        // 0-150 points (5 levels * 30)
        private const int SignatureWeight = 25;             // 0-25 points
        private const int MimeValidityWeight = 20;          // 0-20 points
        private const int SoftwarePopularityWeight = 15;    // 0-15 points
        private const int UsageFrequencyWeight = 10;        // 0-10 points
        private const int UniquenessWeight = 10;            // 0-10 points
        private const int IdentifiabilityWeight = 10;       // 0-10 points

        /// <summary>
        /// Calculates a score based on the extension level of the specified <see cref="Definition"/>.
        /// </summary>
        /// <param name="definition">The <see cref="Definition"/> whose extension level is evaluated. Cannot be <see langword="null"/>.</param>
        /// <returns>An integer score representing the importance of the extension level. Returns 0 if the extension is uncommon.</returns>
        public static int ValueByLevel(Definition definition)
        {
            int level = CommonExtensions.GetLevel(definition.Extension);
            int extensionScore = (6 - level) * ExtensionLevelWeight; // Higher level = higher score
            if (level == 0) extensionScore = 0; // Uncommon extensions get 0
            return extensionScore;
        }
    }
}
