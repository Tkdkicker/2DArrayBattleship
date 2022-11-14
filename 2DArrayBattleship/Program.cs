using System;
using System.Collections.Generic;

namespace _2DArrays

{
    internal class Program

    {
        #region Main

        private static void Main(string[] args)
        {
            Random _markedWarship = new();
            List<int> _randomHolder = new();
            List<int> _twoDimensionalList = new();
            int[,] _twoDimensional = new int[3, 4]

                {//  0, 1, 2, 3
                    {0, 1, 2, 3 },//0

                    {4, 5, 6, 7 },//1

                    {8, 9, 10, 11 }//2
                };

            RandomGenerator(_markedWarship, _randomHolder, _twoDimensionalList, _twoDimensional);

            Introduction("Welcome to the battleship game where you have to guess the coordinates of 5 ship locations");

            ArrayDisplay(_twoDimensional);

            //WarshipMarker(_randomHolder, _twoDimensional);

            UserInput(out int x, out int y);

            Result(x, y, _randomHolder);
        }

        #endregion Main

        #region RandomGenerator

        public static void RandomGenerator(Random markedWarship, List<int> randomHolder, List<int> twoDimensionalList, int[,] twoDimensional)
        {
            foreach (int first in twoDimensional)
            {
                twoDimensionalList.Add(first);
            }

            for (int start = 0; start < 10; start++)
            {
                int randomNumber = markedWarship.Next(start, twoDimensional.Length);

                //Add the 5 randomly generated unique numbers to the list
                if (!randomHolder.Contains(randomNumber) && randomHolder.Count < 5)
                {
                    randomHolder.Add(randomNumber);
                }
            }
            randomHolder.ToArray();//Convert the list to an array
        }

        #endregion RandomGenerator

        #region WarshipMarker

        public static void WarshipMarker(List<int> randomHolder, int[,] twoDimensional)
        {
            int index = Array.Find(randomHolder.ToArray(), element => element == twoDimensional[2, 3]);

            //TO DO:
            //replace 'twoDimensional' array chosen numbers with an 'X'

            //Shows all the numbers in the array and forms them equally as a rectangle or square
            foreach (int first in twoDimensional)
            {
                //When the array row is more than 0 and the column index is 0, add a new line
                if (twoDimensional[1, 0] == first || twoDimensional[2, 0] == first)
                {
                    Console.WriteLine("\n");
                }
                Console.Write(string.Join("", first, "\t"));//Join the formed numbers with a space and a tab
            }
            Console.WriteLine("\n");//Add a new line to allow room for the next function
        }

        #endregion WarshipMarker

        #region Introduction

        public static void Introduction(string welcome)
        {
            Console.WriteLine(welcome);
        }

        #endregion Introduction

        #region ArrayDisplay

        public static void ArrayDisplay(int[,] twoDimensional)
        {
            //Shows all the numbers in the array and forms them equally as a rectangle or square
            foreach (int first in twoDimensional)
            {
                //When the array row is more than 0 and the column index is 0, add a new line
                if (twoDimensional[1, 0] == first || twoDimensional[2, 0] == first)
                {
                    Console.WriteLine("\n");
                }
                Console.Write(string.Join("", first, "\t"));//Join the formed numbers with a space and a tab
            }
            Console.WriteLine("\n");//Add a new line to allow room for the next function
        }

        #endregion ArrayDisplay

        #region UserInput

        public static void UserInput(out int x, out int y)
        {
            Console.WriteLine("Choose an x coordinate in the range of 0-3");
            x = int.Parse(Console.ReadLine());

            Console.WriteLine("Now choose a y coordinate in the range of 0-4");
            y = int.Parse(Console.ReadLine());
        }

        #endregion UserInput

        #region Result

        public static void Result(int x, int y, List<int> _randomholder)
        {
            if (x > 3 && y > 4 || x > 3 || y > 4)
            {
                Console.WriteLine("Incorrect range");
            }

            int findX = Array.Find(_randomholder.ToArray(), element => element == x);
            int findY = Array.Find(_randomholder.ToArray(), element => element == y);

            while (findX != x && findY != y)
            {
                for (int start = 0; start <= 5; start++)
                {
                    if (findX == x && findY == y)
                    {
                        Console.Write("You have found this amount of battleships: " + findX + "," + findY + "\n");
                    }
                    if (findX == x && findX != x && findY != y)
                    {
                        Console.WriteLine("You have found the X axis of the battleship/s: " + findX + "\n");
                    }
                    if (findY == y && findX != x && findY != y)
                    {
                        Console.WriteLine("You have found the Y axis of the battleship/s: " + findY + "\n");
                    }
                    else
                    {
                        Console.WriteLine("You haven't found a batteship");
                        return;
                    }
                }
            }
        }

        #endregion Result
    }
}