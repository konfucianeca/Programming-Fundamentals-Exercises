using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(SmallestNumber(num1, num2, num3));
        }

        static int SmallestNumber(int a, int b, int c)
        {
           return  Math.Min(a, Math.Min(b, c));
        }
    }
}

=================================================================

using System;
using System.Linq;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();
            SearchForVoweles(inputText);
        }

        private static void SearchForVoweles(string text)
        {
            int count = 0;
            // Console.WriteLine(text.Count(vowles => "aouei".Contains(vowles)));
            foreach (char vowle in text)
            {
                if ("aouei".Contains(vowle))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}

===================================================================

using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            CharsInRange(firstChar, secondChar);
        }

        private static void CharsInRange(char firstChar, char secondChar)
        {
            int startChar = Math.Min(firstChar, secondChar);
            int endChar = Math.Max(firstChar, secondChar);

            for (int i = startChar + 1; i < endChar; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}

====================================================================

using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isPasswordLengthValid = ValidatePasswordLength(password);
            bool isPasswordContainsValidSymbols = ValidatePasswordText(password);
            bool isDigitInPasswordLeastTwo = ValidatePasswordDigit(password);

            if (!isPasswordLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isPasswordContainsValidSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isDigitInPasswordLeastTwo)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isDigitInPasswordLeastTwo && isPasswordContainsValidSymbols && isPasswordLengthValid)
            {
                Console.WriteLine($"Password is valid");
            }
        }

        private static bool ValidatePasswordDigit(string password)
        {
            int count = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    count++;
                }
            }
            return count >= 2;
        }

        private static bool ValidatePasswordText(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidatePasswordLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}

=================================================================

using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int addedResult = AddNumbers(num1, num2);
            int finalResult = SubstractNumbers(addedResult, num3);
            PrintResult(finalResult);
        }

        private static int AddNumbers(int num1, int num2) => num1 + num2;


        private static int SubstractNumbers(int result, int num3) => result - num3;

        private static void PrintResult(int number) => Console.WriteLine(number);
    }
}

======================================================================

using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            PrintMiddleCharacters(word);
        }

        private static void PrintMiddleCharacters(string word)
        {
            if (word.Length % 2 == 0)
            {
                Console.Write(word[word.Length / 2 - 1]);
                Console.WriteLine(word[word.Length / 2]);
            }
            else
            {
                Console.WriteLine(word[word.Length / 2]);
            }
        }
    }
}

===================================================================

using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int input = int.Parse(Console.ReadLine());
           MatrixCreator(input);
        }

        private static void MatrixCreator(int input)
        {
            for (int rows = 0; rows < input; rows++)
            {
                for (int cols = 0; cols < input; cols++)
                {
                    Console.Write(input + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}

==================================================================

using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            double result1 = Factoriel(firstNum);
            double result2 = Factoriel(secondNum);
            PrintResult(result1, result2);
        }

        private static void PrintResult(double result1, double result2) => Console.WriteLine($"{result1 / result2:F2}");

        private static double Factoriel(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result *= number;
                number--;
            }
            return result;
        }
    }
}

==========================================================================

using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
           while (input != "END")
           {
               bool isIntegerPalindrome = IsNumberPalindrom(input);
               Console.WriteLine(isIntegerPalindrome.ToString().ToLower());
               input = Console.ReadLine();
           }
        }

        private static bool IsNumberPalindrom(string input)
        {
            int number = int.Parse(input);
            if (number >= 0 && number <= 9)
            {
                return true;
            }

            if (input[0] == input[input.Length - 1]) return true;

            return false;
        }
    }
}

=======================================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
           string[] command = Console.ReadLine().Split();
           while (command[0] != "end")
           {
               if (command[0] == "exchange")
               {
                   int givenIndex = int.Parse(command[1]);
                   arr = ExchangeArr(arr, givenIndex);
               }
               else if (command[0] == "max" || command[0] == "min")
               {
                   FindMinMax(arr, command[0], command[1]);
               }
               else
               {
                   FindNumbers(arr, command[0], int.Parse(command[1]), command[2]);
               }
               command = Console.ReadLine().Split();
           }

           Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void FindNumbers(int[] arr, string possition, int numbersCount, string evenOdd)
        {
            if (numbersCount > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (numbersCount == 0)
            {
                Console.WriteLine($"[]");
                return;
            }

            int resultEvenOdd = 1;
            if (evenOdd == "even") resultEvenOdd = 0;
            int count = 0;
            List<int> nums = new List<int>();

            if (possition == "first")
            {
                foreach (int num in arr)
                {
                    if (num % 2 == resultEvenOdd)
                    {
                        count++;
                        nums.Add(num);
                    }
                    if(count == numbersCount) break;
                }
            }
            else
            {
                for (int currIndex = arr.Length - 1; currIndex >= 0; currIndex--)
                {
                    if (arr[currIndex] % 2 == resultEvenOdd)
                    {
                        count++;
                        nums.Add(arr[currIndex]);
                    }
                    if (count == numbersCount) break;
                }
                nums.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static void FindMinMax(int[] arr, string minOrMax, string evenOrOdd)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;
            int resultOddEven = 1;

            if (evenOrOdd == "even") resultOddEven = 0;

            for (int currIndex = 0; currIndex < arr.Length; currIndex++)
            {
                if (arr[currIndex] % 2 == resultOddEven)
                {
                    if (minOrMax == "min" && min >= arr[currIndex])
                    {
                        min = arr[currIndex];
                        index = currIndex;
                    }
                    else if (minOrMax == "max" && max <= arr[currIndex])
                    {
                        max = arr[currIndex];
                        index = currIndex;
                    }
                }
                
            }

            Console.WriteLine(index > -1 ? index.ToString() : "No matches");
        }

        private static int[] ExchangeArr(int[] arr, int splitIndex)
        {
            if (splitIndex >= arr.Length || splitIndex < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            int[] exchangedArray = new int[arr.Length];
            int index = 0;
            for (int i = splitIndex + 1; i < arr.Length; i++)
            {
                exchangedArray[index] = arr[i];
                index++;
            }

            for (int i = 0; i <= splitIndex; i++)
            {  
                exchangedArray[index] = arr[i];
                index++;
            }

            return exchangedArray;
        }
    }
}