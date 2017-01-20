using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced5
{
    //trying to use arrays without the problem of the size limit
    //note: in c sharp pointers are named as references    
    class Car
    {
        public int Year;

        public void Honk()
        {
            Console.WriteLine(Year < 1990 ? "pap pap" : "beep");
        }
    }

    class MathExercise
    {
        public int remainder;

        public int quotient;

        public int Remainder(int x, int y)
        {
            Quotient(x, y);
            return remainder;
        }

        public int Quotient(int x, int y)
        {
            int high = x > y ? x : y;
            int low = x < y ? x : y;
            int temp = 0;
            while (temp + low < high)
            {
                temp += low;
                quotient++;
            }
            while (remainder + temp < high)
            {
                remainder++;
            }
            return quotient;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar1;
            myCar1 = new Car();
            //'new' does several things: searches a place in the memory that is
            //large enough to include the object.
            //2.tags said space as reserved so nothing will delete it.
            //3.initilizes the space. all the variables are equal 0
            //4.returns the address of the first byte of the object
            Car myCar2 = new Car();
            myCar1.Year = 2016;
            myCar2.Year = 1980;
            myCar1.Honk();

            //Class exercise:
            //write the next functions using only one mathematical operator - addition.
            //1. function that returns the distance between 2 positive ints.
            //2. function that returns their multiplication
            //3. function that show how many times the smallest int goes inside the largest
            //4. function that returns the modulus
            int y = 13;
            int x = 5;
            Console.WriteLine(distance(x, y).ToString());
            Console.WriteLine(product(x, y).ToString());
            Console.WriteLine(quotient(x, y).ToString());
            Console.WriteLine(remainder(x, y).ToString());
            Console.WriteLine("------------------");
            MathExercise temp1 = new MathExercise();
            Console.WriteLine(temp1.Quotient(x, y).ToString());
            Console.WriteLine(temp1.Remainder(x, y).ToString());            

            /*Homework: Make a class that creates a strechable array.
            class Collection
            {
                int[] arr;
                int pos;
             *  //below is a constructor
             *  public Collection()
             *  {
             *      arr = new int[100];
             *      pos = 0;
             *  }
             *  public void Add(int x)
             *  {
             *  
             *  }
             *  public int Get(int index)
             *  {
             *  
             *  }
             *  public void Remove(int index)
             *  {
             *  
             *  }
            }
             */
        }

        static int distance(int x, int y)
        {
            int high = x > y ? x : y;
            int low = x < y ? x : y;
            int result = 0;
            while (result + low < high)
            {
                result++;
            }
            return result;
        }

        static int product(int x, int y)
        {
            int high = x > y ? x : y;
            int low = x < y ? x : y;
            int result = high;
            for (int i = 0; i < low; i++)
            {
                result += high;
            }
            return result;
        }

        static int quotient(int x, int y)
        {
            int result = 0;
            int high = x > y ? x : y;
            int low = x < y ? x : y;
            int sum = low;
            while (sum <= high)
            {
                sum += low;
                result++;
            }
            return result;
        }
        static int remainder(int x, int y)
        {
            int high = x > y ? x : y;
            int low = x < y ? x : y;
            int sum = low;
            while (sum <= high)
            {
                sum += low;
            }
            return distance(high, sum);
        }
    }
}