using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
 
            List<string> validUsernames = new List<string>();
 
            foreach (var username in input)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isValid = true;
 
                    for (int i = 0; i < username.Length; i++)
                    {
                        char currentChar = username[i]; // 'J'
 
                        if (!(currentChar == '-' || currentChar == '_' || char.IsLetterOrDigit(currentChar)))
                        {
                            isValid = false;
                            break;
                        }
                    }
 
                    if (isValid)
                    {
                        validUsernames.Add(username);
                    }
                }
            }
 
            Console.WriteLine(String.Join(Environment.NewLine,validUsernames));
 
        }
    }
}

============================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
 
            Console.WriteLine(CharMultiplier(input[0],input[1]));
        }
 
        public static int CharMultiplier(string str1, string str2)
        {
            int sum = 0;
 
            string longest = "";
            string shortest = "";
 
            if (str1.Length > str2.Length)
            {
                longest = str1;
                shortest = str2;
            }
            else
            {
                longest = str2;
                shortest = str1;
            }
 
            for (int i = 0; i < shortest.Length; i++)
            {
                sum += str1[i] * str2[i]; 
            }
 
            for (int i = shortest.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }
 
            return sum;
        }
    }
}

=======================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\', StringSplitOptions.RemoveEmptyEntries);
 
            string[] fileName = input[input.Length - 1].Split('.');
 
            Console.WriteLine("File name: "+fileName[0]);
            Console.WriteLine("File extension: "+fileName[1]);
 
        }
    }
}

==============================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
 
            string cipheredText = String.Empty;
 
            for (int i = 0; i < input.Length; i++)
            {
                cipheredText += (char)(input[i] + 3);
            }
 
            Console.WriteLine(cipheredText);
 
        }
    }
}

=========================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string reallyBigNum = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
 
            // 8
            // 9999
            //    9
            // 89991
 
            if (num == 0)
            {
                Console.WriteLine(0);
                return;
            }
 
            StringBuilder sb = new StringBuilder();
            int remainder = 0;
 
            for (int i = reallyBigNum.Length - 1; i >= 0; i--)
            {
                char lastNum = reallyBigNum[i]; 
                int lastNumAsDigit = int.Parse(lastNum.ToString()); 
 
                int result = lastNumAsDigit * num + remainder; 
 
                sb.Append(result % 10);
 
                remainder = result / 10; 
            }
 
            if (remainder != 0)
            {
                sb.Append(remainder);
            }
 
            StringBuilder reversedString = new StringBuilder();
 
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversedString.Append(sb[i]);
            }
 
            Console.WriteLine(reversedString);
        }
    }
}

======================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
 
            StringBuilder sb = new StringBuilder();
            sb.Append(text[0]);
 
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == text[i - 1])
                {
                    continue;
                }
                sb.Append(text[i]);
            }
 
            Console.WriteLine(sb);
        }
    }
}

==========================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            // abv>1>1>2>2asdasd
 
            StringBuilder sb = new StringBuilder();
 
            int power = 0;
 
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
 
                if (current == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    sb.Append(current);
                }
                else if(power == 0){
                    sb.Append(current);
                }
                else
                {
                    power--;
                }
 
            }
 
            Console.WriteLine(sb);
        }
    }
}

=========================================================================

using System;
using System.Collections.Generic;
using System.Text;
 
namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // A12b s17G
 
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
 
            double sum = 0;
 
            foreach (var item in input)
            {
                // A12b
 
                char firstLetter = item[0]; // 'A'
                char lastLetter = item[item.Length - 1]; // 'b'
 
                double number = double.Parse(item.Substring(1, item.Length - 2)); // 12
 
                double result = 0;
 
 
 
                // check if upper:
                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    int firstLetterPositionInTheAlphabet = firstLetter - 64;
                    result = number / firstLetterPositionInTheAlphabet;
                }
                else 
                {
                    int firstLetterPositionInTheAlphabet = firstLetter - 96;
                    result = number * firstLetterPositionInTheAlphabet;
                }
 
                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    int lastLetterPositionInTheAlphabet = lastLetter - 64;
                    sum += result - lastLetterPositionInTheAlphabet;
                }
                else
                {
                    int lastLetterPositionInTheAlphabet = lastLetter - 96;
                    sum += result + lastLetterPositionInTheAlphabet;
                }
 
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}