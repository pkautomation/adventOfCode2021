using System.Collections.Generic;

namespace Day01
{
    class FileReader
    {
        public static List<int> ReadFile(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@$"C:\repos\adventOfCode2021\AdventOfCode2021\AdventOfCode2021\{fileName}");
            var values =  new List<int>();

            foreach (var line in lines)
            {
                values.Add(int.Parse(line));
            }

            return values;
        }
    }
}
