using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int>  wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                if (tokens.Length == 2)
                {
                    int wagon = int.Parse(tokens[1]);
                    wagons.Add(wagon);
                }
                else
                {
                    int passangers = int.Parse(tokens[0]);
                    FindWagon(wagons, maxCapacity, passangers);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FindWagon(List<int> wagons, int maxCapacity, int passangers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentWagon = wagons[i];
                if (currentWagon + passangers <= maxCapacity)
                {
                    wagons[i] += passangers;
                    break;
                }
            }
        }
    }
}

using System;
using System.Linq;

namespace T02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split();
                string cmd = tokens[0];
                if (cmd == "Delete")
                {
                    int element = int.Parse(tokens[1]);
                    numbers.RemoveAll(el => el == element);
                }
                else if (cmd == "Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

using System;
using System.Collections.Generic;

namespace T03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           var listOfNames = new List<string>();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();   
                string currName = command[0];
                if (listOfNames.Contains(currName) && command[2] == "going!")
                {
                    Console.WriteLine($"{currName} is already in the list!");
                }
                else if (listOfNames.Contains(currName) && command[2] == "not")
                {
                    listOfNames.Remove(currName);
                }
                else if (!listOfNames.Contains(currName) && command[2] == "not")
                {
                    Console.WriteLine($"{currName} is not in the list!");
                }
                else
                {
                    listOfNames.Add(currName);
                }
            }

            foreach (var currName in listOfNames)
            {
                Console.WriteLine(currName);
            }
        }
    }
}

using System;
using System.Linq;

namespace T04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string commnad = Console.ReadLine();

            while (commnad != "End")
            {
                string[] tokens = commnad.Split();

                if (tokens[0] == "Add")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (tokens[0] == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    if (index > numbers.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, number);
                }
                else if (tokens[0] == "Remove")
                {
                    int index = int.Parse(tokens[1]);
                    if (index > numbers.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(index);
                }
                else if (tokens[0] == "Shift")
                {
                    int count = int.Parse(tokens[2]);
                    if (tokens[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (tokens[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count  -1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }

                commnad = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
          var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
          int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
          int bombNumber = tokens[0];
          int power = tokens[1];

          for (int i = 0; i < numbers.Count; i++)
          {
              int target = numbers[i];
              if (target == bombNumber)
              {
                  BombNumber(numbers, power, i);
                 
              }
          }

          Console.WriteLine(numbers.Sum());
        }

        private static void BombNumber(List<int> numbers, int power, int index)
        {
            int start = Math.Max(0, index - power);
            int end = Math.Min(numbers.Count - 1, index + power);
            for (int i = start; i <= end; i++)
            {
                numbers[i] = 0;
            }
        }
    }
}

using System;
using System.Linq;

namespace T06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);
                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);
                }

                firstPlayer.Remove(firstPlayer[0]);
                secondPlayer.Remove(secondPlayer[0]);

                if (firstPlayer.Count == 0)
                {
                    int sum = secondPlayer.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                if (secondPlayer.Count == 0)
                {
                    int sum = firstPlayer.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbersAsStrings = Console.ReadLine().Split('|').Reverse().ToList();
           
            var numbers = new List<int>();
            foreach (var number in numbersAsStrings)
            {
                numbers.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace T08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                if (command == "3:1") break;

                int startIndex = int.Parse(commands[1]);
                int endIndex = int.Parse(commands[2]);
                string concatedWord = "";
                if (endIndex > myList.Count - 1 || endIndex < 0)
                {
                    endIndex = myList.Count - 1;
                }

                if (startIndex < 0 || startIndex > myList.Count - 1)
                {
                    startIndex = 0;
                }

                if (command == "merge")
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatedWord += myList[i];
                    }
                    myList.RemoveRange(startIndex, endIndex - startIndex + 1);
                    myList.Insert(startIndex, concatedWord);
                }
                else if (command == "divide")
                {
                    var dividedList = new List<string>();
                    int partitions = int.Parse(commands[2]);
                    string word = myList[startIndex];
                    myList.RemoveAt(startIndex);
                    int parts = word.Length / partitions;
                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            dividedList.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            dividedList.Add(word.Substring(i * parts, parts));
                        }
                    }
                    myList.InsertRange(startIndex, dividedList);
                }
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}

using System;
using System.Linq;

namespace T09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            int index;
            int currentValue;
            int sum = 0;

            while (sequence.Count != 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    currentValue = sequence[0];
                    sum += currentValue;
                    sequence[0] = sequence[sequence.Count - 1];
                }
                else if (index > sequence.Count - 1)
                {
                    currentValue = sequence[sequence.Count - 1];
                    sum += currentValue;
                    sequence[sequence.Count - 1] = sequence[0];
                }
                else
                {
                    currentValue = sequence[index];
                    sum += currentValue;
                    sequence.RemoveAt(index);
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] <= currentValue)
                    {
                        sequence[i]  += currentValue;
                    }
                    else
                    {
                        sequence[i] -= currentValue;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] tokens = command.Split(":");
                switch (tokens[0])
                {
                    case "Add":
                        string lessonTitleToAdd = tokens[1];
                        AddLesson(schedule, lessonTitleToAdd);
                        break;
                    case "Insert":
                        string lessonTitleToInsert = tokens[1];
                        int atIndex = int.Parse(tokens[2]);
                        InsertLesson(schedule, lessonTitleToInsert, atIndex);
                        break;
                    case "Remove":
                        string lessonTitleToRemove = tokens[1];
                        RemoveLesson(schedule, lessonTitleToRemove);
                        break;
                    case "Swap":
                        string lessonTitleToSwap1 = tokens[1];
                        string lessonTitleToSwap2 = tokens[2];
                        SwapPositions(schedule, lessonTitleToSwap1, lessonTitleToSwap2);
                        break;
                    case "Exercise":
                        string exerciseToAdd = tokens[1];
                        AddExercise(schedule, exerciseToAdd);
                        break;
                }
                command = Console.ReadLine();
            }
            int counter = 1;
            foreach (var lesson in schedule)
            {
                Console.WriteLine($"{counter}.{lesson}");
                counter++;
            }
        }

        static void AddExercise(List<string> schedule, string exerciseToAdd)
        {
            if (schedule.Contains(exerciseToAdd) && !schedule.Contains($"{exerciseToAdd}-Exercise"))
            {
                int indexOfTheLesson = -1;
                for (int i = 0; i < schedule.Count; i++)
                {
                    if (schedule[i] == exerciseToAdd)
                    {
                        indexOfTheLesson = i;
                    }
                }
                int atIndexInsert = indexOfTheLesson + 1;
                schedule.Insert(atIndexInsert, $"{exerciseToAdd}-Exercise");
            }
            else if (!schedule.Contains(exerciseToAdd))
            {
                schedule.Add(exerciseToAdd);
                schedule.Add($"{exerciseToAdd}-Exercise");
            }
        }

        static void SwapPositions(List<string> schedule, string lessonTitleToSwap1, string lessonTitleToSwap2)
        {
            if (schedule.Contains(lessonTitleToSwap1) && schedule.Contains(lessonTitleToSwap2))
            {
                int firstLessonIndex = -1;
                int secondLessonIndex = -1;

                for (int i = 0; i < schedule.Count; i++)
                {
                    if (schedule[i] == lessonTitleToSwap1)
                    {
                        firstLessonIndex = i;
                    }
                    if (schedule[i] == lessonTitleToSwap2)
                    {
                        secondLessonIndex = i;
                    }
                }
                string temp = schedule[firstLessonIndex];
                schedule[firstLessonIndex] = schedule[secondLessonIndex];
                schedule[secondLessonIndex] = temp;

                if (schedule.Contains($"{lessonTitleToSwap1}-Exercise") && !schedule.Contains($"{lessonTitleToSwap2}-Exercise"))
                {
                    schedule.Insert(secondLessonIndex + 1, $"{lessonTitleToSwap1}-Exercise");
                    schedule.RemoveAt(firstLessonIndex + 2);
                }
                else if (!schedule.Contains($"{lessonTitleToSwap1}-Exercise") && schedule.Contains($"{lessonTitleToSwap2}-Exercise"))
                {
                    schedule.Insert(firstLessonIndex + 1, $"{lessonTitleToSwap2}-Exercise");
                    schedule.RemoveAt(secondLessonIndex + 2);
                }
                else if (schedule.Contains($"{lessonTitleToSwap1}-Exercise") && schedule.Contains($"{lessonTitleToSwap2}-Exercise"))
                {
                    string tempr = schedule[firstLessonIndex + 1];
                    schedule[firstLessonIndex + 1] = schedule[secondLessonIndex + 1];
                    schedule[secondLessonIndex + 1] = tempr;
                }
            }
        }

        static void RemoveLesson(List<string> schedule, string lessonTitleToRemove)
        {
            if (schedule.Contains(lessonTitleToRemove))
            {
                if (schedule.Contains($"{lessonTitleToRemove}-Exercise"))
                {
                    schedule.Remove($"{lessonTitleToRemove}-Exercise");
                }
                schedule.Remove(lessonTitleToRemove);
            }
        }

        static void InsertLesson(List<string> schedule, string lessonTitle, int atIndex)
        {
            if (!schedule.Contains(lessonTitle))
            {
                schedule.Insert(atIndex, lessonTitle);
            }
        }

        static void AddLesson(List<string> schedule, string lessonTitle)
        {
            if (!schedule.Contains(lessonTitle))
            {
                schedule.Add(lessonTitle);
            }
        }
    }
}