using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson22B
{
    class Program
    {
        static void Main(string[] args)
        {
            #region reminder of how basic array functions
            //reminding of how old sets work
            int[] mySet = new int[5];
            mySet[0] = 1;
            mySet[1] = 10;
            mySet[2] = 15;
            //non initialized int[] has a value of 0
            mySet[4] = 50;

            int[,] my2DSet = new int[3, 2];
            my2DSet[0, 0] = 19;
            my2DSet[0, 1] = 50;
            my2DSet[1, 0] = 100;

            //reference types such as class objects are pointers and copying pointers does not create a separate copy
            Person[] persons = new Person[3];
            persons[0] = new Person("Einat");
            //non initialized class objects have a value of "null"
            persons[2] = new Person("Erez");
            #endregion

            //  some types of built in collections:
            //Array List - A list with a working array "behind the curtain"
            //HashTable - A list with a key(i.e. hashcode) and value, each key can have only one value
            //              values can have multiple keys (useful for user/password data)
            //SortedList - A list with faster searching for specific values.
            //Queue - First in, first out.             
            //Stack - First in, last out.

            //Generic (all values has to be of the same type) collection classes:
            //Dictionary
            //List
            //Queue
            //SortedList
            //Stack

            #region ArrayList
            //arraylist is non-generic, and any type could be added to it.
            ArrayList myList = new ArrayList(); 
            myList.Add(1);
            myList.Add("hello world");
            myList.Add(new DateTime(2016, 9, 6));
            // sort will not work in this instance because the objects in myList are of different types.
            myList.Clear();
            myList.Add(new Person("Roi"));
            myList.Add(new Person("Einat"));
            myList.Add(new Person("Erez"));
            myList.Sort();

            //var is defined by the value type it's initialized by.
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            int indexFound = myList.BinarySearch(new Person("Roi"));
            Console.WriteLine("found at: " + indexFound);
            Console.WriteLine();
            #endregion

            #region HashTable
            Hashtable myHashtable = new Hashtable();
            //Each element in a hashtable has 2 objects - key and value.
            //Hashtable is non-generic and  both key and value can be of any type.
            myHashtable.Add(1, "one");
            myHashtable.Add("2", "two");
            myHashtable.Add(3, "Three");
            //warning: a null value can be mistaken for a null element (both key and value are nulls) in a hashtable object.
            myHashtable.Add(4, null); 
            Console.WriteLine(myHashtable["2"]);
            Console.WriteLine();
            #endregion

            //SortedList: elements added to sortedlist already come indexed.

            #region Queue
            //first in, first out
            Queue q = new Queue();
            q.Enqueue("first");
            q.Enqueue("second");
            q.Enqueue("third");

            while (q.Count > 0)
            {
                Console.WriteLine(q.Dequeue());
            }
            #endregion            

            #region Stack
            Stack myStack = new Stack();
            myStack.Push("First");
            myStack.Push("Second");
            myStack.Push("Third");
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }
            #endregion

        }
    }

    class Person : IComparable
    {
        public string name { get; set; }

        public Person()
        { }

        public Person(string name)
        {
            this.name = name;
        }

        public int CompareTo(object obj)
        {
            return name.CompareTo((obj as Person).name);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
