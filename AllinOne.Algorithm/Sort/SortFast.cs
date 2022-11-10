using System;

namespace AllinOne.Algorithm.Sort
{
    internal class SortFast
    {
        public static void Demo(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);
        }
        public static void QuickSort(int[] nums, int start, int end)
        {
            if (start > end) return;
            int i, j, baseNum;
            i = start;
            j = end;
            baseNum = nums[start];
            while (i < j)
            {
                while (i < j && nums[j] >= baseNum) j--;
                while (i < j && nums[i] <= baseNum) i++;
                if (i < j)
                {
                    Common.Swap(nums, i, j);
                }
            }
            Common.Swap(nums, start, i);
            QuickSort(nums, start, j - 1);
            QuickSort(nums, j + 1, end);
        }


        public static void PrintArray(int[] nums, string message)
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
