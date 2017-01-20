using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 19;            
            float distance = 3.4f;
            long bigNumber = 1231231241234L;
            string firstName = "Elad";
            decimal d = 3.4M;


            int[] grades = { 12, 35, 34, 99, 100, 23 };
            int[] grades2 = { 35, 34, 99 };
            int[] arr = new int[10];


            int[] check1 = { 4, 6, 8, 8, 13 };
            int[] check2 = { 8, 13 };

            Console.WriteLine(FindSeries(check1, check2));

            PrintArray(grades);
            PrintLargest(grades);
            PrintAvarage(grades);
            FindMinMaxSeries(grades, 13, 120);

            Console.ReadLine();
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            if (arr.Length > 0)
                Console.WriteLine(arr[arr.Length - 1] + ".");
        }

        static int PrintLargest(int[] arr)
        {
            //assume nums has at least one number.
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            Console.WriteLine(max);
            return max;
        }

        static float PrintAvarage(int[] arr)
        {
            float sum = 0;
            float num;
            for (int i = 0; i < arr.Length; i++)
            {
                num = arr[i];
                sum += arr[i];
            }
            float result = sum / arr.Length;
            Console.WriteLine(result);
            return result;
        }

        static bool FindSeries(int[] arr1, int[] arr2)
        {
            bool result = true;
            for (int i = 0; i < arr1.Length - arr2.Length + 1; i++)
            {
                result = true;
                if (arr2[0] == arr1[i])
                {
                    for (int j = 1; j < arr2.Length; j++)
                    {
                        if (arr1[i + j] != arr2[j])
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result)
                        return result;
                }
            }
            return false;
        }

        static int[] FindMinMaxSeries(int[] arr, int min, int max)
        {
            int maxNum = 0;
            int[] temp = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < max && arr[i] > min)
                    maxNum++;

            int[] result = new int[maxNum];
            int position = 0;
            for (int i = 0; i < result.Length; i++)
                if (arr[i] < max && arr[i] > min)
                    result[position] = arr[i];

            PrintArray(temp);
            PrintArray(result);
            return result;
        }
    }
}