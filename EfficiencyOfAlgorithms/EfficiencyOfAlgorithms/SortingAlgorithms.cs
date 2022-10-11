using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfficiencyOfAlgorithms
{
    public static class SortingAlgorithms
    {
        public class InsertionSort
        {
            public void sort(int[] arr)
            {
                int n = arr.Length;
                for (int i = 1; i < n; ++i)
                {
                    int key = arr[i];
                    int j = i - 1;
                    while (j >= 0 && arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        j = j - 1;
                    }
                    arr[j + 1] = key;
                }
            }

            public void printArray(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");

                Console.Write("\n");
            }
        }

        public class MergeSort
        {
            public void merge(int[] arr, int l, int m, int r)
            {
                int n1 = m - l + 1;
                int n2 = r - m;

                int[] L = new int[n1];
                int[] R = new int[n2];
                int i, j;

                for (i = 0; i < n1; ++i)
                    L[i] = arr[l + i];
                for (j = 0; j < n2; ++j)
                    R[j] = arr[m + 1 + j];

                i = 0;
                j = 0;

                int k = l;
                while (i < n1 && j < n2)
                {
                    if (L[i] <= R[j])
                    {
                        arr[k] = L[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = R[j];
                        j++;
                    }
                    k++;
                }

                while (i < n1)
                {
                    arr[k] = L[i];
                    i++;
                    k++;
                }

                while (j < n2)
                {
                    arr[k] = R[j];
                    j++;
                    k++;
                }
            }

            public void sort(int[] arr, int l, int r)
            {
                if (l < r)
                {
                    int m = l + (r - l) / 2;

                    sort(arr, l, m);
                    sort(arr, m + 1, r);

                    merge(arr, l, m, r);
                }
            }

            public void printArray(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");
                Console.WriteLine();
            }

        }

        public class QuickSort
        {
            public void swap(ref int a, ref int b)
            {
                int t = a;
                a = b;
                b = t;
            }

            public int partition(int[] arr, int low, int high)
            {
                int pivot = arr[high];
                int i = (low - 1);

                for (int j = low; j <= high - 1; j++)
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        swap(ref arr[i], ref arr[j]);
                    }
                }
                swap(ref arr[i + 1], ref arr[high]);
                return (i + 1);
            }

            public void sort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int pi = partition(arr, low, high);

                    sort(arr, low, pi - 1);
                    sort(arr, pi + 1, high);
                }
            }

            public void printArray(int[] arr, int size)
            {
                int i;
                for (i = 0; i < size; i++)
                {
                    Console.Write(arr[i]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        public class ArraySort
        {
            public void sort(int[] arr)
            {
                Array.Sort(arr);
            }

            public void printArray(int[] arr)
            {
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}

