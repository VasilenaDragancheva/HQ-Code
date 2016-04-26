namespace Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Assertions
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        public static void Main()
        {
            int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            // preconditions
            Debug.Assert(arr.Length > 0, "No collections is given ");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) where T : IComparable<T>
        {
            // preconditions
            Debug.Assert(arr.Length > 0, "No collections is given ");
            Debug.Assert(IsSortedArray(arr), "Array shoudl be sorted for binary search");
            Debug.Assert(startIndex > 0, "Start index should be non negative");
            Debug.Assert(endIndex > startIndex, "End index should be greater than start index");
            Debug.Assert(endIndex < arr.Length - 1, "End index should be less than size of collection");

            int foundIndex = -1;
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    while (midIndex >= startIndex && arr[midIndex].Equals(value))
                    {
                        midIndex--;
                    }

                    foundIndex = midIndex;
                    break;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // postconditions
            Debug.Assert(arr[foundIndex].Equals(value), "Value on found index is not equal to the wanted");
            Debug.Assert(
                foundIndex >= startIndex && foundIndex <= endIndex, 
                "Index is not in give range of start and end index");

            return foundIndex;
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) where T : IComparable<T>
        {
            // preconditions
            Debug.Assert(arr.Length > 0, "No collections is given ");
            Debug.Assert(startIndex >= 0, "Start index should be non negative");
            Debug.Assert(endIndex > startIndex, "End index should be greater than start index");
            Debug.Assert(endIndex < arr.Length - 1, "End index should be less than size of collection");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            // postconditions
            Debug.Assert(
                minElementIndex >= startIndex && minElementIndex <= endIndex, 
                "Find index is not in range of start and end index ");

            return minElementIndex;
        }

        private static bool IsSortedArray<T>(T[] arr)
        {
            T[] copiedArray = new List<T>(arr).ToArray();
            Array.Sort(copiedArray);
            for (int i = 0; i < copiedArray.Length; i++)
            {
                if (!copiedArray[i].Equals(arr[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}