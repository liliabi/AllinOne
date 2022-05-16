using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Business.Algorithm
{
    public class SPC
    {
        /// <summary>
        /// 随机初始化数组
        /// </summary>
        /// <param name="len">数组长度</param>
        /// <returns>返回指定长度的数组</returns>
        public static List<int> InitArr(int len)
        {
            List<int> arrlist = new List<int>();

            Random r = new Random();
            for (int i = 1; i < len; i++)
            {
                int sum = r.Next(-100, 101);
                arrlist.Add(sum);
            }
            return arrlist;
        }

        /// <summary>
        /// 1个落点在区间以外
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="UCL">上边界</param>
        /// <param name="LCL">下边界</param>
        /// <returns></returns>
        public static List<int> PointOutOfArea(List<int> sourcelist, int UCL, int LCL)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < sourcelist.Count; i++)
            {
                if (sourcelist[i] > UCL || sourcelist[i] < LCL)
                {
                    list.Add(i);
                }
            }
            return list;
        }


        /// <summary>
        /// 连续N个落点在中心线的同一侧
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="centreline">中心线值</param>
        /// <param name="continueN">连续N个落点</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNcheck(List<int> sourcelist, int centreline, int continueN)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < sourcelist.Count - continueN; i++)
            {
                bool flag = true;
                if (sourcelist[i] > centreline)
                {
                    for (int j = i; j < i + continueN; j++)
                    {
                        if (sourcelist[j] < centreline)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = i; j < i + continueN; j++)
                    {
                        if (sourcelist[j] > centreline)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        /// <summary>
        /// 连续N个落点递增或递减
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="continueN">连续N个落点</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNIncOrDim(List<int> sourcelist, int continueN)
        {
            int actual_continue = continueN - 1;
            List<int> list = new List<int>();
            for (int i = 0; i < sourcelist.Count - actual_continue; i++)
            {
                bool flag = true;
                int tmp = sourcelist[i + 1] - sourcelist[i];
                if (tmp == 0)
                {
                    continue;
                }
                if (tmp > 0)//递增
                {
                    for (int j = i; j < i + actual_continue; j++)
                    {
                        if (sourcelist[j] < sourcelist[j + 1])
                        {
                            continue;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (tmp < 0)//递减
                {
                    for (int j = i; j < i + actual_continue; j++)
                    {
                        if (sourcelist[j] > sourcelist[j + 1])
                        {
                            continue;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        /// <summary>
        /// 连续N个落点中相邻点交替上线
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="continueN">连续N个落点</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNAlternate(List<int> sourcelist, int continueN)
        {
            int actual_continue = continueN - 1;
            List<int> list = new List<int>();
            for (int i = 0; i < sourcelist.Count - actual_continue; i++)
            {
                int tmp = sourcelist[i + 1] - sourcelist[i];
                if (tmp == 0)
                {
                    continue;
                }
                bool AddFlag = true;
                bool UpDownFlag = tmp > 0 ? true : false;
                for (int j = i + 1; j < i + actual_continue; j++)
                {
                    if (tmp == 0)
                    {
                        break;
                    }
                    else if (tmp > 0)
                    {
                        if (sourcelist[j + 1] < sourcelist[j])
                        {
                            UpDownFlag = !UpDownFlag;
                        }
                        else
                        {
                            AddFlag = false;
                            break;
                        }
                    }
                    else if (tmp < 0)
                    {
                        if (sourcelist[j + 1] > sourcelist[j])
                        {
                            UpDownFlag = !UpDownFlag;
                        }
                        else
                        {
                            AddFlag = false;
                            break;
                        }
                    }
                    tmp = sourcelist[j + 1] - sourcelist[j];
                }
                if (AddFlag)
                {
                    list.Add(i);
                }
            }
            return list;
        }
    }
}
