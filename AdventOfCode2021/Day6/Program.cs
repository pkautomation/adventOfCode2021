using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersString = FileReader.ReadFile("data6.txt");

            var lanternFishesString = numbersString[0].Split(',').ToList();
            var lanternFishes = new List<int>();
            var lanternFishesNextDay = new List<int>();
            lanternFishesString.ForEach(fish => lanternFishes.Add(int.Parse(fish)));
            var numberOfOnes = lanternFishes.Count(x => x == 1);
            var numberOfTwos = lanternFishes.Count(x => x == 2);
            var numberOfThrees = lanternFishes.Count(x => x == 3);
            var numberOfFours = lanternFishes.Count(x => x == 4);
            var numberOfFives = lanternFishes.Count(x => x == 5);

            long res = CalculateFishes(0);
            Console.WriteLine(res);
            for (int i = 1; i <= 5; i++)
            {
                //res += CalculateFishes(i) * lanternFishes.Count(x => x == i);
            }

            //            Console.WriteLine(res);

        }

        public static long CalculateFishes(int currentIteration, int daysLeft = 255)
        {
            if (daysLeft == 0) return 0;
            if (currentIteration == 0) return 1 + CalculateFishes(8, daysLeft - 1) + CalculateFishes(6, daysLeft - 1);
            else return CalculateFishes(currentIteration - 1, daysLeft);
        }

    }
}
