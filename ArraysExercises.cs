using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numberOfWagons];

            int sum = 0;

            for (int indexOfWagons = 0; indexOfWagons < wagons.Length; indexOfWagons++)
            {
                wagons[indexOfWagons] = int.Parse(Console.ReadLine());
                sum += wagons[indexOfWagons];
            }

            foreach (int wagon in wagons)
            {
                Console.Write($"{wagon} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}

================================================================

using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            // [Hey, hello, 2, 4]
            string[] arrOne = Console.ReadLine().Split(' ');
            // [10, hey, 4, hello]
            string[] arrTwo = Console.ReadLine().Split(' ');

            foreach (string currElement in arrOne)
            {
                for (int i = 0; i < arrTwo.Length; i++)
                {
                    string secondCurElement = arrTwo[i];
                    if (currElement == secondCurElement)
                    {
                        Console.Write($"{currElement} ");
                        break;
                    }
                }
            }

        }
    }
}

================================================================

using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] evenArray = new int[lines];
            int[] oddArray = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    evenArray[i] = numbers[0];
                    oddArray[i] = numbers[1];
                }
                else
                {
                    evenArray[i] = numbers[1];
                    oddArray[i] = numbers[0];
                }
            }

            Console.WriteLine(String.Join(" ",  evenArray));
            Console.WriteLine(String.Join(" ", oddArray));
        }
    }
}

================================================================

using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int tempEl = arr[0];
                for (int operations = 0; operations < arr.Length - 1; operations++)
                {
                    arr[operations] = arr[operations + 1];
                }

                arr[arr.Length - 1] = tempEl;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}

====================================================================

using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < inputArray.Length; i++)
            {
                int currentIterationNum = inputArray[i];
                bool currIterattionNumIsBigger = true;
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    int nextIterationNum = inputArray[j];
                    if (currentIterationNum <= nextIterationNum)
                    {
                        currIterattionNumIsBigger = false;
                        break;
                    }
                }

                if (currIterattionNumIsBigger)
                {
                    Console.Write($"{currentIterationNum} ");
                }
            }
        }
    }
}

===============================================================

using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                leftSum = 0;
                // 1 2 3 3
                for (int sumLeft = i; sumLeft > 0; sumLeft--)
                {
                    int nextLeftElementPosition = sumLeft - 1;
                    if (sumLeft > 0)
                    {
                        leftSum += numbers[nextLeftElementPosition];
                    }
                }

                rightSum = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    int nextElementPositon = j + 1;
                    if (j < numbers.Length - 1)
                    {
                        rightSum += numbers[nextElementPositon];
                    }
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}

===============================================================

using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // sequence length 
            int sequenceLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] DNA = new int[sequenceLength];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;
            int dnaSamples = 0;

            int sample = 0;

            while (input != "Clone them!")
            {
                // Current DNA info
                sample++;
                int[] currDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                // Current DNA elements
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDnaSum = 0;
                bool isCurrDnaBetter = false;


                int count = 0;
                for (int i = 0; i < currDNA.Length; i++)
                {
                    if (currDNA[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count > currCount) // 1 0 11
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }
                // 1 0 11 0 => endIndex 3 => 3 - 2 => 1 + 1 => 2 // first sample #
                // 0 11 0 0 => endIdex 2 => 2 - 2 => 0 + 1 => start index = 1 ; second sample
                // 00 11 0 1 => 11 (endIndex = 2) => (startIndex 2 - 2 = 0 + 1 => 1)
                currStartIndex = currEndIndex - currCount + 1;
                currDnaSum = currDNA.Sum();

                //CHECK CURRENT DNA WITH BEST DNK

                if (currCount > dnaCount)
                {
                    isCurrDnaBetter = true;
                }
                else if (currCount == dnaCount)
                {
                    if (currStartIndex < dnaStartIndex)
                    {
                        isCurrDnaBetter = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        if (currDnaSum > dnaSum)
                        {
                            isCurrDnaBetter = true;
                        }
                    }
                }



                if (isCurrDnaBetter)
                {
                    DNA = currDNA;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}

================================================================

using System;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initial field size
            int filedSize = int.Parse(Console.ReadLine());

            int[] ladBugsField = new int[filedSize]; // [0 0 0]

            string[] occupiedIndexes = Console.ReadLine().Split(); // 0 1 => [1 1 0]

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndex = int.Parse(occupiedIndexes[i]);
                if (currentIndex >= 0 && currentIndex < filedSize)
                {
                    ladBugsField[currentIndex] = 1; // [1 0 0]
                                                    // [1 1 0]
                }
            }

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                bool isFirst = true;
                int currentIndex = int.Parse(commands[0]);
                while (currentIndex >= 0 && currentIndex < filedSize && ladBugsField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladBugsField[currentIndex] = 0;
                        isFirst = false;
                    }

                    string direction = commands[1];
                    int flightLenght = int.Parse(commands[2]);
                    if (direction == "left")
                    {
                        currentIndex -= flightLenght;
                        if (currentIndex >= 0 && currentIndex < filedSize)
                        {
                            if (ladBugsField[currentIndex] == 0)
                            {
                                ladBugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentIndex += flightLenght;
                        if (currentIndex >= 0 && currentIndex < filedSize)
                        {
                            if (ladBugsField[currentIndex] == 0)
                            {
                                ladBugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladBugsField));
        }
    }
}