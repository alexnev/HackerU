using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    // same access rules of class apply to interface. public/private etc. work the same way
    interface IEdible
    {
        //This is a method signature
        void eat();
        //int calories { get; set; }
    }

    interface IDrinkable
    {
        void drink();
    }

    class Food
    {

    }

    //Inheritence: Classes can inherit only from one class, but can inherit infinite number of interfaces.
    //In the inheritence syntax the father class have to come before interfaces
    //Note: Like regular methods, the son class inherits all the interface methods of the father class

    class Sandwitch : Food, IEdible, IDrinkable
    {
        public void eat()
        {

        }

        public void drink()
        {

        }

        //public calories { get; set; }
    }

    //Warning: There is already a built in IComparable interface
    interface IComparable
    {
        bool compare(Object o);
    }

    class Point : IComparable
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double distanceFromOrigin()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public bool compare(Object o)
        {
            if (o == null)
                return false;
            if (o is Point)
            {
                Point other = (Point)o;
                double d1 = this.distanceFromOrigin();
                double d2 = other.distanceFromOrigin();

                if (d1 > d2)
                    return true;
                else if (d1 == d2)
                {
                    if (this.y < 0)
                    {
                        if (other.y < 0)
                            return this.x > other.x;
                        else // other.y > 0
                            return true;
                    }
                    else // this.y > 0
                    {
                        if (other.y < 0)
                            return false;
                        else
                            return this.x < other.x;

                    }
                }
                else // d1 < d2
                    return false;

            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEdible e = new Sandwitch();
        }

        static void BubbleSort(IComparable[] nums)
        {
            bool isSorted = false;
            int upToPosition = nums.Length - 1;
            while (!isSorted)
            {
                isSorted = false;
                for (int i = 0; i < upToPosition; i++)
                {
                    if (nums[i].compare(nums[i + 1]))
                    {
                        IComparable temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                        isSorted = true;
                    }
                }
                upToPosition--;
            }
        }
    }
}