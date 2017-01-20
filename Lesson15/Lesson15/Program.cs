using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    class Program
    {

        static void Main(string[] args)
        {
            //Parse
            //Note: The parse method is very resource intensive and it's not recommended for use unless absolutely neccessary.
            string s = "5";
            int x = 0;
            try
            {
                x = int.Parse(s);
            }
            catch
            {
                Console.WriteLine("There was an error");
            }
            Console.WriteLine(x);

            //TryParse
            //'out': The out Keyword allows to return results in the paramater field
            int y = 0;
            if (int.TryParse(s, out y))
            {
                Console.WriteLine("The value of y is " + y);
            }
            else
            {
                Console.WriteLine("Wrong string input.");
            }

            //DateTime - a struct with methods related to time            
            DateTime dt = DateTime.Parse("06:08 PM August 11");
            Console.WriteLine(dt);
            //Definition of ticks: Numeric representaion of the date. Usually began counting from 1970.
            Console.WriteLine(dt.Ticks);

            //.ToString(): This method exists on all objects and SUPPOSED to return the string of said object
            // Note: for your own custom classes it's possible and recommended to override the tostring method.
            Dog d = new Dog();
            d.name = "yombo";
            d.yearOfBirth = 100;
            Console.WriteLine(d);

            //Global methods for all objects
            Object o = new Object();
            Dog d2 = new Dog();
            //.equals() compares the addresses of 2 objects in the memory, not their values
            // string checks the values despite string being a pseudo-object
            d2.name = "yombo";
            d2.yearOfBirth = 100;
            Console.WriteLine(d.Equals(d2));

            //.GetHashCode - checks if 2 objects are different. Note - hashcode gurantees diffrence NOT equality.
            // The hashcode is much faster than .equals() hence it's useful to use it on large objects

            Console.ReadKey();
        }

        class Dog
        {
            public string name;
            public int yearOfBirth;

            public override string ToString()
            {
                return "Dog " + name;
            }

            //overriding the global .equals() method
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                if (this == obj)
                    return true;
                if (obj is Dog)
                {
                    //note: casting is neccesarry since "is" keyword just checks the object 'obj'. 'obj' is still of class object
                    Dog other = (Dog)obj;
                    return this.yearOfBirth == other.yearOfBirth
                        && this.name == other.name;
                }
                else
                    return false;
            }
        }
    }
}