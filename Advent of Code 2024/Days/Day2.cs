using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2024.Days
{
	internal static class Day2
	{
		public static void Run()
		{
			var data = GetRows<int>("day2.txt");
			//int numSafe = data.Aggregate(0, (int numSafe, List<int> next) => SafeDampened(next) ? numSafe + 1 : numSafe);
			//Console.WriteLine($"Safe reports: {numSafe}");
		}

		private static bool Safe(List<int> vals)
		{
			int i = 0;
			return Safe(vals, ref i);
		}

		private static bool Safe(List<int> vals, ref int problemIndex)
		{
			// Broke this in my attempt for part 2, will fix later this month
			problemIndex = 0;
			(int index, int sign)[] signs = [
				(0, int.Sign(vals[1] - vals[0])),
				(1, int.Sign(vals[2] - vals[1])),
				(2, int.Sign(vals[3] - vals[2])),
				];

			int sign = int.Clamp(signs.Sum(i => i.sign), -1, 1);
			foreach (var kvp in signs)
			{
				if (kvp.sign != sign || kvp.sign == 0)
				{
					problemIndex = kvp.index;
					return false;
				}
			}

			int diff;
			for (int i = 1; i < vals.Count; i++)
			{
				diff = vals[i] - vals[i - 1];

				if (sign != int.Sign(diff))
				{
					if (i == vals.Count - 1 || sign != int.Sign(vals[i + 1] - vals[i]))	// End of list, or sign following this problem persists with wrong sign
						problemIndex = i;
					else
						problemIndex = i - 1;
					return false;
				}

				if (int.Abs(diff) > 3 || diff == 0)
				{
					problemIndex = i;
					return false;
				}
			}
			problemIndex = -1;
			return true;
		}
	}
}