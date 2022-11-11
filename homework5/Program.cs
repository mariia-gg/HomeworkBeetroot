using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_5_arrays
{
    internal class ArraySorting
    {
        public static int[] array = new int[] { 45, 56, 45, 34, 65, 23, 0, 76, 54, 7 };

        enum SortAlgorithmType { BubbleSort, SelectionSort, InsertionSort }

        enum OrderBy { Asc, Desc }

        static void Main(string[] args)
        {
            int[] unsortedArray = { 45, 56, 45, 34, 65, 23, 0, 76, 54, 7 };
            Console.WriteLine("Selection sort");
            SelectionMethod(unsortedArray);
            PrintArray(unsortedArray);
            Console.WriteLine("Bubble sort");
            BubbleSortingMethod(unsortedArray);
            PrintArray(unsortedArray);
            Console.WriteLine("Insertion  sort");
            InsertionMethod(unsortedArray);
            PrintArray(unsortedArray);

            Console.WriteLine();
            Console.WriteLine("Bubble sort order by Asc:");
            Sort(array, SortAlgorithmType.BubbleSort, OrderBy.Asc);
            Console.WriteLine();

            Console.WriteLine("Selection sort order by Asc:");
            Sort(array, SortAlgorithmType.SelectionSort, OrderBy.Asc);
            Console.WriteLine();

            Console.WriteLine("Insertion sort order by Asc:");
            Sort(array, SortAlgorithmType.InsertionSort, OrderBy.Asc);

            Console.ReadKey();
        }

        static void PrintArray(int[] unsortedArray)
        {
            int n = unsortedArray.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(unsortedArray[i] + " ");
            Console.WriteLine();
        }

        private static void BubbleSortingMethod(int[] unsortedArray)
        {
            int array = unsortedArray.Length;
            for (int i = 0; i < array - 1; i++)
            {
                {
                    for (int j = i + 1; j < array - i - 1; j++)
                    {
                        if (unsortedArray[j] > unsortedArray[i + 1])
                        {
                            int comparison = unsortedArray[j];
                            unsortedArray[j] = unsortedArray[j + 1];
                            unsortedArray[j + 1] = comparison;
                        }
                    }
                }
            }
        }

        private static void InsertionMethod(int[] unsortedArray)
        {
            int array = unsortedArray.Length;
            for (int i = 1; i < array; i++)
            {
                int comparison = unsortedArray[i];
                int j = i - 1;
                while (j >= 0 && unsortedArray[j] > comparison)
                {
                    unsortedArray[j + 1] = unsortedArray[j];
                    j = j - 1;
                }
                unsortedArray[j + 1] = comparison;
            }
        }
        private static void SelectionMethod(int[] unsortedArray)
        {
            int array = unsortedArray.Length;

            for (int i = 0; i < array - 1; i++)
            {
                int minValue = i;
                for (int j = i + 1; j < array; j++)
                    if (unsortedArray[j] < unsortedArray[minValue])
                        minValue = j;
                int comparison = unsortedArray[minValue];
unsortedArray[minValue] = unsortedArray[i];
unsortedArray[i] = comparison;
            }
        }
        static void BubbleSortingMethod(int[] unsortedArray, OrderBy type)
{
    int[] array = PritnArray(unsortedArray);
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            if (type == 0 ? array[j] > array[j + 1] : array[j] < array[j + 1])
            {
                if (array[j] > array[j + 1])
                {
                    int comparison = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = comparison;
                }
            }
        }
    }
    Output(array);
}

static void SelectionMethod(int[] unsortedArray, OrderBy type)
{
    int[] array = PritnArray(unsortedArray);
    for (int i = 0; i < 10; i++)
    {
        int index_minimum = i;
        for (int j = i; j < 10; j++)
        {
            if (type == 0 ? array[index_minimum] > array[j] : array[index_minimum] < array[j])
            {
                if (array[index_minimum] > array[j])
                {
                    index_minimum = j;
                }
            }
        }
        int comparison = array[i];
        array[i] = array[index_minimum];
        array[index_minimum] = comparison;
    }
    Output(array);
}

static void InsertionMethod(int[] unsortedArray, OrderBy type)
{
    int[] array = PritnArray(unsortedArray);
    for (int i = 1; i < 10; i++)
    {
        int k = i;
        if (type == 0 ? array[k] < array[k - 1] : array[k] > array[k - 1])
        {
            if (array[i] < array[i - 1])
            {
                while (array[k] < array[k - 1])
                {
                    int comparison = array[k - 1];
                    array[k - 1] = array[k];
                    array[k] = comparison;
                    k--;
                    if (k - 1 < 0) break;
                }
            }
        }
    }
    Output(array);
}

static int[] PritnArray(int[] unsortedArray)
{
    int[] copy = new int[unsortedArray.Length];
    for (int i = 0; i < unsortedArray.Length; i++)
    {
        copy[i] = unsortedArray[i];
    }
    return copy;
}

static void Output(int[] array)
{
    Console.WriteLine($"{array[0]}, {array[1]}, {array[2]}, {array[3]}, {array[4]}, {array[5]}, {array[6]}, {array[7]}, {array[8]}, {array[9]}");
}

static void Sort(int[] unsortedArray, SortAlgorithmType sort, OrderBy type)
{
    switch (sort)
    {
        case SortAlgorithmType.BubbleSort:
            BubbleSortingMethod(unsortedArray, type);
            break;
        case SortAlgorithmType.SelectionSort:
            SelectionMethod(unsortedArray, type);
            break;
        case SortAlgorithmType.InsertionSort:
            InsertionMethod(unsortedArray, type);
            break;
    }
}

    }
}