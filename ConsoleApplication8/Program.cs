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

            Console.WriteLine("Enter count of bombs:");
            int bombCount = Convert.ToInt32(Console.ReadLine());


            FillArray(array, bombCount);
            //todo заполнить массив бомбами и цифрами
            ArrangeMines(array, bombCount);
            //бесконечный ввод i j


            PaintArray(array);
            do
            {
                InputCell(array);
                PaintArray(array);

            } while (true);
           // Console.ReadLine();
        }

       

        public static void ArrangeMines(Cell[,] array, int bombCount)
        {
            Random random = new Random();

            for (int k = 0; k < bombCount; k++)
            {
                int l = random.Next(array.GetLength(0));
                int m = random.Next(array.GetLength(1));

                array[l, m].Value = 9;
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

        public static void InputCell(Cell[,] array)
        {

            Console.WriteLine("The game started");
            int i = Convert.ToInt32(Console.ReadLine());
            int j = Convert.ToInt32(Console.ReadLine());

            if (i >= array.Length || j >= array.Length || i < 0 || j < 0)
            {
                Console.WriteLine("Wrong indexes");
            }
            else
            {
                array[i, j].IsOpen = true;
            }



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











