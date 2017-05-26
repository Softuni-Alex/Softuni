﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GenericMethod
{
    class GenericMethod
    {

        class GenericArraySort
        {
            static void Main()
            {
                // input
                CultureInfo invC = CultureInfo.InvariantCulture;
                int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
                string[] strings = { "zaz", "cba", "baa", "azis" };
                DateTime[] dates =
                {
            new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1),
        };

                // printing
                Console.WriteLine(SortArray(numbers));
                Console.WriteLine(SortArray(strings));
                Console.WriteLine(SortArray(dates));
            }

            private static string SortArray<T>(IEnumerable<T> inputArr)
            {
                List<T> tempList = inputArr.ToList();
                List<T> sorted = new List<T>();

                while (tempList.Count != 0)
                {
                    var x = tempList.Min();
                    sorted.Add(x);
                    tempList.Remove(x);
                }
                return PrintArray(sorted);
            }

            private static string PrintArray<T>(IEnumerable<T> array)
            {
                return string.Join(", ", array);
            }
        }
    }
