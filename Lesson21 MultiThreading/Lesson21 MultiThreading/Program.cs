using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson21
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] nums = new int[1000000];
            nums[1000] = 51;
            nums[700000] = 102;
            Console.WriteLine(max(nums));
        }

        static int stam(ref int res)
        {
            int x = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                if (i % 2 == 0)
                    x++;
                res = x;
            }
            Console.WriteLine("done in stam()");
            return x;
        }

        static int maxInDomain(int[] nums, int from, int to)
        {
            int max = nums[from];
            for (int i = from; i < to; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
            }
            return max;
        }

        static int max(int[] nums)
        {
            int max1 = 0;
            int max2 = 0;
            Thread t1 = new Thread(() => max1 = maxInDomain(nums, 0, nums.Length / 2));
            Thread t2 = new Thread(() => max2 = maxInDomain(nums, nums.Length / 2, nums.Length));
            t1.Start();
            t2.Start();
            //.Join() stops the current thread(main in this case)until t1 terminates.
            t1.Join();
            t2.Join();

            return max1 > max2 ? max1 : max2;
        }
    }
}
