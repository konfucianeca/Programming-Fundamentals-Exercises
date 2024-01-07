using System;

namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            for (int i = 1; i <= 30; i++)
            {
                food -= 300;

                if (i % 2 == 0)
                {
                    hay -= food * 0.05;
                }

                if (i % 3 == 0)
                {
                    cover -= weight / 3;
                }

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");

                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(food / 1000):f2}, Hay: {(hay / 1000):f2}, Cover: {(cover / 1000):f2}.");
        }
    }
}

============================================================

using System;
using System.Linq;

namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxPeoplePerWagon = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                for (int j = lift[i]; j < maxPeoplePerWagon; j++)
                {
                    lift[i]++;
                    peopleWaiting--;

                    if (peopleWaiting == 0)
                    {
                        if (lift.Sum() < lift.Length * maxPeoplePerWagon)
                        {
                            Console.WriteLine("The lift has empty spots!");
                        }

                        Console.WriteLine(string.Join(' ', lift));

                        return;
                    }
                }
            }

            Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
            Console.WriteLine(string.Join(' ', lift));
        }
    }
}

========================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Shoot":
                        Shoot(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                    case "Add":
                        Add(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                    case "Strike":
                        Strike(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }

        static void Shoot(int index, int power, List<int> targets)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                return;
            }

            targets[index] -= power;

            if (targets[index] <= 0)
            {
                targets.RemoveAt(index);
            }
        }

        static void Add(int index, int value, List<int> targets)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                Console.WriteLine("Invalid placement!");

                return;
            }

            targets.Insert(index, value);
        }

        static void Strike(int index, int radius, List<int> targets)
        {
            if (index - radius < 0 || index + radius > targets.Count - 1)
            {
                Console.WriteLine("Strike missed!");

                return;
            }

            targets.RemoveRange(index - radius, radius * 2 + 1);
        }
    }
}

============================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            int turn = 1;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                int[] indices = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int firstIndex = indices[0];
                int secondIndex = indices[1];

                if (firstIndex == secondIndex
                    || firstIndex < 0
                    || firstIndex > elements.Count - 1
                    || secondIndex < 0
                    || secondIndex > elements.Count - 1)
                {
                    elements.Insert(elements.Count / 2, $"-{turn}a");
                    elements.Insert(elements.Count / 2, $"-{turn}a");

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (elements[firstIndex] == elements[secondIndex])
                {
                    string elementToRemove = elements[firstIndex];

                    elements.Remove(elementToRemove);
                    elements.Remove(elementToRemove);

                    Console.WriteLine($"Congrats! You have found matching elements - {elementToRemove}!");
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {turn} turns!");

                    return;
                }

                turn++;
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', elements));
        }
    }
}

========================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];
                switch (action)
                {
                    case "swap":
                        Swap(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "multiply":
                        Multiply(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "decrease":
                        Decrease(numbers);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void Swap(int firstIndex, int secondIndex, List<int> numbers)
        {
            int temp = numbers[firstIndex]; ;
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }

        static void Multiply(int firstIndex, int secondIndex, List<int> numbers)
        {
            numbers[firstIndex] = numbers[firstIndex] * numbers[secondIndex];
        }

        static void Decrease(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            };
        }
    }
}

===============================================================

using System;
using System.Linq;

namespace _06.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] places = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            int place = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Love!")
                {
                    break;
                }

                string[] tokens = command.Split();

                int jump = int.Parse(tokens[1]);

                if (place + jump > places.Length - 1)
                {
                    place = 0;

                    CheckPlace(place, places);
                }
                else
                {
                    place += jump;

                    CheckPlace(place, places);
                }
            }

            Console.WriteLine($"Cupid's last position was {place}.");

            int failedPlaces = GetFailedPlaces(places);

            if (failedPlaces > 0)
            {
                Console.WriteLine($"Cupid has failed {failedPlaces} places.");
            }
            else if (failedPlaces == 0)
            {
                Console.WriteLine("Mission was successful.");
            }

        }

        static void CheckPlace(int currentPosition, int[] places)
        {
            if (places[currentPosition] == 0)
            {
                Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
            }
            else
            {
                places[currentPosition] -= 2;

                if (places[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                }
            }
        }

        static int GetFailedPlaces(int[] places)
        {
            int failedPlaces = 0;

            foreach (var heart in places)
            {
                if (heart != 0)
                {
                    failedPlaces++;
                }

            }

            return failedPlaces;
        }
    }
}