using Rheo.Storage.DefinitionsBuilder.Models.Definition;

namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static class Valuation
    {
        private const int ExtensionLevelWeight = 30;        // 0-150 points (5 levels * 30)
        private const int PatternPositionWeight = 5;        // points per pattern
        private const int SignatureStringWeight = 2;        // points per signature string
        private const int SignatureWeight = 10;             // 0-10 points
        private const int IdentifiabilityWeight = 10;       // 0-10 points

        /// <summary>
        /// Calculates the priority value for the specified <see cref="Definition"/> based on its characteristics.
        /// </summary>
        /// <param name="definition">The <see cref="Definition"/> instance for which to calculate the priority. Cannot be null.</param>
        /// <returns>An integer representing the calculated priority of the specified definition.</returns>
        public static int CalculatePriority(Definition definition)
        {
            int totalValue = 0;
            totalValue += ValueByLevel(definition);
            totalValue += ValueBySignature(definition);
            totalValue += ValueByIdentifiability(definition);
            
            return totalValue;
        }

        /// <summary>
        /// Calculates a score based on the extension level of the specified <see cref="Definition"/>.
        /// </summary>
        /// <param name="definition">The <see cref="Definition"/> whose extension level is evaluated. Cannot be <see langword="null"/>.</param>
        /// <returns>An integer score representing the importance of the extension level. Returns 0 if the extension is uncommon.</returns>
        private static int ValueByLevel(Definition definition)
        {
            int level = definition.Level;
            int extensionScore = (6 - level) * ExtensionLevelWeight; // Higher level = higher score
            if (level == 0) extensionScore = 0; // Uncommon extensions get 0
            return extensionScore;
        }

        /// <summary>
        /// Calculates a weighted score based on the patterns and strings defined in the specified signature definition.
        /// </summary>
        /// <remarks>The score is determined by assigning weights to each pattern and string in the
        /// signature. Patterns at position zero receive additional weight. The final score is scaled by a signature
        /// weight constant.</remarks>
        /// <param name="definition">The <see cref="Definition"/> containing the signature whose patterns and strings are used to compute the
        /// score.</param>
        /// <returns>An integer representing the weighted score derived from the signature's patterns and strings.</returns>
        private static int ValueBySignature(Definition definition)
        {
            var score = 0;
            var patterns = definition.Signature.Patterns;
            var strings = definition.Signature.Strings;

            foreach (var pattern in patterns)
            {
                var patternScore = 1;
                if (pattern.Position == 0)
                {
                    patternScore += PatternPositionWeight;
                }
                score += patternScore;
            }

            foreach (var str in strings)
            {
                score += SignatureStringWeight;
            }

            return score * SignatureWeight;
        }

        /// <summary>
        /// Calculates the identifiability value for the specified <see cref="Definition"/>.
        /// </summary>
        /// <param name="definition">The definition to evaluate for identifiability. Cannot be <c>null</c>.</param>
        /// <returns>An integer representing the identifiability value. Returns a positive value if the definition contains one
        /// or more signature patterns; otherwise, returns 0.</returns>
        private static int ValueByIdentifiability(Definition definition)
        {
            if (definition.Signature.Patterns.Count > 0)
            {
                return IdentifiabilityWeight;
            }
            return 0;
        }
    }
}
