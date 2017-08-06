using System;
using System.Collections.Generic;
using System.Linq;
namespace EnLearn
{
    internal class ScoreBuckets
    {
        private readonly Dictionary<int, List<int>> _scorebuckets = new Dictionary<int, List<int>>();
        private readonly int[] _rolls;

        public ScoreBuckets(IEnumerable<int> rolls)
        {
            InitBuckets();
            var enumerable = rolls as int[] ?? rolls.ToArray();
            _rolls = enumerable.ToArray();
            foreach (var roll in enumerable)
                _scorebuckets[roll].Add(roll);
        }

        private void InitBuckets()
        {
            for (var i = 1; i < 9; i++)
            {
                _scorebuckets.Add(i, new List<int>());
            }
        }

        public int RollCount(int roll) => _scorebuckets[roll].Count;

        public int FindByRollCount(int count )
        {
            return !_scorebuckets.Any(b => b.Value.Count >= count) ? 0 : _scorebuckets.First(b => b.Value.Count >= count).Key;
        }

        public int NumberOfSetsOf(int count) => _scorebuckets.Count(x => x.Value.Count == count);

        public bool AreUnique() => _scorebuckets.Where(b => b.Value.Count > 0 ).All(b => b.Value.Count == 1);

        public bool  HaveBucketSquenceSizeOf(int size)
        {
            var r = _rolls.Distinct().ToArray();

            if (r.Length < size)
            {
                return false; 
            }

            Array.Sort(r); 

            for (var i = 0; i < size -1; i++)
            {
                if (r[i] +1 != r[i + 1])
                {
                    return false; 
                }
            }
            return true; 
        }

        public int TotalRowValues() => _rolls.Sum();
    }
}