using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2024.Days
{
	internal static class Day1
	{
		public static void Run()
		{
			var data = GetColumns<int>("day1.txt", "   ");
			var l1 = data[0];
			var l2 = data[1];
			l1.Sort();
			l2.Sort();

			var l3 = new int[l1.Count];
			for (int i = 0; i < l1.Count; i++)
				l3[i] = int.Abs(l1[i] - l2[i]);

			int sum = l3.Sum();
			int similarity = Similarity(l1.Distinct(), l2).Sum();
			Console.WriteLine($"Sum: {sum}, Similarity: {similarity}");
		}

		private static IEnumerable<int> Similarity(IEnumerable<int> distinct, IEnumerable<int> l2)
		{
			foreach (var d in distinct)
			{
				int tally = 0;
				foreach (var i in l2)
					if (i == d)
						tally += 1;

				yield return tally * d;
			}
		}
	}
}
