using System;
using System.Collections.Generic;


public static class STPAR
{
    public static bool Solve(int[] a)
    {
        var b = new Stack<int>();
        int c = 1;
        for (int i = 0; i < a.Length; ++i)
        {
            while (b.Count > 0
                && b.Peek() == c)
            {
                b.Pop();
                ++c;
            }
            int d = a[i];
            if (d == c)
            {
                ++c;
            }
            else if (b.Count == 0

                || d < b.Peek())
            {
                b.Push(d);
            }
            else return false;
        }
        return true;
    }
}
public static class Program
{
    private static void Main()
    {
        int e;
        while ((e = int.Parse(Console.ReadLine())) != 0)
        {
            int[] f = Array.ConvertAll(
                Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(
                STPAR.Solve(f) ? "yes" : "no");
        }
    }
}