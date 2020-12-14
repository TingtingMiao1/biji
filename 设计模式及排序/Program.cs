﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paixv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 1, 3, 4, 2, 8, 6, 0, 9, 7 };
            CrSort(arr);
            XeSort(arr);
            MPSort(arr);
            XZSort(arr);
            QSSort(arr);
            Console.ReadKey();
        }
        public static void CrSort(int[] arr)
        {
            //插入排序：从第二个数据开始，遍历所有元素，作为基准点；然后遍历这个基准点之前的所有元素和这个数据进行比较，
            //然后判断，数据大小，大的后移，利用j--，一直找到合适的位置，然后arr[j]=temp;赋值即可

            int i, j, temp;
            for (i = 0; i < arr.Length; i++)
            {
                temp = arr[i];
                for (j = i; j > 0; j--)
                {
                    if (temp < arr[j - 1])
                    {
                        arr[j] = arr[j - 1];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j] = temp;
            }
            Console.WriteLine("插入排序的结果为：" + String.Join(",", arr));
        }
        //希尔排序。希尔排序是把记录按下标的一定增量分组，对每组使用直接插入排序算法排序；随着增量逐渐减少，
        //每组包含的关键词越来越多，当增量减至 1 时，整个文件恰被分成一组，算法便终止。
        private static void XeSort(int[] arr)
        {
            
            // int[] arr = new int[] { 6, 3, 8, 4, 6, 3, 2,5,6,8 };
            int j, h, temp;
            int n = arr.Length / 2;
            for (h = n / 2; h > 0; h = h / 2)//循环所得 增量值
            {

                for (int i = h; i < arr.Length; i++)//循环的到点值
                {
                    temp = arr[i];//把点值付给temp
                    for (j = i - h; j >= 0 && temp < arr[j]; j = j - h)
                    {
                        arr[j + h] = arr[j];
                    }
                    arr[j + h] = temp;//很多情况下这个j为负值-1



                }
            }
            Console.WriteLine("希尔排序的结果为：" + String.Join(",", arr));
        }

        //冒泡排序：原理，相邻元素进行比较比较相邻的元素。如果第一个比第二个大，就交换他们两个。 [1] 
        //对每一对相邻元素做同样的工作，从开始第一对到结尾的最后一对。在这一点，最后的元素应该会是最大的数。 [1]
        //针对所有的元素重复以上的步骤，除了最后一个。 [1]
        //持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
        private static void MPSort(int[] arr)
        {

            int i, j, temp;
            bool change = false;//交换标志
            for (i = 0; i < arr.Length - 1; i++)
            {
                for (j = 0; j < arr.Length - 1 - i; j++)
                {
                    change = false;
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        change = true;
                    }


                }


            }
            Console.WriteLine("冒泡排序的结果为：" + String.Join(",", arr));
            if (!change)
            {
                return;
            }

        }
        private static void QSSort(int[] arr)
        {
            int L = 0;
            int R = arr.Length - 1;

            if(L < R)
            {
                int l = L;
                int r = R;
                int min = arr[l];
                while (l < r)
                {
                    while (l < r && arr[r] > min)
                    {
                        r--;
                    }
                    if (l < r)
                    {
                        arr[l] = arr[r];
                        l++;
                    }
                    while (l < r && arr[l] < min)
                    {
                        l++;
                    }
                    if (l < r)
                    {
                        arr[r] = arr[l];

                        r--;
                    }
                }

            }
            Console.WriteLine("快速排序的结果为：" + String.Join(",", arr));




        }
        //选择排序
        //从第一个开始 每一个他后边的所有进行比较，如果前边的大于后边的那么两者交换值，最小的值在前边,最大的值在最后
        //------- 命名;向后扫描法
        //首先从第一个数开始比较，找到比第一个数中最小的值的索引。交换两个数的位置。
        //
        private static void XZSort(int[] arr)
        {

            int i, j, temp;
            int min;
            for (i = 0; i < arr.Length - 1; i++)
            {
                min = i;

                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;//每一个for循环一遍的到一个每次中的最小的值的索引
                    }
                }
                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
            Console.WriteLine("选择排序的结果为：" + String.Join(",", arr));


        }
       
    }
}


    