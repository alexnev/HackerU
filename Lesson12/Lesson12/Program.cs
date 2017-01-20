using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    class Program
    {
        //Note:In objective C (apple language) you have to name the parameters getting into the function.

        // Showing the use of default parameter names, in this case rectarea uses the default length of 0 and the width 34.3
        // When using defaults, be careful not to have no defaults at the end.
        static void Main(string[] args)
        {
            double a = rectArea(width: 34.3);
            Console.WriteLine(a);

            Dog d = new Dog();
            d.name = "yakub";

        }

        static double rectArea(double length = 0, double width = 0)
        {
            return length * width;
        }

        static double rectArea2(double diagonalLength, double angle)
        {
            return 0;
        }
    }

    //Property Examples
    class Dog
    {
        //Note: There is a convention to name private variables or fields with an underscore.
        string _name;

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }

    /* Homework:  Binary tree which is perfectly symmetrical both in structure and value (left and right are identical)
                  Find the longest (deepest) tree in the entire vertex.
    */
}