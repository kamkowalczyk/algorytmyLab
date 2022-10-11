using System;
using System.Collections.Generic;
using System.Linq;

namespace EfficiencyOfAlgorithms
{
    class Program
    {
     public class Timer
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            SortingAlgorithms.InsertionSort i_s = new SortingAlgorithms.InsertionSort();
            SortingAlgorithms.MergeSort m_s = new SortingAlgorithms.MergeSort();
            SortingAlgorithms.QuickSort q_s = new SortingAlgorithms.QuickSort();
            SortingAlgorithms.ArraySort a_s = new SortingAlgorithms.ArraySort();

            public void getAttempt(int type, int size, int minVal = 0, int maxVal = 0, int almost = 0)
            {
                int[] A_T = new int[size];

                TimeSpan[] i_s_t = new TimeSpan[10];
                TimeSpan[] m_s_t = new TimeSpan[10];
                TimeSpan[] q_s_t = new TimeSpan[10];
                TimeSpan[] a_s_t = new TimeSpan[10];

                TimeSpan i_s_t_Avg = new TimeSpan();
                TimeSpan m_s_t_Avg = new TimeSpan();
                TimeSpan q_s_t_Avg = new TimeSpan();
                TimeSpan a_s_t_Avg = new TimeSpan();

                switch (type)
                {
                    case 1:
                        A_T = Generators.GenerateRandom(size, minVal, maxVal);
                        break;
                    case 2:
                        A_T = Generators.GenerateSorted(size, minVal, maxVal);
                        break;
                    case 3:
                        A_T = Generators.GenerateReversed(size, minVal, maxVal);
                        break;
                    case 4:
                        A_T = Generators.GenerateAlmost(size, minVal, maxVal, almost);
                        break;
                    case 5:
                        A_T = Generators.GenerateFewUnique(size);
                        break;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int[] a_t = (int[])A_T.Clone();
                        stopWatch.Start();
                        if (i == 0) { i_s.sort(a_t); }
                        if (i == 1) { m_s.sort(a_t, 0, a_t.Length - 1); }
                        if (i == 2) { q_s.sort(a_t, 0, a_t.Length - 1); }
                        if (i == 3) { a_s.sort(a_t); }
                        stopWatch.Stop();
                        if (i == 0) { i_s_t[i] = stopWatch.Elapsed; }
                        if (i == 1) { m_s_t[i] = stopWatch.Elapsed; }
                        if (i == 2) { q_s_t[i] = stopWatch.Elapsed; }
                        if (i == 3) { a_s_t[i] = stopWatch.Elapsed; }
                    }

                    i_s_t_Avg = i_s_t_Avg / 10;
                    m_s_t_Avg = m_s_t_Avg / 10;
                    q_s_t_Avg = q_s_t_Avg / 10;
                    a_s_t_Avg = a_s_t_Avg / 10;

                    for (int k = 0; k < 10; k++)
                    {
                        if (i == 0) { i_s_t_Avg = i_s_t_Avg.Add(i_s_t[k]); }
                        if (i == 1) { m_s_t_Avg = m_s_t_Avg.Add(m_s_t[k]); }
                        if (i == 2) { q_s_t_Avg = q_s_t_Avg.Add(q_s_t[k]); }
                        if (i == 3) { a_s_t_Avg = a_s_t_Avg.Add(a_s_t[k]); }
                    }

                }

                Console.WriteLine("InsertionSort: t = " + i_s_t_Avg.TotalMilliseconds.ToString() + " +/- " + arrDeviation(i_s_t).ToString());
                Console.WriteLine("MergeSort: t = " + m_s_t_Avg.TotalMilliseconds.ToString() + " +/- " + arrDeviation(m_s_t).ToString());
                Console.WriteLine("QuickSort: t = " + q_s_t_Avg.TotalMilliseconds.ToString() + " +/- " + arrDeviation(q_s_t).ToString());
                Console.WriteLine("ArraySort: t = " + a_s_t_Avg.TotalMilliseconds.ToString() + " +/- " + arrDeviation(a_s_t).ToString());
                Console.WriteLine();
            }

            private double arrDeviation(TimeSpan[] time)
            {
                List<double> intList = new List<double> { };
                for (int i = 0; i < time.Length; i++)
                {
                    intList.Add(Convert.ToDouble(time[i].TotalMilliseconds));
                }

                double average = intList.Average();
                double sumOfDerivation = 0;
                foreach (double value in intList)
                {
                    sumOfDerivation += (value) * (value);
                }
                double sumOfDerivationAverage = sumOfDerivation / (intList.Count - 1);
                double deviation = Math.Sqrt(sumOfDerivationAverage - (average * average));
                return Math.Round(deviation, 6);
            }
        }

        public static void Main(string[] args)
        {
            var example = new Program.Timer();

            Console.WriteLine("Przypadek 1: próba mała (n = 10), random");
            example.getAttempt(1, 10, 0, 100);
            Console.WriteLine("Przypadek 2: próba mała (n = 10), sorted");
            example.getAttempt(2, 10, 0, 100);
            Console.WriteLine("Przypadek 3: próba mała (n = 10), reversed");
            example.getAttempt(3, 10, 0, 100);
            Console.WriteLine("Przypadek 4: próba mała (n = 10), almost sorted");
            example.getAttempt(4, 10, 0, 100, 2);
            Console.WriteLine("Przypadek 5: próba mała (n = 10), few unique");
            example.getAttempt(5, 10);
            Console.WriteLine("Przypadek 6: próba średnia (n = 1000), random");
            example.getAttempt(1, 1000, 0, 1000);
            Console.WriteLine("Przypadek 7: próba średnia (n = 1000), sorted");
            example.getAttempt(2, 1000, 0, 1000);
            Console.WriteLine("Przypadek 8: próba średnia (n = 1000), reversed");
            example.getAttempt(3, 1000, 0, 1000);
            Console.WriteLine("Przypadek 9: próba średnia (n = 1000), almost sorted");
            example.getAttempt(4, 1000, 0, 1000, 30);
            Console.WriteLine("Przypadek 10: próba średnia (n = 1000), few unique");
            example.getAttempt(5, 1000);
            Console.WriteLine("Przypadek 11: próba duża (n = 100000), random");
            example.getAttempt(1, 10000, 0, 1000);
            Console.WriteLine("Przypadek 12: próba duża (n = 100000), sorted");
            example.getAttempt(2, 10000, 0, 1000);
            Console.WriteLine("Przypadek 13: próba duża (n = 100000), reversed");
            example.getAttempt(3, 10000, 0, 1000);
            Console.WriteLine("Przypadek 14: próba duża (n = 100000), almost sorted");
            example.getAttempt(4, 10000, 0, 1000, 50);
            Console.WriteLine("Przypadek 15: próba duża (n = 100000), few unique");
            example.getAttempt(5, 10000);



        }
    }
}
