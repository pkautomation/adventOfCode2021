using System;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // var data = FileReader.ReadFile();

            // Submarine sub = new Submarine();

            // foreach (var line in data)
            // {
            //     int value = int.Parse(line.Split(' ')[1]);
            //     string move = line.Split(' ')[0];
            //     if (move == "forward")
            //     {
            //         sub.position += value;
            //         sub.depth = sub.depth + sub.aim * value;
            //     }
            //     if (move == "up")
            //     {
            //         sub.aim -= value;
            //     }
            //     if (move == "down")
            //     {
            //         sub.aim += value;
            //     }

            // }

            // Console.WriteLine($"final position, depth: {sub.depth} value: {sub.position}");
            // Console.WriteLine($"Outcome for task1: {sub.depth * sub.position}");

            var lines = FileReader.ReadFile("data2.txt");

            var lines2 = FileReader.ReadFile("data2.txt");
            var bitValues = new int[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    var line = lines[i];
                    bitValues[i, j] = int.Parse(line[j].ToString());
                }
            }

            Console.WriteLine("number of lines:" + bitValues.GetLength(0));
            Console.WriteLine("row length:" + bitValues.GetLength(1));

            var stringres = "";
            int zerohitsAmount = 0;

            for (int i = 0; i < bitValues.GetLength(1); i++)
            {
                zerohitsAmount = 0;
                for (int j = 0; j < bitValues.GetLength(0); j++)
                {
                    if (bitValues[j, i] == 0)
                    {
                        zerohitsAmount++;
                    }
                    if (j == bitValues.GetLength(0) - 1)
                    {
                        if (zerohitsAmount > 500)
                        {
                            stringres += "0";
                        }
                        else
                        {
                            stringres += "1";
                        }
                    }
                }
            }
            Console.WriteLine(stringres);

            var finalValue = 0;

            for (int i = stringres.Length - 1; i >= 0; i--)
            {
                if (stringres[i] != '0') finalValue += (int)Math.Pow(2, stringres.Length - 1 - i);
            }

            var finalValue2 = 0;

            for (int i = stringres.Length - 1; i >= 0; i--)
            {
                if (stringres[i] != '1') finalValue2 += (int)Math.Pow(2, stringres.Length - 1 - i);
            }


            /////////////////

            for (int i = 0; i < lines[0].Length; i++)
            {
                if (lines.Length == 1) break;
                var keep = CompareOnesToZeros(lines, i);
                if (keep >= 0)
                {
                    lines = lines.Where(x => x.ElementAt(i) == '1').ToArray();
                }
                else
                {
                    lines = lines.Where(x => x.ElementAt(i) == '0').ToArray();
                }

            }

            var firstString = lines[0];


            for (int i = 0; i < lines2[0].Length; i++)
            {
                if (lines2.Length == 1) break;
                var keep = CompareOnesToZeros(lines2, i);
                if (keep >= 0)
                {
                    lines2 = lines2.Where(x => x.ElementAt(i) == '0').ToArray();
                }
                else
                {
                    lines2 = lines2.Where(x => x.ElementAt(i) == '1').ToArray();
                }

            }

            var secondString = lines2[0];

            Console.WriteLine("result");
            Console.WriteLine(Convert.ToInt32(firstString, 2) * Convert.ToInt32(secondString, 2));

            var final1 = 0;

            for (int i = firstString.Length - 1; i >= 0; i--)
            {
                if (firstString[i] != '0') final1 += (int)Math.Pow(2, firstString.Length - 1 - i);
            }

            var final2 = 0;

            for (int i = secondString.Length - 1; i >= 0; i--)
            {
                if (secondString[i] != '1') final2 += (int)Math.Pow(2, secondString.Length - 1 - i);
            }

            Console.WriteLine(final1 * final2);


        }




        public static int CompareOnesToZeros(string[] arr, int atIndex)
        {
            int oneAmount = 0;
            int zeroAmount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].ElementAt(atIndex) == '0')
                {
                    zeroAmount++;
                }
                else
                {
                    oneAmount++;
                }
            }

            if (oneAmount > zeroAmount)
            {
                return 1;
            }
            if (oneAmount == zeroAmount)
            {
                return 0;
            }
            if (oneAmount < zeroAmount)
            {
                return -1;
            }

            return 0;
        }
    }
    }
}
