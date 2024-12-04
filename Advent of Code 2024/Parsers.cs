global using static Advent_of_Code_2024.Parsers;
using System.Collections;
using System.Numerics;

namespace Advent_of_Code_2024
{
	internal static class Parsers
	{
		public static List<List<T>> GetColumns<T>(string path, string separator = " ", bool removeEmpty = true, bool removeWhitespace = false) where T : INumberBase<T>
		{
			var lines = ReadLines(path);
			int lCount = lines.First().Split(separator).Length;
			List<List<T>> ll = new(lCount);
			for (int i = 0; i < lCount; i++)
				ll.Add([]);

			StringSplitOptions options = StringSplitOptions.None;
			if (removeEmpty)
				options |= StringSplitOptions.RemoveEmptyEntries;
			if (removeWhitespace)
				options |= StringSplitOptions.TrimEntries;

			foreach (string str in lines)
			{
				int i = 0;
				foreach (string s in str.Split(separator, options))
					ll[i++].Add(T.Parse(s, System.Globalization.NumberStyles.Number, null));
			}

			return ll;
		}

		public static IEnumerable<List<T>> GetRows<T>(string path, string separator = " ", bool removeEmpty = true, bool removeWhitespace = false) where T : INumberBase<T>
		{
			StringSplitOptions options = StringSplitOptions.None;
			if (removeEmpty)
				options |= StringSplitOptions.RemoveEmptyEntries;
			if (removeWhitespace)
				options |= StringSplitOptions.TrimEntries;

			foreach (string line in ReadLines(path))
			{
				string[] split = line.Split(separator, options);
				List<T> ll = new(split.Length);
				for (int i = 0; i < split.Length; i++)
					ll.Add(T.Parse(split[i], System.Globalization.NumberStyles.Number, null));

				yield return ll;
			}
		}

		public static IEnumerable<string> ReadLines(string path)
		{
			using StreamReader sr = File.OpenText(path);
			string? line;
			while ((line = sr.ReadLine()) is not null)
				yield return line;
		}
	}
}
