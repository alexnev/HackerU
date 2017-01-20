using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14
{
    //Notes:
    //"value" is a protecected word and it's recommended not to use it as a name for any variable, method etc.
    //Assume MyList is similiar to the collection class that we created in previous lessons - an array without pre-determined limits
    //MyList will have all other fuctions of the collection: add() remove() compare() etc.
    class MyList
    {
        private string[] items;

        public MyList()
        {
            items = new string[10];
        }
        //  Example of indexed properties
        //  An indexer is a member that enables objects to be indexed in the same way as an array.
        //An indexer is declared like a property except that the name of the member 
        //is 'this' followed by a parameter list written between the [] brackets.
        public string this[int index]
        {
            get
            {
                // returns the string in the indexed position
                return items[index];
            }
            set
            {
                //the protected word "value" points to the value after '='
                items[index] = value;
            }
        }         
    }

    class Animal
    {

    }

    class Dog : Animal
    {

    }

    //Generics
    //The generic keyword name doesn't have to be the letter "T"
    //There are also generic methods, but they are much less frequently used
    class Kayak<T>
    {
        T front;
        T rear;

        public Kayak(T front, T rear)
        {
            this.front = front;
            this.rear = rear;
        }

        public T getRear()
        {
            return rear;
        }
        public T getFront()
        {
            return front;
        }
    }

    //Solution for previous homework - create a stack using class but without using arrays

    class MyStack<T>
    {
        private Link head;

        public void push(T val)
        {
            Link l = new Link(val);
            l.next = head;
            head = l;
        }

        public T pop()
        {
            //'default' keyword returns '0' or null depending on the type given.
            if (head == null)
                return default(T);

            T val = head.val;
            head = head.next;
            return val;
        }

        class Link
        {
            public T val;
            public Link next;

            public Link(T val)
            {
                this.val = val;
            }
        }
    }

    class Program
    {
        //Reference
        //ref keyword need to be in the function and in the activation.
        static void Add(ref int x)
        {
            x++;
        }

        static void Main(string[] args)
        {

            MyList myList = new MyList();
            myList[3] = "hello";
            Console.WriteLine(myList[3]);

            Kayak<int> myKayak = new Kayak<int>(5, 8);

            int x = 5;
            Add(ref x);
            Console.WriteLine(x);
            Console.WriteLine();

            MyStack<string> myStak = new MyStack<string>();
            myStak.push("hello");
            myStak.push("how");
            myStak.push("are");
            myStak.push("you?");
            string s;
            while ((s = myStak.pop()) != null)
            {
                Console.WriteLine(s);
            }

            Animal a1 = new Animal();
            Dog d1 = new Dog();
            //typeof checks
            //note: it is possible to cast arrays. e.g. "Animal[] animal2 = dogs;", but only upcasting, downcasting require casting each item individually
            //note: Unlike in primitive values casting (e.g. (short)int x = 1234000) downcasting an object does NOT change it's properties)

            //is keyword: a boolean query that checks if 'a1' is of the class dog
            if (a1 is Dog)
            {
                Dog d4 = (Dog)a1;
            }
            //as keyword: first does 'a1 is dog' and if false, 'd5' will be null. If true 'd5' will be 'a1' with the class dog.
            Dog d5 = a1 as Dog;
            if (d5 != null)
            {

            }
        }
    }
}