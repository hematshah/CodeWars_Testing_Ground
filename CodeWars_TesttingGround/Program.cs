using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace CodeWars_TesttingGround
{

    public class A 
    {
        public static string testingAB(int height, int width, int length, int mass) 
        {
            bool Bulky = false;
            bool heavy = false;

            int volume = height * width * length;
            if (( width >= 150 || height >= 150 || length >= 150) || volume >= 1000000) 
            {
                Bulky = true;
            }
            if (mass >= 20)
            {
                heavy = true;
            }
            if (Bulky && heavy)
            {
                return "REJECTED";
            }
            else if (Bulky || heavy)
            {
                return "SPECIAL";
            }
            else 
            {
                return "STANDARD";
            }

        }  


    }
   
    class Program
    {
        static void Main(string[] args)
        {
                  
            var testingA = A.testingAB(120, 120, 120, 30); // bulky and heavy --> return rejected
            var testingB = A.testingAB(150, 160, 120, 10); // bulky but not heavy --> return special
            var testingC = A.testingAB(50, 50, 50, 50); //  heavy but not bulky --> return  special
            var testingD = A.testingAB(20,40,60,10); // not heavy or bulky --> return standard
            var testingE = A.testingAB(34,244,32,10);

            Console.WriteLine(testingA + "\n" + testingB + "\n" + testingC + "\n" + testingD);
                           


            Console.WriteLine("...............................................................................................................\n");        
                Student newStudent = null;

                try
                {
                    newStudent = new Student();
                    newStudent.StudentName = "James007";

                    ValidateStudent(newStudent);
                }
                catch (InvalidStudentNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                //Console.ReadKey();
            

            


            WeirdCaseTestEvenCharacterUpperCase testWeirdCases = new WeirdCaseTestEvenCharacterUpperCase();
            var testing = testWeirdCases.TurningStringEvenCharactersIntoUpperCase("hello foot are you");
            Exception customException = new Exception("Error");
           
            Console.WriteLine(customException);
           

            Console.WriteLine(".....................................................................................");

            YourOrderPlease yourOrder = new YourOrderPlease();
            var testYourOrder = yourOrder.Order("is2 Thi1s T4est 3a");
            Console.WriteLine(testYourOrder);

            Console.WriteLine("......................................................................................");

            DecendingOrder order = new DecendingOrder();
            var testdecending = order.OutputInDecendingOrder(234967021);
            Console.WriteLine(testdecending);
        }

        private static void ValidateStudent(Student std)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(std.StudentName))
                throw new InvalidStudentNameException(std.StudentName);

        }
    }

    public class MultipleOfThreeAndFIve
    {
        public int testingMultipleOfTHreeAndFIve(int value)
        {
            //using linq to get the sum of multiple of 3 and 5
            return Enumerable.Range(0, value).Where(n => n % 3 == 0 || n % 5 == 0).Sum();

        }

        public int testingMultipleOfThreeAndFiveLongWay(int value)
        {
            int sum = 0;
            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }

            }

            return sum;
        }

    }

    public class IntegerToBinary
    {

        public int CountingNumberOfBits(int value)
        {

            int SetBits = 0;

            while (value > 0)
            {

                SetBits += value & 1;
                value >>= 1; // shifting from the right hand operand to the left 
            }

            return SetBits;

            /* example (int 9 --> binary reprentation of (int 9) 00001001) --> for every  loop 
             * thats greater than 0 the Setbits is being counted when bit '1' is found and the
             * operand is shifted to the right until the binary representation of the value have been 
             * counted and return the total amount of the counted bits(which is => '1'). 
             */

        }

        public int CountSetBitsShortVersion(int value)
        {
            return Convert.ToString(value, 2).Count(c => c == '1');  // shorter verion of Count set number of bits.
        }

    }

    public class WeirdCaseTestEvenCharacterUpperCase
    {
        public string TurningStringEvenCharactersIntoUpperCase(string EvenCharacterStringConversion)
        {
            Exception customException = new Exception("Error");
            var testing = customException.Message; 

            #region testing code V1

            int adding = 1;

            string result = "";
            foreach (char item in EvenCharacterStringConversion)
            {

                if (adding % 2 == 0)
                {
                    result += char.ToLower(item);
                    adding++;
                }
                else if (item == ' ')
                {

                    result += " ";
                }

                else
                {
                    result += char.ToUpper(item);
                    adding++;
                }

            }

            Console.WriteLine(result);
            return result;
            #endregion

        }

        public string TurningEvencharacterInAStringIntoUpperCaseAndOddCharactersInTheSameStringIntoLowerCaseShortVersion(string uAndlCases)
        {
            return string.Join(" ",

                uAndlCases.Split(' ')
                .Select(
                       w => string.Concat(
                                     w.Select((ch, i) => i % 2 == 0 ? char.ToUpper(ch) : char.ToLower(ch)))));
        }
    }

    public class IQTest
    {
        public int ReturningThePositionOfEvenness(string listValues)
        {
            int[] arrayOfListValues = listValues.Split(' ')
                .Select(x => Convert.ToInt32(x)).ToArray();
            int countEven = arrayOfListValues.Count(x => x % 2 == 0);
            int theValue = 1;
            if (countEven > 1)
            {
                for (int i = 0; i < arrayOfListValues.Length; i++)
                {
                    if (arrayOfListValues[i] % 2 == 1)
                    {
                        theValue = i + 1;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arrayOfListValues.Length; i++)
                {
                    if (arrayOfListValues[i] % 2 == 0)
                    {
                        theValue = i + 1;
                        break;
                    }
                }
            }
            return theValue;
        }

        public int ReturningThePositionsShortVersion(string listValues)
        {
            // shorter version using linq
            var parseInt = listValues.Split(' ').Select(int.Parse).ToList();
            var turningEvenCharInListIntoUpperCaseCharacters = parseInt.GroupBy(n => n % 2).OrderBy(c => c.Count()).First().First();
            return parseInt.FindIndex(c => c == turningEvenCharInListIntoUpperCaseCharacters) + 1;

        }
    }

    public class YourOrderPlease
    {
        public string Order(string text)
        {

            if (text == string.Empty)
            {
                return text;

            }

            string[] aWord = text.Split(" ");

            text = string.Empty;

            for (int i = 1; i < 10; i++)
            {
                foreach (var theWord in aWord)
                {
                    if (theWord.Contains(i.ToString()))
                    {
                        text += theWord + " ";
                    }

                }

            }

            text = text.Substring(0, text.Length - 1);
            return text;


        }

        public string OrderShortVersion(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return string.Join(" ", text.Split(' ').OrderBy(s => s.ToList().Find(c => char.IsDigit(c))));
        }
    }

    public class RomanNumericalEncoder
    {
        string[] romanLetters = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] numbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        public string RomanConvert(int Value)
        {

            string romanLToN = "";
            for (int i = 0; i < romanLetters.Length && Value != 0; i++)
            {
                while (Value >= numbers[i])
                {
                    Value -= numbers[i];
                    romanLToN += romanLetters[i];
                }
            }

            return romanLToN;

        }

        public string RomanConvertUsingDictionary(int value)
        {
            var romToDict = new Dictionary<int, string>()
            {
                [1000] = "M",
                [900] = "CM",
                [500] = "D",
                [400] = "CD",
                [100] = "C",
                [90] = "XC",
                [50] = "L",
                [40] = "XL",
                [10] = "X",
                [9] = "IX",
                [5] = "V",
                [4] = "IV",
                [1] = "I"

            };

            var numberToString = new StringBuilder();

            foreach (var romToNum in romToDict)
            {
                while (romToNum.Key <= value)
                {

                    numberToString.Append(romToNum.Value);
                    value -= romToNum.Key;
                }
            }

            return numberToString.ToString();

        }


    }

    public class RomanNumericalDecoder 
    {
        public int RomanDecoder(string romanNum)
        {
            var romanAndNumIntoDic = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
               
            };

            romanNum = romanNum.ToUpper();

            int theValue = 0, subtract = 0;

            for (int i = 0; i < romanNum.Length; i++)
            {
                int theNumerical = romanAndNumIntoDic[romanNum[i]] - subtract;

                if (i >= romanNum.Length - 1 ||
                    theNumerical + subtract >= romanAndNumIntoDic[romanNum[i + 1]])
                {
                    theValue += theNumerical;
                    subtract = 0;
                }
                else 
                {
                    subtract = theNumerical;
                }
            }
            return theValue;
        }

        public int RomanDecoderShorVersion(string romNum) 
        {
            switch (romNum)
            {
                case "I": return 1;
                case "V": return 5;
                case "X": return 10;
                case "L": return 50;
                case "C": return 100;
                case "D": return 500;
                case "M": return 1000;
                default: return 0;
                    
            }
        }
    }

    public class VasyaClerk 
    {
        public string Tickets(int[] peopleInLine) 
        {
            int money_25 = 0;
            int money_50 = 0;
            int money_100 = 0;

            for (int i = 0; i < peopleInLine.Length; i++)
            {
                //$25
                if (peopleInLine[i] == 25)
                {
                    money_25++;
                }
                //$50 --> return $50-$25 = $25
                else if (peopleInLine[i] == 50 && money_25 > 0)
                {
                    money_50++;
                    money_25--;
                }
                //$100 --> return $100-$25 = $75 => $50+$25
                else if (peopleInLine[i] == 100 && money_25 > 0 && money_50 >0)
                {
                    money_100++;
                    money_50--;
                    money_25--;

                }
                //$100 --> return $100-$25 = $75 => 3*$25
                else if (peopleInLine[i] == 100 && money_25 > 2)
                {
                    money_100++;
                    money_25-=3;

                }
                else
                {
                    //not possible
                    return "NO";
                }
                
            }

               return "YES";
        }
       

        



    }

    public class CategorizeNewMember 
    {
        public IEnumerable<string> OpenOrSenior(int[][] data)
        {

            List<string> openSeniors = new List<string>();

            foreach (var item in data)
            {
                if (item[0] >= 55 && item[1] > 7)
                {
                    openSeniors.Add("Senior");
                }
                else
                {
                    openSeniors.Add("Open");
                }
                
            }

            return openSeniors;
        }
    }

    public class FindTheParityOutlier 
    {
        public int FindingTheParityOutliner(int[] intValue) 
        {
            List<int> even = new List<int>();
            List<int> odd  = new List<int>();

            for (int i = 0; i < intValue.Length; i++)
            {

                if (intValue[i] % 2 == 0)
                {
                    even.Add(intValue[i]);
                }
                else
                {
                    odd.Add(intValue[i]);
                }
            }

            if (even.Count > odd.Count)
            {
                return odd[0];
            }
            else return even[0];
        }


    }

    public class LoveAndFriendShip 
    {
        public int WordsToMarks(string str)
        {  
            return str.Where(c => char.IsLetter(c)).Sum(c => char.ToUpperInvariant(c) - 64);

            throw new NotImplementedException();
        }
    }

    public class DecendingOrder 
    {
        public int OutputInDecendingOrder(int theInputNum) 
        {
            // hashed array to store count of digits
            int[] countDigits = new int[10];

            // converting into string the input
            string str = theInputNum.ToString();

            // updating the count array
            for (int i = 0; i < str.Length; i++)
            {
                countDigits[str[i] - '0']++;
            }

            //result is to store the final number
            int theOutput = 0;  int multiplier = 1;

            //going through array to output the maximum number
            for (int i = 0; i < 10; i++)
            {
                while (countDigits[i] > 0)
                {
                    theOutput = theOutput + (i *multiplier);
                    countDigits[i]--;
                    multiplier = multiplier * 10;

                }

            }

            return theOutput;


            
        }
    }

    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }

    [Serializable]
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException()
        {

        }

        public InvalidStudentNameException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }

    }

}

