namespace AllinOne.Algorithm.Sort
{
    internal class SortBubble
    {
        public static void DemoNormal(int[] nums)
        {
            int count = BubbleSortNormal(nums);
            System.Console.WriteLine("DemoNormal" + count);
        }

        public static void DemoImproved(int[] nums)
        {
            int count = BubbleSortImproved(nums);
            System.Console.WriteLine("DemoImproved" + count);
        }

        // 常规方法-->(最好，最坏)算法复杂度都是O(n^2)
        public static int BubbleSortNormal(int[] nums)
        {
            int count = 0; // 记录比较的次数==算法时间复杂度
            int length = nums.Length; // 数组未排序序列的长度
            do
            {
                for (int j = 0; j < length - 1; j++) // 数组未排序序列的倒第二数
                {
                    count++;
                    if (nums[j] > nums[j + 1])
                    {
                        Common.Swap(nums, j, j + 1);
                    }
                }
                length--; // 每次遍历后，就会确定一个最大值，未排序序列的长度减1
            }
            while (length > 1); // 当数组未排序序列只剩最后一个数时，就不需要排序了
            return count;
        }

        // 优化方法
        public static int BubbleSortImproved(int[] arr)
        {
            int count = 0; // 记录比较的次数==算法时间复杂度
            bool swaped; // 判断一次遍历中是否有交换
            int length = arr.Length; // 数组未排序序列的长度
            do
            {
                swaped = false; // 每次遍历都初始化没有交换
                for (int j = 0; j < length - 1; j++) // 数组未排序序列的倒第二数
                {
                    
                    if (arr[j] > arr[j + 1])
                    {
                        count++;
                        Common.Swap(arr, j, j + 1);
                        swaped = true;
                    }
                }
                length--; // 每次遍历后，就会确定一个最大值，未排序序列的长度减1
            }
            while (length > 1 && swaped); // 当数组未排序序列只剩最后一个数或者遍历过程中没有交换任何相邻元素时，就不需要排序了
            return count;
        }

    }
}
