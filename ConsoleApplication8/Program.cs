﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter size:");
            int size = Convert.ToInt32(Console.ReadLine());
            Cell[,] array = new Cell[size, size];

            int bombCount = 0;
            bool normalBombCount = false;
            do
            {

                Console.WriteLine("Enter count of bombs:");
                bombCount = Convert.ToInt32(Console.ReadLine());
                normalBombCount = bombCount <= size * size;
                if (!normalBombCount)
                {
                    Console.WriteLine("Quantity of bombs over the field size");
                }

            }
            while (!normalBombCount);


            FillArray(array, bombCount);
            ArrangeMines(array, bombCount);
            Console.WriteLine("The game started");

            PaintArray(array);

            bool gameFinished = false;
            do
            {
               gameFinished = InputCell(array);
                PaintArray(array);
             
            } while (!gameFinished);

            Console.WriteLine("The game over");
            Console.ReadLine();
        }



        public static void ArrangeMines(Cell[,] array, int bombCount)
        {
            Random random = new Random();

            for (int k = 0; k < bombCount; k++)
            {

                bool engaged = false;
                do
                {

                    int l = random.Next(array.GetLength(0));
                    int m = random.Next(array.GetLength(1));
                    engaged = array[l, m].Value == 9;
                    if (!engaged)
                    {
                        array[l, m].Value = 9;
                    }
                } while (engaged);

                /* дописать
                int l = random.Next(array.GetLength(0));
                int m = random.Next(array.GetLength(1));
                if (array[l, m].Value != 9)
                {
                    array[l, m].Value = 9;
                }
                else
                {
                    
                }*/
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int count1 = 0;
                    if (array[i, j].Value != 9)
                    {

                        if (i >= 0 && i < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                        {

                            if (array[i, j - 1].Value == 9)
                            {
                                count1++;
                            }
                        }
                        if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                        {

                            if (array[i - 1, j - 1].Value == 9)
                            {
                                count1++;
                            }
                        }
                        if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
                        {
                            if (array[i - 1, j].Value == 9)
                            {

                                count1++;
                            }
                        }
                        if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                        {
                            if (array[i - 1, j + 1].Value == 9)
                            {

                                count1++;
                            }
                        }
                        if (i >= 0 && i < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                        {
                            if (array[i, j + 1].Value == 9)
                            {

                                count1++;
                            }
                        }
                        if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                        {
                            if (array[i + 1, j + 1].Value == 9)
                            {

                                count1++;
                            }
                        }
                        if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
                        {
                            if (array[i + 1, j].Value == 9)
                            {

                                count1++;
                            }
                        }
                        if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                        {
                            if (array[i + 1, j - 1].Value == 9)
                            {

                                count1++;
                            }
                        }

                        array[i, j].Value = count1;
                    }
                }


            }
        }


        public static void FillArray(Cell[,] array, int bombCount)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new Cell(); // todo почитать что такое экземпляр класса!

                }
            }
        }

        public static bool InputCell(Cell[,] array)
        {
            bool bombInCell = false;

            Console.WriteLine("Enter indexes:");

            int i = Convert.ToInt32(Console.ReadLine());
            int j = Convert.ToInt32(Console.ReadLine());

            if (i >= array.Length || j >= array.Length || i < 0 || j < 0)
            {
                Console.WriteLine("Wrong indexes");
            }
            else
            {
                array[i, j].IsOpen = true;
                if(array[i, j].Value==9)
                {
                    bombInCell = true;
                }
            }

            return bombInCell;

        }

        public static void PaintArray(Cell[,] array)
        {
           for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].IsOpen)
                    {
                        Console.Write(" " + array[i, j].Value + " ");
                    }
                    else
                    {
                        Console.Write(" " + '*' + " ");
                    }

                }
                Console.WriteLine();
            }

        }

    }
}











