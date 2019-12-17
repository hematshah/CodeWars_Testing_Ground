using NUnit.Framework;
using CodeWars_TesttingGround;

namespace Codewars_NUnit_Testing_In_Core
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        #region Multiple of Three and Five Testing 
        [TestCase(10, 23)]
        public void TestingTheMultipleOfThreeAndFive(int theValue, int expected)
        {
            //arrange
            var TestingMultiples = new MultipleOfThreeAndFIve();

            // actual
            var actual = TestingMultiples.testingMultipleOfTHreeAndFIve(theValue); // short version with linq lamda
            var actual2 = TestingMultiples.testingMultipleOfThreeAndFiveLongWay(theValue); // long version with for loop and if statements

            // asserting
            Assert.AreEqual(actual2, expected);

        }
        #endregion

        #region integer to binary reperestation test
        [TestCase(4, 1)]
        [TestCase(7, 3)]
        [TestCase(10, 2)]

        public void TestingIntegerToBinarySum(int theBitValue, int expected)
        {
            // arrange
            var TestingCountNumberOfBits = new IntegerToBinary();

            //actual
            var actual = TestingCountNumberOfBits.CountingNumberOfBits(theBitValue);
            var actual2 = TestingCountNumberOfBits.CountSetBitsShortVersion(theBitValue);

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected);
        }
        #endregion

        #region WeirdCases: Turning Even Characters in a string into Upper Case and Odd Characters of the same string into Lower Case
        [TestCase("how", "HoW")]
        [TestCase("how foot are you doing", "HoW FoOt ArE YoU DoInG")]

        public void TestingWeirdCases(string cases, string expected)
        {
            //arrange
            var testingWeirdCases = new WeirdCaseTestEvenCharacterUpperCase();

            //actual
            var actual = testingWeirdCases.TurningStringEvenCharactersIntoUpperCase(cases);
            var actual2 = testingWeirdCases.TurningEvencharacterInAStringIntoUpperCaseAndOddCharactersInTheSameStringIntoLowerCaseShortVersion(cases);

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected);
        }
        #endregion

        #region IQ TEST Testing Numbers 
        [TestCase("1 2 2", 1)]
        public void TestingIQTestReturningThePositionEveness(string ListOfValues, int expected)
        {
            //arrange
            var testingTheValue = new IQTest();

            //actual
            var actual = testingTheValue.ReturningThePositionOfEvenness(ListOfValues);
            var actual2 = testingTheValue.ReturningThePositionsShortVersion(ListOfValues);
            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected);

        }


        #endregion

        #region Testing Your Order Please: Sorting the strings in a sentence based on the number that each string has

        [TestCase("is2 Thi1s T4est 3a", "Thi1s is2 3a T4est")]
        [TestCase("4is th3is i6s it7 H1ow o5r w2eird", "H1ow w2eird th3is 4is o5r i6s it7")]
        public void TesttingYourOrderPlease(string text, string expected)
        {
            //arrange
            var testingOrder = new YourOrderPlease();

            //actual
            var actual = testingOrder.Order(text);
            var actual2 = testingOrder.OrderShortVersion(text);

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected);
        }

        #endregion

        #region Roman Numerical ENCODER: converting numbers into Roman Letters

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1954, "MCMLIV")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(2014, "MMXIV")]

        public void TestingRomanNumericalEncoder(int numToRoman, string expected)
        {
            //arrange
            var testingRomEncoder = new RomanNumericalEncoder();

            //actual
            var actual = testingRomEncoder.RomanConvert(numToRoman);
            var actual2 = testingRomEncoder.RomanConvertUsingDictionary(numToRoman);

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected);
        }

        #endregion

        #region Roman Numerical DECODER : converting Roman Numerical into numbers

        [TestCase("I", 1)]
        [TestCase("X", 10)]
        public void TestingRomanNumericalDecoder(string testingRomNum, int expected)
        {
            //arrange
            var testRomToNum = new RomanNumericalDecoder();

            //actual
            var actual = testRomToNum.RomanDecoder(testingRomNum);
            var actual2 = testRomToNum.RomanDecoderShorVersion(testingRomNum);
            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected);

        }


        #endregion

        #region Vasya Clerk
        [Test()]
        public void  TestingVasyaCLerkTicketBill() 
        {
            int[] theBill = new int[] { 25, 25, 50, 50 };
            string expected = "YES";
            //arrange
            var testingTicketSell = new VasyaClerk();

            //acual
            var actual = testingTicketSell.Tickets(theBill);

            //Assert
            Assert.AreEqual(actual, expected);
        }
        #endregion

        #region Testing Categorizing New Members

        [Test()]
        public void TestingCategorizingNewMembers() 
        {
           int[][] someData = new[] { new[] { 45, 12 }, new[] { 55, 21 }, new[] { 19, 2 }, new[] { 104, 20 } };
           string [] expected = new[] { "Open", "Senior", "Open", "Senior" };
            // arrange
            var testing = new CategorizeNewMember();

            //actual
            var actual = testing.OpenOrSenior(someData);

            //Assert
            Assert.AreEqual(actual, expected);
        }
        #endregion

        #region Find The Parity Outlier Test
        [Test]
        public void TestingParityOutlier() 
        {
            int[] oddOrEvenValue = { 2, 6, 8, -10, 3 };
            int expected = 3;
            //Arrange
            var testing = new FindTheParityOutlier();

            //Actual
            var actual = testing.FindingTheParityOutliner(oddOrEvenValue);

            //Assert
            Assert.AreEqual(actual, expected);
        }
        #endregion

        #region Testing LoveAndFriendShip

        [TestCase("love", 54)]
        [TestCase("friendship", 108)]
        public void testingLoveAndFriendShip(string letter, int expected) 
        {
            //arrange
            var testing = new LoveAndFriendShip();

            //actual
            var actual = testing.WordsToMarks(letter);

            //Assert
            Assert.AreEqual(actual, expected);

        }

        #endregion

        #region testing Decending order input
        [TestCase(54792, 97542)]

        public void TestOutputInDecendingOrder(int sorting, int expected) 
        {
            //arrange
            var testing = new DecendingOrder();

            //actual
            var actual = testing.OutputInDecendingOrder(sorting);

            //Assert
            Assert.AreEqual(actual, expected);

        }

        #endregion

    }
}