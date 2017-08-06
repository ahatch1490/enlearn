using System.Collections.Generic;

namespace EnLearn
{
     internal class ScoreBuilder
    {
        private readonly Dictionary<string, int> _numericScores = new Dictionary<string, int>()
        {
            { "Ones", 1},{"Twos", 2},{"Threes", 3},{ "Fours", 4},{ "Fives", 5},{ "Sixes", 6},{"Sevens", 7},{ "Eights", 8}
        };

        public int ScoreByCategory(string category, IEnumerable<int> rolls)
        {
            var buckets = new ScoreBuckets(rolls);

            return IsNumaric(category) ? GetNumericScore(category, buckets) : GetCombose(category, buckets);
        }

        private int GetCombose(string category, ScoreBuckets buckets)
        {
            switch (category)
            {
                case "ThreeOfAKind":
                    return 3 * buckets.FindByRollCount(3);
                case "FourOfAKind":
                    return 4 * buckets.FindByRollCount(4);
                case "AllOfAKind":
                    return (buckets.FindByRollCount(5) > 0) ? 50 : 0;
                case "NoneOfAKind":
                    return (buckets.AreUnique()) ? 40 : 0;
                case "FullHouse":
                    return (buckets.NumberOfSetsOf(2) == 1 && buckets.NumberOfSetsOf(3) == 1) ? 25 : 0;
                case "SmallStraight":
                    return (buckets.HaveBucketSquenceSizeOf(4)) ? 30 : 0;
                case "LargeStraight":
                    return (buckets.HaveBucketSquenceSizeOf(5)) ? 40 : 0;
                case "Chance":
                    return buckets.TotalRowValues();
                default:
                    throw new ScoreCategoryException($"Could not find category: '{category}'.");
            }
        }

        private bool IsNumaric(string category)
        {
            return _numericScores.ContainsKey(category);
        }

        private int GetNumericScore(string category, ScoreBuckets buckets)
        {
            return _numericScores[category] * buckets.RollCount(_numericScores[category]);
        }
    }
}