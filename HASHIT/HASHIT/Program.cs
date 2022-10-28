using System;
using System.Text;
namespace HASHIT
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int t = Convert.ToInt32(System.Console.ReadLine());
			for (int i = 0; i < t; i++)
			{
				string[] table = new string[101];
				int n = Convert.ToInt32(System.Console.ReadLine());
				for (int i2 = 0; i2 < n; i2++)
				{
					string line = System.Console.ReadLine();
					string op = line.Substring(0, 3);
					string key = line.Substring(4);
					int ix = FindKey(table, key);

					if (op == "ADD")
					{
						if (ix == -1)
						{
							ix = FindNextOpenAddress(table, Hash(key));
							if (ix >= 0)
							{
								table[ix] = key;
							}
						}
					}
					else
					{
						if (ix >= 0)
						{
							table[ix] = string.Empty;
						}
					}
				}
				StringBuilder sb = new StringBuilder();
				int count = 0;
				for (int j = 0; j < 101; j++)
				{
					if (!string.IsNullOrEmpty(table[j]))
					{
						count++;
						sb.AppendLine(j + ":" + table[j]);
					}
				}
				Console.WriteLine(count);
				Console.Write(sb.ToString());
			}
		}
		public static int Hash(string key)
		{
			int ret = 0;
			ret = h(key) % 101;
			return ret;
		}
		public static int h(string key)
		{
			int ret = 0;
			int cnt = key.Length;
			for (int i = 0; i < cnt; i++)
			{
				ret += (int)key[i] * (i + 1);
			}
			return ret * 19;
		}
		public static int FindKey(string[] table, string key)
		{
			int ix = Hash(key);
			if (table[ix] == key)
				return ix;
			for (int j = 1; j < 20; j++)
			{
				int newix = (ix + j * j + 23 * j) % 101;
				if (table[newix] == key)
				{
					return newix;
				}
			}
			return -1;
		}
		public static int FindNextOpenAddress(string[] table, int ix)
		{
			if (string.IsNullOrEmpty(table[ix]))
				return ix;
			for (int j = 1; j < 20; j++)
			{
				int newix = (ix + j * j + 23 * j) % 101;
				if (string.IsNullOrEmpty(table[newix]))
				{
					return newix;
				}
			}
			return -1;
		}
	}
}