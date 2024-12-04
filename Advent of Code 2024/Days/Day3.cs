using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2024.Days
{
	internal static class Day3
	{
		public static void Run()
		{
			string input = File.ReadAllText("day3.txt");
			var matches = Regex.Matches(input, @"mul\(\d+,\d+\)|do\(\)|don't\(\)");
			uint sum = 0;

			bool doSum = true;
			foreach (Match m in matches)
			{
				string mString = m.Value;
				if (mString == "do()")
					doSum = true;
				else if (mString == "don't()")
					doSum = false;
				else
				{
					string[] strs = m.Value[4..^1].Split(',');
					if (doSum)
						sum += uint.Parse(strs[0]) * uint.Parse(strs[1]);
				}
			}

			Console.WriteLine($"Sum: {sum}");
			Console.WriteLine($"MatchesSum: {MatchesSum(input)}");
		}

		public static uint MatchesSum(string input)
		{
			string buffer = "";
			bool doSum = true;
			uint sum = 0;
			int i;
			foreach (char c in input)
			{
				buffer += c;
				if ((i = buffer.IndexOf("mul(")) is not -1 && buffer[^1] is ')')
				{
					string[] strs = buffer[(4 + i)..^(1)].Split(',');
					if (doSum)
						sum += uint.Parse(strs[0]) * uint.Parse(strs[1]);
				}
				else if (buffer.Contains("do()"))
				{
					doSum = true;
				}
				else if (buffer.Contains("don't()"))
				{
					doSum = false;
				}
				else
				{
					continue;
				}
				buffer = "";
			}
			return sum;
		}
	}
}
