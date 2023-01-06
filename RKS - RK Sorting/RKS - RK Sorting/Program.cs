using System;
using System.Collections.Generic;
using System.Linq;

namespace RK_sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int a = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
            int b = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

            input = Console.ReadLine();
            List<int> numbers = new List<int>(Array.ConvertAll(input.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse));

            var countedNumbers = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (!countedNumbers.ContainsKey(numbers[i]))
                {
                    countedNumbers.Add(numbers[i], numbers.FindAll(x => x == numbers[i]).Count);
                }
            }
            foreach (KeyValuePair<int, int> item in countedNumbers.OrderByDescending(x => x.Value))
            {
                for (int i = 0; i < item.Value; i++)
                {
                    Console.Write(item.Key + " ");
                }
            }
        }
    }
}