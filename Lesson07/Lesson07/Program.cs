using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07
{

    class Collection
    {
        Link anchor;
        Link last;

        public Collection()
        {
            anchor = new Link(0);
            last = anchor;
        }

        public void Add(int number)
        {
            while (last.next != null)
            {
                last = last.next;
            }
            last.next = new Link(number);
            last = last.next;
        }

        public int Get(int index)
        {
            Link current = this.anchor.next;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            if (current == null)
                return -1;
            return current.value;

            //Teacher solution:

            //int  counter = -1;
            //Link link = anchor;
            //while (link.next != null && counter < index)
            //    {
            //    link = link.next;
            //    counter++;
            //    }
            //if (counter == index)
            //    return link.value;
            //else
            //    throw new Exception("index out of bounds!");
        }

        public void Remove(int index)
        {
            Link current = this.anchor.next;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }
            if (current.next == null || current == null)
                return;
            if (current.next == last)
            {
                last = current;
            }
            else
            {
                current.next = current.next.next;
            }
        }

        public int Size()
        {
            Link current = this.anchor.next;
            int size = 0;
            while (current.next != null)
            {
                current = current.next;
                size++;
            }
            return size;
        }

        public int IndexOf(int number)
        {
            Link current = this.anchor.next;
            int index = 0;
            while (current.next != null)
            {
                if (current.value == number)
                    return index;
                index++;
                current = current.next;
            }
            return -1;
        }

        public void Insert(int number, int index)
        {
            Link current = this.anchor.next;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }
            if (current == null)
                return;
            if (current.next == last)
            {
                this.Add(number);
            }
            Link temp = current.next;
            current.next = new Link(number);
            current.next.next = temp;

        }

        public void Set(int number, int index)
        {
            Link current = this.anchor.next;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            if (current == null)
                return;
            current.value = number;
        }

        public bool Equals(Collection other)
        {
            Link current = this.anchor.next;
            Link currentOther = other.anchor;
            while (current.next != null && currentOther.next != null)
            {
                if (current.value != currentOther.value)
                    return false;
                current = current.next;
                currentOther = currentOther.next;
            }
            if (current.next != null || currentOther.next != null)
                return false;
            return true;
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


    class Program
    {
        static void Main(string[] args)
        {

            Collection col1 = new Collection();
            col1.Add(3);
            col1.Add(4);
            col1.Add(6);
            col1.Add(7);
            col1.Add(12);
            col1.Add(8);

            Collection col2 = new Collection();
            col2.Add(3);
            col2.Add(4);
            col2.Add(6);
            col2.Add(7);
            col2.Add(12);
            col2.Add(8);

            Console.WriteLine(col1.Equals(col2));
            Console.WriteLine(col1.Get(6));
            col1.Remove(6);
            Console.WriteLine(col1.Get(4));
            Console.WriteLine(col1.Size());
            Console.WriteLine(col1.IndexOf(6));
            col1.Insert(200, 3);
            Console.WriteLine(col1.Get(3));
            Console.WriteLine(col1.Get(4));
            Console.ReadKey();
        }
    }
}