using System;
using System.Text;

namespace ADAINDEX
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int[] N = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int words = N[0];
            int queries = N[1];

            string[] wordsTab = new string[words];
            for (int i = 0; i < words; i++)
            {

                wordsTab[i] = Console.ReadLine();


            }



            for (int j = 0; j < queries; j++)
            {
                string sub = Console.ReadLine();
                sb.Append(WordsLength(wordsTab, sub) + "\n");




            }
            Console.WriteLine(sb);
        }


        static int WordsLength(string[] wordsTab, string sub)
        {
            int sol = 0;
            for (int z = 0; z < wordsTab.Length; z++)
            {

                if (wordsTab[0].Contains(sub)) sol++;

            }

            return sol;
        }
    }
}