using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Lesson notes: 
//(1) wpf(the dot net graphic interface) has graph that can show cpu usage.
//(2) Primitive variables (int, bool, double, etc.) start with value that equals 0 bits.
//Non-primitives like objects and array pointers start with the value 'null'.
//(3) Visual studio has a tool that can search all the programs for comments containing "TODO".
namespace Lesson10
{
    class Canvas
    {
        bool[,] coordinates;

        public Canvas(int size)
        {
            coordinates = new bool[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    coordinates[x, y] = false;
                }
            }
        }

        public Canvas()
        {
            int size = 50;
            coordinates = new bool[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    coordinates[x, y] = false;
                }
            }
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            for (int row = 1; row < height; row++)
            {
                coordinates[y + row, x] = true;
                coordinates[y + row, x + width] = true;
            }
            for (int column = 0; column <= width; column++)
            {
                coordinates[y + 1, x + column] = true;
                coordinates[y + height - 1, x + column] = true;
            }
        }

        public void DrawCanvas()
        {
            for (int row = 0; row < coordinates.GetLength(0); row++)
            {
                for (int column = 0; column < coordinates.GetLength(1); column++)
                {
                    Console.Write(coordinates[row, column] ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
    }

    struct Student
    {
        //Notes:
        //(1)When declaring struct or class fields it's recommended to use data that is not dependant on time or other exterior influences
        //(2)example: date of birth is better to use than age, singe age changes with time regardless of the variable in the struct
        public string firstName;
        public string lastName;
        public int year;
        public int grade;
        //(3)"public Student friend;" this is an error unlike in class where friend would be null
        //(4)Usually struct are used similiar to variables like int and rarely have methods and these methods, usually, are simple compared to classes.
    }
    struct Oded
    {
        public int x;

        public Oded(int getNumber)
        {
            x = getNumber;
        }
    }
    //Note: It's possible to give numerical numbers to the enum objects
    //Example: { TelAviv = 12, Jerusalem = 23 ...etc.}
    enum City { TelAviv, RamatGan, Jerusalem, BatYam, LfarSaba, Harish };

    class MyClass
    {
        //fields
        //methods

        //properties
        //events
        //delegates
        //nested classes
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Canvas myCanvas = new Canvas();
            //myCanvas.DrawRectangle(1,1,3,4);
            //myCanvas.DrawCanvas();

            Oded oded1, oded2;
            oded1.x = 8;
            oded2 = oded1;
            oded1.x = 9;
            Console.WriteLine(oded2.x);

            City myCity = City.BatYam;
            if (myCity == City.TelAviv) { }

            switch (myCity)
            {
                case City.TelAviv:
                    break;
                case City.BatYam:
                    break;
            }

            Console.ReadKey();
        }
    }
}