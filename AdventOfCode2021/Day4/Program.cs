using System;
using System.Collections.Generic;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                var numbersString = FileReader.ReadFile("data4a.txt")[0];
                var numbersArray = numbersString.Split(',');
                var numbersToBingo = new int[numbersArray.Length];

                int iter = 0;

                foreach (var str in numbersArray)
                {
                    numbersToBingo[iter] = int.Parse(numbersArray[iter]);
                    iter++;
                }

                var bingosLines = FileReader.ReadFile("data4b.txt");


                var allCards = new List<List<string>>();
                var currentCard = new List<string>();

                foreach (var line in bingosLines)
                {
                    if (line.Length == 0)
                    {
                        if (currentCard.Count > 0) allCards.Add(currentCard);
                        currentCard = new List<string>();
                    }
                    else
                    {
                        currentCard.Add(line);
                    }
                }

                string bingoValuesSoFar = "";
                int indexOfAddedNumber = 0;
                while (true)
                {
                    bingoValuesSoFar += numbersArray[indexOfAddedNumber];
                    List<int> cardsToRemove = new List<int>();
                    int indexToRemove = 0;
                    foreach (var card in allCards)
                    {
                        if (IsCardVictorious(card, bingoValuesSoFar))
                        {
                            Console.WriteLine(CalculateScore(card, bingoValuesSoFar));
                            Console.WriteLine("numbers while winning:" + bingoValuesSoFar);
                            cardsToRemove.Add(indexToRemove);
                        }
                        indexToRemove++;
                    }

                    cardsToRemove.Sort();
                    cardsToRemove.Reverse();

                    foreach (var item in cardsToRemove)
                    {
                        allCards.RemoveAt(item);
                    }

                    indexOfAddedNumber++;
                    bingoValuesSoFar += " ";
                }


            }

            public static int CalculateScore(List<string> cardToCheck, string valuesSoFar)
            {
                int score = 0;
                var bingoValues = valuesSoFar.Replace("  ", " ").Trim().Split(" ");

                foreach (var cardLine in cardToCheck)
                {
                    var lineValuesArray = cardLine.Replace("  ", " ").Trim().Split(" ");
                    foreach (var currentVal in lineValuesArray)
                    {
                        if (!IsValueOnBingoValuesList(currentVal, valuesSoFar))
                        {
                            score += int.Parse(currentVal);
                        }
                    }
                }

                return score;
            }

            public static bool IsValueOnBingoValuesList(string val, string valuesSoFar)
            {
                var valuesSoFarArray = valuesSoFar.Replace("  ", " ").Trim().Split(" ");

                foreach (var item in valuesSoFarArray)
                {
                    if (val == item)
                        return true;
                }
                return false;
            }

            public static bool IsCardVictorious(List<string> card, string valuesSoFar)
            {
                var bingoValues = valuesSoFar.Replace("  ", " ").Trim().Split(" ");

                foreach (var cardLine in card)
                {
                    var lineValuesArray = cardLine.Replace("  ", " ").Trim().Split(" ");
                    var hitCounter = 0;

                    foreach (var rowItem in lineValuesArray)
                    {
                        if (IsValueOnBingoValuesList(rowItem, valuesSoFar))
                        {
                            hitCounter++;
                        }
                    }
                    if (hitCounter == 5)
                        return true;
                }



                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    var hitCounter2 = 0;
                    var columnValues = new List<string>();
                    for (int j = 0; j < 5; j++)
                    {
                        var toAdd = card[j].Replace("  ", " ").Trim().Split(" ")[columnIndex];
                        columnValues.Add(toAdd);
                    }
                    var valuesToCheck = columnValues.ToArray();
                    foreach (var columnItem in valuesToCheck)
                    {
                        if (IsValueOnBingoValuesList(columnItem, valuesSoFar))
                        {
                            hitCounter2++;
                        }
                    }
                    if (hitCounter2 == 5)
                        return true;

                }

                return false;
            }
        }
    }
}
