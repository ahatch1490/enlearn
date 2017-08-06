using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnLearn;
namespace EnLearnTest
{
    [TestClass]
    public class ScorerTestHarness
    {

        [TestMethod]
        public void Should_Score_Category_Ones()
        {
            var scorer = new Scorer();
            Assert.AreEqual(3, scorer.Score("Ones", new[]{1, 1, 1, 2, 2}));

        }

        [TestMethod]
        public void Should_Score_Category_Twos()
        {
            var scorer = new Scorer();
            Assert.AreEqual(6, scorer.Score("Twos", new[] {1, 1, 2, 2, 2 }));

        }

        [TestMethod]
        public void Should_Score_Category_Threes()
        {
            var scorer = new Scorer();
            Assert.AreEqual(9, scorer.Score("Threes", new[] { 1, 1, 3, 3, 3 }));

        }

        [TestMethod]
        public void Should_Score_Category_Fours()
        {
            var scorer = new Scorer();
            Assert.AreEqual(16, scorer.Score("Fours", new[] { 4, 4, 4, 4, 3 }));
        }

        [TestMethod]
        public void Should_Score_Category_Fives()
        {
            var scorer = new Scorer();
            Assert.AreEqual(10, scorer.Score("Fives", new[] { 4, 4, 4,  5, 5 }));
        }

        [TestMethod]
        public void Should_Score_Category_Sixes()
        {
            var scorer = new Scorer();
            Assert.AreEqual(6, scorer.Score("Sixes", new[] { 6, 4, 4, 4, 3 }));
        }

        [TestMethod]
        public void Should_Score_Category_Sevens()
        {
            var scorer = new Scorer();
            Assert.AreEqual(21, scorer.Score("Sevens", new[] {  7, 7, 7, 3, 3 }));
        }

        [TestMethod]
        public void Should_Score_Category_Eights()
        {
            var scorer = new Scorer();
            Assert.AreEqual(24, scorer.Score("Eights", new[] { 7, 7, 8, 8, 8 }));
        }

        [TestMethod]
        public void Should_Score_Category_ThreeOfAKind()
        {
            var scorer = new Scorer();
            Assert.AreEqual(3, scorer.Score("ThreeOfAKind", new[] {1, 1, 1, 8, 8 }));
        }

        [TestMethod]
        public void Should_Score_Category_FourOfAKind()
        {
            var scorer = new Scorer();
            Assert.AreEqual(4, scorer.Score("FourOfAKind", new[] { 1, 1, 1, 1, 8 }));
        }

        [TestMethod]
        public void Should_Score_Category_AllOfAKind()
        {
            var scorer = new Scorer();
            Assert.AreEqual(50, scorer.Score("AllOfAKind", new[] { 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void Should_Score_Category_NoneOfAKind()
        {
            var scorer = new Scorer();
            Assert.AreEqual(40, scorer.Score("NoneOfAKind", new[] { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void Should_Score_Category_SmallStraight()
        {
            var scorer = new Scorer();
            Assert.AreEqual(30, scorer.Score("SmallStraight", new[] { 1, 2, 3, 4, 7 }));
        }

        [TestMethod]
        public void Should_Score_Category_LargeStraight()
        {
            var scorer = new Scorer();
            Assert.AreEqual(40, scorer.Score("LargeStraight", new[] { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void Should_Score_Category_Chance()
        {
            var scorer = new Scorer();
            Assert.AreEqual(12, scorer.Score("Chance", new[] { 1, 1, 1, 1, 8 }));
        }

        [TestMethod]
        public void Should_Return_FullHouse_Score()
        {
            var scorer = new Scorer();
            Assert.AreEqual(25 ,scorer.Score("FullHouse", new[]{5,5,6,6,5}));
        }

        [TestMethod]
        public void Should_Return_0_if_not_does_not_score()
        {
            var scorer = new Scorer();
            Assert.AreEqual(0, scorer.Score("FullHouse", new[] {5, 4, 8, 6, 1})); 
        }

        [TestMethod]
        public void Should_Return_An_Array_Of_Strings()
        {
            var scorer = new Scorer();
            var actual = scorer.SuggestedCategories(new[] {8, 8, 8, 3, 3});
            Assert.IsInstanceOfType(actual,typeof(string[]));
        }

        [TestMethod]
        public void Should_Return_Top_Score()
        {
            var expected = new[] { "AllOfAKind"};
            var actual = new Scorer().SuggestedCategories(new[] {8, 8, 8, 8, 8});
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Should_Return_Full_House()
        {
            var expected = new[] {"FullHouse"};
            var actual = new Scorer().SuggestedCategories(new[] { 1, 1, 1, 2, 2 });
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Should_Return_Chance()
        {
            var expected = new[] { "Chance" };
            var actual = new Scorer().SuggestedCategories(new[] { 8, 8, 8, 2, 2 });
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Should_Return_Small_Straight()
        {
            var expected = new[] { "SmallStraight" };
            var actual = new Scorer().SuggestedCategories(new[] {1, 2, 3, 4, 1}); 
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Should_Return_NoneOfAKind_and_LargeStraight()
        {
            var expected = new[] { "LargeStraight", "NoneOfAKind" };
            var actual = new Scorer().SuggestedCategories(new[] { 2,3,4,5,6});
            CollectionAssert.AreEquivalent(expected, actual);
        }


    }
}
