using Eb3yrLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent_of_Code_2024.Days
{
	internal static class Day4
	{
		public static void Run()
		{
			string input = File.ReadAllText("day4.txt");    // 140 by 140 char grid, split on line ends
			string[] wordGrid = input.Split("\n");
			int lineLength = wordGrid[0].Length;
			int count = 0;

			string target = "XMAS";
			string word;

			for (int j = 0; j < wordGrid.Length; j++)
			{
				for (int i = 0; i < lineLength; i++)
					{
					if (wordGrid[j][i] != 'X')
						continue;

					for (int xDir = -1; xDir < 2; xDir++)
					{
						for (int yDir = -1; yDir < 2; yDir++)
						{
							if ((yDir == 0) && (xDir == 0))
								continue;

							word = target[..1];
							
							while (word.Length < target.Length)
							{
								int wgIndex = j + word.Length * yDir;
								int lineIndex = i + word.Length * xDir;

								if (OutOfBounds(wgIndex, 0, wordGrid.Length) || OutOfBounds(lineIndex, 0, lineLength))
									break;

								word += wordGrid[wgIndex][lineIndex];
								if (IsMatch(word, target))
								{
									if (word == target)
									{
										count++;
										break;
									}
								}
							}
						}
					}
				}
			}
			Console.WriteLine($"Count: {count}");
		}

		public static void Run2()
		{
			string input = File.ReadAllText("day4.txt");    // 140 by 140 char grid, split on line ends
			string[] wordGrid = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
			int lineLength = wordGrid[0].Length;
			int count = 0;

			for (int j = 0; j < wordGrid.Length - 2; j++)
			{
				for (int i = 0; i < lineLength - 2; i++)
				{
					if (IsMas([wordGrid[i][j..(j + 3)], wordGrid[i + 1][j..(j + 3)], wordGrid[i + 2][j..(j + 3)]]))
						count++;
				}
			}
			Console.WriteLine($"Count: {count}");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsMas(string[] strs)
		{
			string topLeft = new([strs[0][0], strs[1][1], strs[2][2]]);
			string bottomLeft = new([strs[2][0], strs[1][1], strs[0][2]]);
			return (topLeft is "MAS" or "SAM") && (bottomLeft is "MAS" or "SAM");
		}

		private static bool IsMatch(string word, string target)
		{
			return word == target[..word.Length];
		}

		private static bool OutOfBounds(int index, int min, int maxExcl)
		{
			return index < min || index > maxExcl - 1;
		}

		private static string Format(this string[] strs)
		{
			string o = "";
			foreach (string str in strs)
				o += (str + "\n");

			return o;
		}
	}
}
