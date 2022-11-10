using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Algorithm.Sort
{
    internal class SortFast
    {
        public static void Demo()
        {
            int[] nums = new int[10000000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Random rd = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                
                nums[i]= rd.Next(1000,9999);
            }
            sw.Stop();
            Console.WriteLine("{0}个初始化耗时：{1}",nums.Length,sw.Elapsed);
            //PrintArray(nums, "快速排序前:");
            sw.Restart();
            QuickSort(nums, 0, nums.Length - 1);
            sw.Stop();
            Console.WriteLine("{0}个排序耗时：{1}", nums.Length, sw.Elapsed);
            //PrintArray(nums, "快速排序后:");
        }
        public static void QuickSort(int[] nums, int start, int end)
        {
            if (start > end) return;
            int i, j,baseNum;
            i = start;
            j = end;
            baseNum = nums[start];
            while (i < j)
            {
                while (i < j && nums[j] >= baseNum) j--;
                while (i < j && nums[i] <= baseNum) i++;
                if (i < j)
                {
                    Swap(nums, i, j);
                }
            }
            Swap(nums, start, i);
            QuickSort(nums, start, j - 1);
            QuickSort(nums, j + 1, end);
        }
        public static void Swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }

        public static void PrintArray(int[] nums,string message)
        {
            Console.WriteLine();
            Console.Write(message);
            foreach (int item in nums)
            {
                Console.Write(item + " ");
            }
        }
    }
}
