//01.CountCharsInAString.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();

        string[] input = Console.ReadLine().Split();

        foreach (var item in input)
        {
            foreach (var ch in item)
            {
                if (!chars.ContainsKey(ch))
                {
                    if (char.IsWhiteSpace(ch))
                    {
                        break;
                    }
                    chars.Add(ch, 1);
                }
                else
                {
                    chars[ch]++;
                }
            }      
        }
        foreach (var ch in chars)
        {
            Console.WriteLine($"{ch.Key} -> {ch.Value}");
        }
    }
}

=========================================================================

//02.AMinerTask.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> resources = new Dictionary<string, int>();

        string input = Console.ReadLine();
        string resource = null; 
        int count = 0, quantity;

        while (input != "stop")
        {
            if (count % 2 == 0)
            {
                resource = input;
            }
            else if (count % 2 == 1)
            {
                quantity = int.Parse(input);
                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, quantity);
                }
                else
                {
                    resources[resource] += quantity;
                }
            }
            
            count++;

            input = Console.ReadLine();
        }

        foreach (var res in resources)
        {
            Console.WriteLine($"{res.Key} -> {res.Value}");
        }
    }
}

====================================================================

//03.Orders.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

        string[] product = Console.ReadLine().Split();

        while (product[0] != "buy")
        {
            string name = product[0];
            double price = double.Parse(product[1]);
            int quantity = int.Parse(product[2]);

            if (!products.ContainsKey(name))
            {
                var temp = new List<double>();
                temp.Add(price);
                temp.Add(quantity);
                products.Add(name, temp);
            }
            else
            {
                foreach (var pr in products.Where(p => p.Key == name))
                {
                    products[name][0] = price;
                    products[name][1] += quantity;
                }
            }
            product = Console.ReadLine().Split();
        }
        foreach (var pr in products)
        {
            Console.WriteLine($"{pr.Key} -> {pr.Value[0] * pr.Value[1]:f2}");
        }
    }
}

=====================================================================================

//04.SoftUniParking.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> cars = new Dictionary<string, string>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] input = Console.ReadLine().Split();

            if (input[0] == "register")
            {
                if (cars.ContainsKey(input[1]))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {cars[input[1]]}");
                }
                else
                {
                    cars.Add(input[1], input[2]);
                    Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                }
            }
            else
            {
                if (!cars.ContainsKey(input[1]))
                {
                    Console.WriteLine($"ERROR: user {input[1]} not found");
                }
                else
                {
                    cars.Remove(input[1]);
                    Console.WriteLine($"{input[1]} unregistered successfully");
                }
            }
        }
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Key} => {car.Value}");
        }
    }
}

===================================================================================================

//05.Courses.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

        string[] input = Console.ReadLine().Split(" : ");

        while (input[0] != "end")
        {
            if (!courses.ContainsKey(input[0]))
            {
                var temp = new List<string>();
                temp.Add(input[1]);
                courses.Add(input[0], temp);
            }
            else
            {
                courses[input[0]].Add(input[1]);
            }

            input = Console.ReadLine().Split(" : ");
        }
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Key}: {course.Value.Count}");
            Console.Write("-- ");
            Console.WriteLine(string.Join("\r\n-- ", course.Value));
        }
    }
}

=====================================================================================

//06.StudentAcademy.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
        int number = int.Parse(Console.ReadLine());
        string currentStudent = null;

        for (int i = 1; i <= number * 2; i++)
        {
            string input = Console.ReadLine();

            if (i % 2 == 0)
            {
                if (!students.ContainsKey(currentStudent))
                {
                    var temp = new List<double>();
                    temp.Add(double.Parse(input));
                    students.Add(currentStudent, temp);
                }
                else
                {
                    students[currentStudent].Add(double.Parse(input));
                }
            }
            else
            {
                currentStudent = input;
            }
        }
        foreach (var student in students.Where(s => s.Value.Average() >= 4.50))
        {
            Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
        }
    }
}

=========================================================================================

//07.CompanyUsers.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

        string[] input = Console.ReadLine().Split(" -> ");

        while (input[0] != "End")
        {
            if (!companies.ContainsKey(input[0]))
            {
                var temp = new List<string>();
                temp.Add(input[1]);
                companies.Add(input[0], temp);
            }
            else
            {
                if (!companies[input[0]].Contains(input[1]))
                {
                    companies[input[0]].Add(input[1]);
                }
            }

            input = Console.ReadLine().Split(" -> ");
        }
        foreach (var company in companies)
        {
            Console.WriteLine($"{company.Key}");
            Console.Write("-- ");
            Console.WriteLine(string.Join("\r\n-- ", company.Value));
        }
    }
}