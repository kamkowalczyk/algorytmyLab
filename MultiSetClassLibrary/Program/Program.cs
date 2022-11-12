using System;
using MultiSetClassLibrary;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MultiSet<char> m = new MultiSet<char>();
            m.Add('a');
            m.Add('a');
            m.Add('a');
            m.Add('a');
            m.Add('a');
            m.Add('a');
            m.Add('a');
            m.Add('b');
            m.Add('b');
            m.Add('b');
            m.Add('b');
            m.Add('b');
            m.Add('a');
            Console.WriteLine(m);
            m.Remove('a');
            Console.WriteLine(m);
            m.Clear();
            Console.WriteLine(m);
            Console.WriteLine(m.Count);
        }
    }
}