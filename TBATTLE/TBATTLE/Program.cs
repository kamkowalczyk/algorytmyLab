using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Main
{
    internal class Program
    {
        protected static TextReader reader;
        protected static TextWriter writer;
        static void Main(string[] args)
        {
            reader = new StreamReader(Console.OpenStandardInput());
            writer = new StreamWriter(Console.OpenStandardOutput());
            int a = 0;
            int b = 0;
            int max = 100000;
            int[] c = new int[max];
            int[] d = new int[max];
            int[,] arr = new int[max, 10];
            Connect[] n = new Connect[10];
            int t = ReadInt();
            int[] army = new int[t];
            string[] tokens = ReadAndSplitLine();

            for (int i = 0; i < t; i++)
                army[i] = int.Parse(tokens[i]);

            for (int i = 2; i < 1000000; i++)
            {
                for (int j = 2; i * j < 100000; i++)
                    c[i * j] = 1;
            }

            for (int i = 2; i < 1000; i++)
            {
                if (c[i] == 0)
                    d[a++] = i;
            }

            int s = t;
            while (s != 1)
            {
                for (int i = 0; i < a; i++)
                {
                    if (s % d[i] == 0)
                    {
                        n[b].previous = d[i];
                        while (s % d[i] == 0)
                        {
                            n[b].data++;
                            s /= d[i];
                        }
                        b++;
                    }
                }
            }

            for (int i = 0; i < t; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    while (army[i] % n[j].previous == 0)
                    {
                        arr[i, j]++;
                        army[i] /= n[j].previous;
                    }
                }
            }

            int h = 0, g = 0, r1 = 0, r2 = 0, l = max, check = 0, num;
            while (g < t)
            {
                num = 0;
                for (int i = 0; i < b; i++)
                    n[i].data -= arr[g, i];

                for (int i = 0; i < b; i++)
                    if (n[i].data <= 0) num++;

                if (num == b)
                {
                    check = 1;
                    while (true)
                    {
                        num = 0;
                        for (int i = 0; i < b; i++)
                            n[i].data += arr[h, i];

                        for (int i = 0; i < b; i++)
                            if (n[i].data <= 0) num++;

                        if (num != b && g - h + 1 < l)
                        {
                            l = g - h + 1;
                            r1 = h;
                            r2 = g;
                        }
                        h++;
                        if (num != b)
                            break;
                    }
                }
                g++;
            }

            if (check != 0)
                Console.WriteLine($"{r1} {r2}");
            else
                Console.WriteLine("-1");
        }

        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
        public static int[][] ReadIntMatrix(int numberOfRows)
        {
            int[][] matrix = new int[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix;
        }
        public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
        public static int ReadLong() { return int.Parse(ReadToken()); }
        public static double ReadDouble() { return double.Parse(ReadToken(), CultureInfo.InvariantCulture); }

        private static Queue<string> currentLineTokens = new Queue<string>();
        private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries); }
        public static string ReadToken()
        {
            while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine());
            return currentLineTokens.Dequeue();
        }
        public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
        public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
        {
            int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
            for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
            return ret;
        }
        public static void Write(params object[] array) { WriteArray(array); }
        public static void WriteLines<T>(IEnumerable<T> array) { foreach (var a in array) writer.WriteLine(a); }
        public static string[] ReadLines(int quantity)
        {
            string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim();
            return lines;
        }
        public static void WriteArray<T>(IEnumerable<T> array) { writer.WriteLine(string.Join(" ", array)); }
        private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        {
            public new TValue this[TKey key]
            {
                get { return ContainsKey(key) ? base[key] : default(TValue); }
                set { base[key] = value; }
            }
        }
        private static T[] Init<T>(int size) where T : new()
        {
            var ret = new T[size];
            for (int i = 0; i < size; i++) ret[i] = new T();
            return ret;
        }
    }

    public struct Connect
    {
        public int previous;
        public int data;
    }
}
