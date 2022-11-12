using System;
using System.Linq;

namespace Main
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int i = 0;
            int j = 0;

            while (d > 0)
            {
                d--;
                int[] nct = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                int n = nct[0];
                int c = nct[1];
                int t = nct[2];
                int flag = 0;
                int set = 0;
                int[] g = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

                Array.Sort(g, 1, g.Length - 1);
                Array.Reverse(g, 1, g.Length - 1);

                for (i = 1; i < n; i++)
                {
                    if (g[i] <= g[0])
                    {
                        Console.WriteLine($"{g[0]} 0");
                        goto end1;
                    }
                    if (Math.Abs(g[i] - g[0]) <= c)
                        break;
                }
                if (i == n)
                {
                    Console.WriteLine($"{g[0]} 0");
                    goto end1;
                }
                if (i == 1)
                {
                    Console.WriteLine($"{g[i]} {t}");
                    goto end1;
                }
                if (Math.Abs(g[i] - g[i - 1]) <= c)
                {
                    set = 2;
                }
                else
                {
                    flag = 1;
                    set = 1;
                    goto end;
                }

                j = i - 1;
                for (; j > 0;)
                {
                    if (Math.Abs(g[j] - g[j - 1]) <= c)
                    {
                        if (Math.Abs(g[j - 1] - g[i]) > c)
                        {
                            i = j;
                            set++;
                        }
                        j--;
                    }
                    else
                        break;
                }
            end:;
                if (flag == 1)
                    Console.WriteLine($"{g[i]} {set * t}");
                else
                    Console.WriteLine($"{g[j]} {set * t}");
                end1:;
            }
        }
    }
}
