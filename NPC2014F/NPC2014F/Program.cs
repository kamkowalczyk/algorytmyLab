using System;

namespace Main
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string arr = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());

            int a;
            char c;
            int[] arr1 = new int[26];
            int[] arr2 = new int[26];
            for (int i = 0; i < k; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                a = int.Parse(input[0]);
                c = input[1][0];
                arr1[c - 'a'] = a;
            }

            int left = 0;
            int right = 0;
            int sum = 0;
            int result = int.MaxValue;
            while (left < n && right < n)
            {
                arr2[arr[right] - 'a']++;
                if (arr2[arr[right] - 'a'] == arr1[arr[right] - 'a'])
                    sum++;

                if (sum == k)
                {
                    while (arr2[arr[left] - 'a'] > arr1[arr[left] - 'a'])
                    {
                        left++;
                        arr2[arr[left - 1] - 'a']--;
                    }
                    result = Math.Min(result, right - left + 1);
                }
                right++;
            }

            if (result != int.MaxValue)
                Console.WriteLine(result);
            else
                Console.WriteLine("Andy rapopo");
        }
    }
}
