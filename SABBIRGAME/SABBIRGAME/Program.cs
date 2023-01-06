using System;
using System.Numerics;

namespace SABBIRGAME
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCases; i++)
            {
                long minHP = 0;
                long currentHP = 0;
                int numberOfLevels = int.Parse(Console.ReadLine());
                string[] HPsForLevel = Console.ReadLine().Split(" ");
                for (int j = 0; j < numberOfLevels; j++)
                {
                    currentHP += long.Parse(HPsForLevel[j]);
                    if (currentHP < 1)
                    {
                        minHP += 1 - currentHP;
                        currentHP = 1;
                    }
                }
                Console.WriteLine(minHP);
            }
        }
    }
}