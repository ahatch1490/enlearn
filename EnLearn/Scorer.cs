using System.Collections.Generic;
using System.Linq;

namespace EnLearn
{
    /// <summary>
    /// Returns scoreing data for a game that uses 5 eight sided dice. 
    /// </summary>
    public class Scorer
    {
        private readonly ScoreBuilder _scoreBuilder = new ScoreBuilder();

        private readonly List<string> _catagories = new List<string>()
        {
            "ThreeOfAKind","FourOfAKind","AllOfAKind","NoneOfAKind","FullHouse","SmallStraight","LargeStraight","Chance"
        };

        /// <summary>
        /// Returns a score based on the category and 5 rolls
        /// </summary>
        /// <param  name="category">One of roll catagories avaliable in the game</param  >
        /// <param  name="roll"> The five dice rolled.</param >
        /// <returns>returns a score</returns>
        public int Score(string category, int[] roll)
        {   
            return _scoreBuilder.ScoreByCategory(category, roll);
        }


        /// <summary>
        /// Suggests one or more of the highest scoring categories based on the roll entered.
        /// </summary>
        /// <param  name="roll"> The five dice rolled</param >
        /// <returns>returns a score</returns>
        public string[] SuggestedCategories(int [] roll)
        {
            var scores = new Dictionary<int, List<string>>();
            foreach (var category in _catagories)
            {
                var score = Score(category, roll);
                if (!scores.Keys.Contains(score))
                {
                    scores.Add(score, new List<string>() {category});
                }
                else
                {
                    scores[score].Add(category);
                }
            }

            var topKey = scores.Keys.Max();
            return scores[topKey].ToArray(); 
        }
        
    }
 
}
