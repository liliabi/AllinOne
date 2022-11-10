using System;
using System.Diagnostics;

namespace AllinOne.Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Random rd = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rd.Next(1000, 9999);
            }
            sw.Stop();
            Console.WriteLine("{0}个初始化耗时：{1}", nums.Length, sw.Elapsed);

            int[] array1 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                array1[i] = nums[i];
            }           
            sw.Restart();
            Algorithm.Sort.SortFast.Demo(array1);
            sw.Stop();
            Console.WriteLine("SortFast{0}个排序耗时：{1}", nums.Length, sw.Elapsed);

            int[] array2 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                array2[i] = nums[i];
            }
            sw.Restart();
            Algorithm.Sort.SortBubble.DemoNormal(array2);
            sw.Stop();
            Console.WriteLine("SortBubble.DemoNormal{0}个排序耗时：{1}", nums.Length, sw.Elapsed);

            int[] array3 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                array3[i] = nums[i];
            }
            sw.Restart();
            Algorithm.Sort.SortBubble.DemoImproved(array3);
            sw.Stop();
            Console.WriteLine("SortBubble.DemoImproved{0}个排序耗时：{1}", nums.Length, sw.Elapsed);

            Console.ReadKey();
        }
    }
}
