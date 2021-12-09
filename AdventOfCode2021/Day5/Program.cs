using System;
using System.Collections.Generic;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersString = FileReader.ReadFile("data5.txt");
            var map = new int[1000, 1000];
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    map[i, j] = 0;
                }
            }

            foreach (var dataRow in numbersString)
            {
                var xValue1 = int.Parse(dataRow.Split("->")[0].Split(",")[0]);
                var xValue2 = int.Parse(dataRow.Split("->")[1].Split(",")[0]);
                var yValue1 = int.Parse(dataRow.Split("->")[0].Split(",")[1]);
                var yValue2 = int.Parse(dataRow.Split("->")[1].Split(",")[1]);

                if (Math.Abs(xValue1 - xValue2) == 0)
                {
                    //iterate over y
                    if (yValue1 > yValue2)
                    {
                        for (int i = yValue1; i >= yValue2; i--)
                        {
                            map[xValue1, i]++;
                        }
                    }
                    else
                    {
                        for (int i = yValue2; i >= yValue1; i--)
                        {
                            map[xValue1, i]++;
                        }
                    }
                }
                else if (Math.Abs(yValue1 - yValue2) == 0)
                {
                    // iterate over x
                    if (xValue1 > xValue2)
                    {
                        for (int i = xValue1; i >= xValue2; i--)
                        {
                            map[i, yValue1]++;
                        }
                    }
                    else
                    {
                        for (int i = xValue2; i >= xValue1; i--)
                        {
                            map[i, yValue1]++;
                        }
                    }
                }
                else
                {
                    var positionDiff = Math.Abs(yValue1 - yValue2);
                    int xDirection = xValue1 - xValue2;
                    if (xDirection > 0) xDirection = -1;
                    else xDirection = 1;
                    int yDirection = yValue1 - yValue2;
                    if (yDirection > 0) yDirection = -1;
                    else yDirection = 1;


                    for (int i = 0; i <= positionDiff; i++)
                    {
                        var currposx = xValue1 + i * xDirection;
                        var currposy = yValue1 + i * yDirection;
                        map[currposx, currposy] += 1;
                    }
                }
            }

            int score = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (map[i, j] > 1) score++;
                }
            }

            Console.WriteLine("score:" + score);
        }
    }
}
