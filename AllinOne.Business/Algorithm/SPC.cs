using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Business.Algorithm
{
    //调用方法
    //try1
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));//连续随机测试
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;

    //    List<int> reslist = SPC_algorithm.PointOutOfArea(arrlist, Convert.ToInt32(tbUCL.Text), Convert.ToInt32(tbLCL.Text));
    //    listBox2.DataSource = reslist;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}

    //try2
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;
    //    List<int> reslist = SPC_algorithm.ContinueNLocalCenterOneSide(arrlist, Convert.ToInt32(tbCentreline.Text), Convert.ToInt32(tbContinueN.Text));

    //    List<string> resStrings = new List<string>();
    //    for (int i = 0; i < reslist.Count; i++)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int j = 0; j < Convert.ToInt32(tbContinueN.Text); j++)
    //        {
    //            sb.Append(arrlist[j + reslist[i]] + ";");
    //        }
    //        resStrings.Add("起始下标：" + reslist[i] + ",数据：" + sb.ToString());
    //    }
    //    listBox2.DataSource = resStrings;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}

    //try3
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));//连续随机测试
    //    //List<int> arrlist = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }; //连续递增测试
    //    //List<int> arrlist = new List<int>() { 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, 0 }; //连续递减测试
    //    //List<int> arrlist = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //连续直线测试
    //    //List<int> arrlist = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 2, 1, 0, -1, 2, 3 };//连续递增+连续递减测试
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;
    //    List<int> reslist = SPC_algorithm.ContinueNIncOrDim(arrlist, Convert.ToInt32(tbContinueN.Text));

    //    List<string> resStrings = new List<string>();
    //    for (int i = 0; i < reslist.Count; i++)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int j = 0; j < Convert.ToInt32(tbContinueN.Text); j++)
    //        {
    //            sb.Append(arrlist[j + reslist[i]] + ";");
    //        }
    //        resStrings.Add("起始下标：" + reslist[i] + ",数据：" + sb.ToString());
    //    }
    //    listBox2.DataSource = resStrings;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}

    //try4
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));//连续随机测试
    //    //List<int> arrlist = new List<int>() { 0, -1, 2, -3, 4, -5, 6, -7, 8, -9, 0 }; //连续交替测试
    //    //List<int> arrlist = new List<int>() { 0, -1, 2, -3, 4, 4, 4, -5, 6, -7, 8, -9, 0 }; //非连续交替测试
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;
    //    List<int> reslist = SPC_algorithm.ContinueNAlternate(arrlist, Convert.ToInt32(tbContinueN.Text));

    //    List<string> resStrings = new List<string>();
    //    for (int i = 0; i < reslist.Count; i++)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int j = 0; j < Convert.ToInt32(tbContinueN.Text); j++)
    //        {
    //            sb.Append(arrlist[j + reslist[i]] + ";");
    //        }
    //        resStrings.Add("起始下标：" + reslist[i] + ",数据：" + sb.ToString());
    //    }
    //    listBox2.DataSource = resStrings;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}


    //try5-6
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));//连续随机测试
    //    //List<int> arrlist = new List<int>() { 21, 22, 5, 6, -7, -8, -9, 0, -11, -12, -13, -14, 0 }; //连续递增测试
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;
    //    int continueN = Convert.ToInt32(tbContinueN.Text);
    //    List<int> reslist = SPC_algorithm.ContinueNLocalCenterInOneSideAreaX(arrlist, Convert.ToInt32(tbCentreline.Text), continueN, Convert.ToInt32(tbContains.Text), Convert.ToInt32(tbHigh_UCL.Text), Convert.ToInt32(tbLow_UCL.Text), Convert.ToInt32(tbHigh_LCL.Text), Convert.ToInt32(tbLow_LCL.Text));
    //    List<string> resStrings = new List<string>();
    //    for (int i = 0; i < reslist.Count; i++)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int j = 0; j < continueN; j++)
    //        {
    //            sb.Append(arrlist[j + reslist[i]] + ";");
    //        }
    //        resStrings.Add("起始下标：" + reslist[i] + ",数据：" + sb.ToString());
    //    }
    //    listBox2.DataSource = resStrings;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}


    //try7
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));//连续随机测试
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;
    //    int continueN = Convert.ToInt32(tbContinueN.Text);
    //    List<int> reslist = SPC_algorithm.ContinueNLocalCenterInAreaC(arrlist, continueN, Convert.ToInt32(tbUCL.Text), Convert.ToInt32(tbLCL.Text));
    //    List<string> resStrings = new List<string>();
    //    for (int i = 0; i < reslist.Count; i++)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int j = 0; j < continueN; j++)
    //        {
    //            sb.Append(arrlist[j + reslist[i]] + ";");
    //        }
    //        resStrings.Add("起始下标：" + reslist[i] + ",数据：" + sb.ToString());
    //    }
    //    listBox2.DataSource = resStrings;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}

    //try8
    //{
    //    List<int> arrlist = SPC_algorithm.InitList(Convert.ToInt32(tbInitcount.Text));//连续随机测试
    //    List<string> strings = new List<string>();
    //    for (int i = 0; i < arrlist.Count; i++)
    //    {
    //        strings.Add(i + "||" + arrlist[i]);
    //    }
    //    listBox1.DataSource = strings;
    //    int continueN = Convert.ToInt32(tbContinueN.Text);
    //    List<int> reslist = SPC_algorithm.ContinueNLocalCenterNoneOutOfC(arrlist, continueN, Convert.ToInt32(tbUCL.Text), Convert.ToInt32(tbLCL.Text));
    //    List<string> resStrings = new List<string>();
    //    for (int i = 0; i < reslist.Count; i++)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int j = 0; j < continueN; j++)
    //        {
    //            sb.Append(arrlist[j + reslist[i]] + ";");
    //        }
    //        resStrings.Add("起始下标：" + reslist[i] + ",数据：" + sb.ToString());
    //    }
    //    listBox2.DataSource = resStrings;
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show(ex.Message);
    //}
    public class SPC
    {
        /// <summary>
        /// 随机初始化数组
        /// </summary>
        /// <param name="len">数组长度</param>
        /// <returns>返回指定长度的数组</returns>
        public static List<int> InitList(int len)
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
        /// 1.1个落点在区间以外
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
        /// 2.连续N个落点在中心线的同一侧
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="centreline">中心线值</param>
        /// <param name="continueN">连续N个落点</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNLocalCenterOneSide(List<int> sourcelist, int centreline, int continueN)
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
        /// 3.连续N个落点递增或递减
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
        /// 4.连续N个落点中相邻点交替上下
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

        /// <summary>
        /// 5-6.连续M个点中有N个点落在中心线同一侧的X区以外
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="centreline">中心线值</param>
        /// <param name="continueN">连续M个落点</param>
        /// <param name="contains">包含有N个落点</param>
        /// <param name="lineX_High">X区高点值</param>
        /// <param name="lineX_Low">X区低点值</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNLocalCenterInOneSideAreaX(List<int> sourcelist, int centreline, int continueN, int contains, int lineX_High_UCL, int lineX_Low_UCL, int lineX_High_LCL, int lineX_Low_LCL)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < sourcelist.Count - continueN; i++)
            {
                bool flag = true;
                int count = 0;
                //判断是否在中心线同一侧
                if (sourcelist[i] > centreline)//高于中心线
                {
                    for (int j = i; j < i + continueN; j++)
                    {
                        if (sourcelist[j] < centreline)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        flag = false;
                        //连续N个数都高于中心线，继续
                        for (int j = i; j < i + continueN; j++)
                        {
                            if (sourcelist[j] > lineX_High_UCL || sourcelist[j] < lineX_Low_UCL)
                            {
                                count++;
                            }
                        }
                        if (count >= contains)
                        {
                            flag = true;
                        }
                    }

                }
                else//低于中心线
                {
                    for (int j = i; j < i + continueN; j++)
                    {
                        if (sourcelist[j] > centreline)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        flag = false;
                        //连续N个数都低于中心线，继续
                        for (int j = i; j < i + continueN; j++)
                        {
                            if (sourcelist[j] > lineX_High_LCL || sourcelist[j] < lineX_Low_LCL)
                            {
                                count++;
                            }
                        }
                        if (count >= contains)
                        {
                            flag = true;
                        }
                    }
                }

                if (flag)
                {
                    list.Add(i);
                }
                Console.WriteLine(DateTime.Now);
            }
            return list;
        }

        /// <summary>
        /// 7.连续N个点落在中心线两侧的C区以内
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="continueN">连续N个落点</param>
        /// <param name="lineC_U">C区上边界</param>
        /// <param name="lineC_L">C区下边界</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNLocalCenterInAreaC(List<int> sourcelist, int continueN, int lineC_U, int lineC_L)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < sourcelist.Count - continueN; i++)
            {
                bool flag = true;

                for (int j = i; j < i + continueN; j++)
                {
                    if (sourcelist[j] > lineC_U || sourcelist[j] < lineC_L)
                    {
                        flag = false;
                        break;
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
        /// 8.连续N个点落在中心线两侧且无一在C区内
        /// </summary>
        /// <param name="sourcelist">数据源</param>
        /// <param name="continueN">连续N个落点</param>
        /// <param name="lineC_U">C区上边界</param>
        /// <param name="lineC_L">C区下边界</param>
        /// <returns>返回符合的结果所在数据源的下标</returns>
        public static List<int> ContinueNLocalCenterNoneOutOfC(List<int> sourcelist, int continueN, int lineC_U, int lineC_L)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < sourcelist.Count - continueN; i++)
            {
                bool flag = true;

                for (int j = i; j < i + continueN; j++)
                {
                    if (sourcelist[j] < lineC_U && sourcelist[j] > lineC_L)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    list.Add(i);
                }
            }
            return list;
        }
    }

    public class diaoyong       
    {
        public static void diao1()
        {
            
        }
    }
}
