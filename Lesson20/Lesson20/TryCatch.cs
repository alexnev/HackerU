using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepetionHandling
{
    class Program
    {
        //building your own exception classes
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(divide(8, 2));

                return;
            }
            //you can use multiple catches with similiar logic to "if else"
            catch (DivisionByZeroException ex)
            {
                Console.WriteLine("oops " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("oops " + ex.Message);
            }
            //finally activates even if you have a return command.
            //used to remind to do full closure to objects that demand cleaning 
            finally
            {
                Console.WriteLine("Finally");

                Console.ReadKey();
            }
            Console.WriteLine("Done");

            Console.ReadKey();
        }

        static float divide(float x, float y)
        {
            if (y == 0)
                throw new DivisionByZeroException();
            return x / y;
        }
    }

    class DivisionByZeroException : Exception
    {
        DateTime exceptionTimeStamp;
        public DivisionByZeroException() : base("division by zero")
        {
            exceptionTimeStamp = DateTime.Now;
        }
    }
}