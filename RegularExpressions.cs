using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}

===============================================================

using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359([ \-])2\1[0-9]{3}\1[0-9]{4}\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
========================================================================

using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<day>[0-9]{2})(?<separator>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}

========================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> pricesByArea = new Dictionary<string, List<int>>();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (WebClient client = new WebClient { Encoding = System.Text.Encoding.UTF8 })
            {
                for (int i = 1; i < 25; i++)
                {
                    string htmlCode = GetHtml(client, i);

                    MatchCollection matches = Regex.Matches(htmlCode, @"<div class=""price"">(?:<img.*?>)?(?<price>.*?)<.*?<a.*?<a.*?>(?<area>.*?)<", RegexOptions.Singleline);

                    foreach (Match item in matches)
                    {
                        string[] tokens = item.Groups["price"].Value.Split("EUR", StringSplitOptions.RemoveEmptyEntries);
                        string priceStr = tokens[0].Trim().Replace(" ", "");
                        if (int.TryParse(priceStr, out int price))
                        {
                            string area = item.Groups["area"].Value;

                            if (!pricesByArea.ContainsKey(area))
                            {
                                pricesByArea.Add(area, new List<int>());
                            }

                            pricesByArea[area].Add(price);

                        }

                        Console.WriteLine($"Area: {item.Groups["area"].Value}, Price: {item.Groups["price"].Value}");
                    }
                }
            }

            Console.WriteLine();

            foreach (var item in pricesByArea)
            {
                Console.WriteLine($"Area: {item.Key}, Average price: {item.Value.Average()}, Count: {item.Value.Count}");
            }
        }

        private static string GetHtml(WebClient client, int index)
        {
            byte[] content = client.DownloadData(@$"https://www.imot.bg/pcgi/imot.cgi?act=3&slink=88o5rs&f1={index}");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding1251 = Encoding.GetEncoding("windows-1251");
            var convertedBytes = Encoding.Convert(encoding1251, Encoding.UTF8, content);

            string htmlCode = Encoding.UTF8.GetString(convertedBytes);

            return htmlCode;
        }
    }
}

=======================================================================================

