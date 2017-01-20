using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson5
{
    // A collection is a custom class that holds ints
    // similiar to array but does not have a limit.
    class Collection
    {
        int[] nums;
        int pos;

        // Note: Default constructor - a constructer that gets no parameters.
        public Collection() : this(10) { }

        public Collection(int size)
        {
            nums = new int[size];
            pos = 0;
        }

        public void Add(int number)
        {
            makeRoom();
            nums[pos++] = number;
        }

        void makeRoom()
        {
            if (pos == nums.Length) //no room
            {
                int[] temp = new int[nums.Length * 2];
                for (int i = 0; i < pos; i++)
                {
                    temp[i] = nums[i];
                }
                nums = temp;
            }
        }

        // Checks if an index is valid
        void checkIndex(int index)
        {
            if (index >= pos || index < 0)
            {
                throw new Exception("Index out of bounds");
            }
        }

        // Returns a num in the index position
        public int Get(int index)
        {
            checkIndex(index);

            return nums[index];
        }

        public void Remove(int index)
        {
            checkIndex(index);

            for (int i = index; i < pos; i++)
                nums[i] = nums[i + 1]; ;

            pos--;
        }

        public int Size()
        {
            return pos;
        }

        public int[] ToArray()
        {
            int[] temp = new int[pos];
            for (int i = 0; i < pos; i++)
            {
                temp[i] = nums[i];
            }
            return temp;
        }

        public int IndexOf(int number)
        {
            for (int i = 0; i < pos; i++)
            {
                if (nums[i] == number)
                    return i;
            }
            return -1;
        }

        public void Insert(int number, int index)
        {
            checkIndex(index);
            makeRoom();
            for (int i = pos; i > index; i--)
            {
                nums[i] = nums[i - 1];
            }
            nums[index] = number;
            pos++;
        }

        public void Set(int number, int index)
        {
            checkIndex(index);
            nums[index] = number;
        }
        //homework: the below functions returns true if the other
        // collection values equal to this one.
        public bool Equals(Collection other)
        {
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int q = Quotient(7, 0);
                Console.WriteLine("q=" + q);
            }
            catch (Exception ex)
            {
                Console.WriteLine("boom! " + ex.Message);
            }
            Collection myCol1 = new Collection();
            for (int i = 0; i < 9; i++)
            {
                myCol1.Add(i * 3);
                Console.WriteLine(myCol1.Get(i));
            }
            myCol1.Insert(-1, 8);
            Console.WriteLine("-------------------");
            for (int i = 0; i < myCol1.Size(); i++)
            {
                Console.WriteLine(myCol1.Get(i));
            }

            Console.WriteLine("Done");
            Console.ReadKey();

        }

        static int Quotient(int x, int y)
        {
            // Note: "Exception" is a reserved class in c sharp (all c sharp programs will have exception).
            // it is often used as reference to other programmers when they use your functions.
            if (y == 0)
            {
                throw new Exception("division by zero");
            }
            int sum = y;
            int result = 0;
            while (sum <= x)
            {
                result++;
                sum += y;
            }
            return result++;
        }
    }
}