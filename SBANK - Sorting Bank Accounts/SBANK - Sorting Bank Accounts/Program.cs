using System;
using System.Collections.Generic;
using System.Text;

namespace SBANK
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var bank = new Dictionary<string, int>();
                int k = int.Parse(Console.ReadLine());
                for (int j = 0; j < k; j++)
                {
                    var account = Console.ReadLine();
                    if (bank.ContainsKey(account))
                    {
                        bank[account]++;
                    }
                    else
                    {
                        bank.Add(account, 1);
                    }
                }
                string[] accounts = new string[bank.Keys.Count];
                bank.Keys.CopyTo(accounts, 0);
                Array.Sort(accounts);

                foreach (var number in accounts)
                {
                    result.AppendLine($"{number} {bank[number]}");
                }
                result.AppendLine();
                Console.ReadLine();
            }
            Console.Write(result.ToString());
        }
    }
}
