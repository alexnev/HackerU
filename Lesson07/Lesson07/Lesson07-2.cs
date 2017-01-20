using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07
{
    //Collections with size

    class Collection2
    {
        Link anchor;
        Link last;
        int size;

        public Collection2()
        {
            anchor = new Link(0);
            last = anchor;
            size = 0;
        }

        public void Add(int number)
        {
            last.next = new Link(number);
            last = last.next;
            size++;
        }

        public int Get(int index)
        {
            CheckIndex(index);
            Link current = this.anchor.next;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.value;
            /* // Teacher solution:
              int  counter = -1;
              Link link = anchor;
              while(link.next != null && counter < index)
              {
                   link = link.next;
                   counter++;
              }
              if (counter == index)
                   return link.value;
              else
                   throw new Exception("index out of bounds!");
             */
        }

        void CheckIndex(int index)
        {
            if (index >= size)
                throw new Exception("index out of bounds!");
            if (size == 0)
                throw new Exception("Collection2 is empty!");
        }

        public void Remove(int index)
        {
            CheckIndex(index);
            Link current = this.anchor;
            for (int i = 0; i < index; i++)
                current = current.next;
            if (index == size - 1)
            {
                last = current;
            }
            current.next = current.next.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public int[] ToArray()
        {
            int[] arr = new int[size];
            Link current = this.anchor.next;
            for (int i = 0; i < size; i++)
            {
                arr[i] = current.value;
                current = current.next;
            }
            return arr;
        }

        public int IndexOf(int number)
        {
            Link current = this.anchor;
            int index = 0;
            while (current.next != null)
            {
                current = current.next;
                index++;
                if (current.value == number)
                    return index;
            }
            return -1;
        }

        public void Insert(int number, int index)
        {
            if (index > size)
                throw new Exception("index out of bounds!");
            if (index == size)
            {
                this.Add(number);
                return;
            }
            Link current = this.anchor;
            for (int i = 0; i < index; i++)
                current = current.next;

            Link temp = current.next;
            current.next = new Link(number);
            current.next.next = temp;
            size++;
        }

        public void Set(int number, int index)
        {
            CheckIndex(index);
            Link current = this.anchor.next;
            for (int i = 0; i < index; i++)
                current = current.next;

            if (current == null)
                return;
            current.value = number;
        }

        public void PrintCollection2()
        {
            if (size == 0)
                return;
            Link current = this.anchor;
            for (int i = 0; i < size - 1; i++)
            {
                current = current.next;
                Console.Write(current.value + ", ");
            }
            Console.WriteLine(current.next.value);
        }

        public bool Equals(Collection2 other)
        {
            if (other == null)
                return false;
            if (other == this)
                return true;
            Link current = this.anchor;
            Link currentOther = other.anchor;
            while (current.next != null && currentOther.next != null)
            {
                current = current.next;
                currentOther = currentOther.next;
                if (current.value != currentOther.value)
                    return false;
            }
            return current.next == currentOther.next;
        }

        class Link
        {
            public int value;
            public Link next;

            public Link(int value)
            {
                this.value = value;
                this.next = null;
            }
        }
    }


    class Execute
    {
        static void Main(string[] args)
        {

            Collection2 col1 = new Collection2();
            col1.Add(3);
            col1.Add(4);
            col1.Add(6);
            col1.Add(7);
            col1.Add(12);
            col1.Add(8);

            Collection2 col2 = new Collection2();
            col2.Add(3);
            col2.Add(4);
            col2.Add(6);
            col2.Add(7);
            col2.Add(12);
            col2.Add(8);

            int[] arr = col1.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].ToString() + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(col1.Equals(col2));
            Console.WriteLine(col1.Get(0));
            Console.WriteLine("Size of Collection2:" + col1.Size());
            Console.WriteLine("Index of number 6:" + col1.IndexOf(6));
            col1.Remove(5);
            Console.WriteLine("After removing the 3th member");
            col1.PrintCollection2();
            col1.Insert(200, 5);
            Console.WriteLine("After inserting 200 in index 3:");
            col1.PrintCollection2();
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}