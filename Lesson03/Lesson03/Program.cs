using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson3
{
    class Program
    {
        //Homework: Write a function that gets an array of chars and 
        //parameter called delemeter(char). The function returns 
        //an array of arrays which containt the words.
        //The function will be named split.

        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 1, 3, 4 };

            PrintArray(arr);
            mergeSort(arr, 0, arr.Length - 1);
            PrintArray(arr);

            int[][] arr2 = new int[5][];
            arr2[0] = new int[3];

            Console.ReadLine();
        }

        static void PrintArray(int[] arr)
        {
            foreach (int number in arr)
                Console.Write(number + ", ");
            Console.WriteLine();
        }

        static void BubbleSort(int[] arr)
        {
            int temp = arr[0];
            bool changedPlace = false;
            do
            {
                changedPlace = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        changedPlace = true;
                    }
                }
            }
            while (changedPlace);
        }

        static int partition(int[] nums, int low, int high)
        {
            int pivot = nums[high];
            int i = low - 1;
            int temp;
            for (int j = low; j < high; j++)
            {
                if (nums[j] <= pivot)
                {
                    i++;
                    temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
            temp = nums[i + 1];
            nums[i + 1] = nums[high];
            nums[high] = temp;
            return i + 1;
        }

        static void quickSort(int[] nums, int low, int high)
        {
            if (low < high)
            {
                int p = partition(nums, low, high);
                quickSort(nums, low, p - 1);
                quickSort(nums, p + 1, high);
            }
        }

        static void merge(int[] nums, int l, int m, int r)
        {
            int[] left = new int[m - l + 1];
            int[] right = new int[r - m];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = nums[l + i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = nums[m + 1 + i];
            }
            int indexLeft = 0;
            int indexRight = 0;
            int k = l;
            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] <= right[indexRight])
                {
                    nums[k] = left[indexLeft];
                    indexLeft++;
                }
                else
                {
                    nums[k] = right[indexRight];
                    indexRight++;
                }
                k++;
            }

            while (indexLeft < left.Length)
            {
                nums[k] = left[indexLeft];
                indexLeft++;
                k++;
            }

            while (indexRight < right.Length)
            {
                nums[k] = right[indexRight];
                indexRight++;
                k++;
            }
        }

        static void mergeSort(int[] nums, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                mergeSort(nums, l, m);
                mergeSort(nums, m + 1, r);
                merge(nums, l, m, r);
            }
        }
    }
}