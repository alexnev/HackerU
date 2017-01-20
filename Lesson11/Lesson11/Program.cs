using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Class Notes:
   Modifiers come before the definition of the class, struct, method etc.
   List of modifiers (access modifiers)
    - public - can be accessed by other class objects.
    - private - most limited access, can be accessed only from within the class object.
    - internal - (usually added before type and not before fields or methods)
                 when assigned to a type, accessed from within the same .Net assembly.
                 the references in the solution window are all discrete assemblies and internal types
                 cannot be accessed from other assemblies.
    - protected - can be accessed from derived classes (inherited classes)
    Non access modifiers:
    - abstract - cannot instantiate (from the word 'instance') cannot make objects out of abstract classes Used for inherited classes
    - async - works on several threads at once
    - const - cannot be modified (used only on fields)
    - event - can be subscribed from other classes
    - extern - (short for 'external') it's used in another dll, a rare modifier.
    - new - 
    - override - replaces abstract or virtual inherited methods.
    - partial - c sharp only, allows defining a class in one file and continue defining it in another file, an object created form partials behaves normally.
                Often used in graphical programs.
    - readonly - same as const, the difference is readonly does not change the value during compilation
    - sealed - makes a class uninheritable
    - static - is not part of an object, a method that belongs to the class itself, not to instantiated object from the class.
    - unsafe - allows pointing to specific, numeric, addresses. Used mostly in graphical proccessing, but rarely.
    - virtual - allows a method to be overriden.
    - volatile - a protection keyword for a variable that can be accessed by multiple threads.

    Additional Notes:
    (1) executable .net assemblies will have a main() function, while other assemblies like .dll will not have main().
    (2) static fields are saved in the class and all objects from that class will have the same value.
    (3) if a class has a non-default constructor the compiler will no longer automatically create a default one.
    (4) defining multiple methods with the same name is called 'method overload'
    (5) In java the syntax for inheritence is 'existens' instead ':'
*/
namespace Lesson11
{
    class MyClass
    {
        //fields (can be named as 'members') 
        //methods

        //properties 
        //events
        //delegates
        //nested classes
    }

    class Person
    {
        string firstName, lastName;

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetName()
        {
            return this.firstName + " " + this.lastName;
        }
    }

    // static fields are saved in the class and all objects will have the same value.
    class Student
    {
        public Student()
        {
            Student.studentCounter++;
        }
        static int studentCounter;
        public string firstName, lastName;
        public int grade;
    }

    // (1)When deciding inheritance you can ask an "is a" question
    // example: dog 'is an' animal. But animal "is NOT neccessarily a" dog.
    // (2)When ovverriding methods you can make inherited methods more accessible, but not less.
    // (3)There is a default abstract class named 'object' that all inheritence-less inherit from it.
    abstract class Animal
    {
        public void GoToSleep()
        {
            Console.WriteLine("going to sleep");
        }
        //abstrac methods can only be in abstract classes
        public abstract void Eat();
    }

    //example the use of property and inheritence.
    class Dog : Animal
    {
        string name;
        string breed;
        int birthYear;
        public int age
        {
            set { birthYear = DateTime.Now.Year - value; }
            get { return DateTime.Now.Year - birthYear; }
        }

        public void SetName(string name)
        {
            if (name.Length > 3)
                this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public void Bark()
        {
            Console.WriteLine("bfff....bfff..");
        }


        public override void Eat()
        {
            Console.WriteLine("Yum yum");
        }
    }

    //Extension methods example
    //Note: if there is a method in a class with identical name
    //      the class method will take priority.
    static class Oded
    {
        public static int square(this int num)
        {
            return num * num;
        }

        public static void sit(this Dog d)
        {
            Console.WriteLine("am sitting");
        }
    }

    class Program
    {
        //example of working methods overload
        public static double calcArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        public static double calcArea(double width, double height)
        {
            return width * height;
        }

        static void Main(string[] args)
        {
            Dog d = new Dog();
            d.SetName("yombo");

            //You can define inherited classes by their parent classes
            // this is called upcasting or implicited casting.
            //Note: Upcast can never fail and return an exception.
            Animal a = new Dog();
            //Downcasting is the same, but it has a chance to crash.
            Dog d2 = (Dog)a;

            Student student1 = new Student();
            //Student.studentCounter++;

            int num = 3;

            Console.ReadKey();
        }
    }
    //Homework: Write a function that recieves an array of ints,
    // the arrays have sub-arrays that begin from a specific
    // location and ends in another location in the original
    // array. Both original array and sub-array have at least
    // one element.
    //You can assume that not all elements are negative,
    // but some of them can be.
    //Every array has a sum.
    //Among all the sums of the sub-arrays, which one is the largest?
    //Try to make as effecient as possible.
}