using System;
using System.Collections.Generic;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                var file = FileReader.ReadFile("data8.txt");
                var outputList = new List<string>();
                var valueList = new List<string>();

                file.ToList().ForEach(line => {
                    line.Split('|')[0].Trim().Split(" ").ToList().ForEach(x => {
                        outputList.Add(x);
                    });
                    line.Split('|')[1].Trim().Split(" ").ToList().ForEach(x => {
                        valueList.Add(x);
                    });
                });

                Dictionary<int, int> segments = new Dictionary<int, int>();
                segments.Add(2, 1);
                segments.Add(4, 4);
                segments.Add(3, 7);
                segments.Add(7, 8);


                var allNumbers = new List<int>();

                var score = 0;
                var digitChecker = 1000;
                foreach (var value in valueList)
                {
                    var val = GetSegmentValueFromString(value, segments);
                    score += (val * digitChecker);
                    digitChecker /= 10;
                    if (digitChecker == 1)
                    {
                        allNumbers.Add(score);
                        digitChecker = 1000;
                        score = 0;
                    }
                }

                Console.WriteLine(allNumbers.Sum());
            }

            public static int GetSegmentValueFromString(string input, Dictionary<int, int> segmValues)
            {
                var res = input.Distinct().ToArray();
                Array.Sort(res);

                var cleanInput = new String(res);


                if (cleanInput.Contains("abcdef")) return 9;
                if (cleanInput.Contains("acdfg")) return 6;
                if (cleanInput.Contains("bcdef")) return 5;
                if (cleanInput.Contains("abcdf")) return 3;
                if (cleanInput.Contains("abcdefg")) return 8;

                if (segmValues.ContainsKey(input.Length))
                {
                    return segmValues[input.Length];
                }


                return -1;
            }
        }
    }
}
