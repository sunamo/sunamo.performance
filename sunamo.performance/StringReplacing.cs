

	public class StringReplacing
	{
		// Used http://stackoverflow.com/a/20285267/40868 as a template 
		private static readonly Random Seed = new Random(42); //used a constant to keep result consistant
		private static readonly string OutputFormat = "{0, -20} | {1, 8} | {2, -40}";

		private static string BuildRandomInputString(int length)
		{
			var input = new StringBuilder();
			for (var i = 0; i < length; i++)
			{
				var randomNumber = Seed.Next(0, 3);
				var character = randomNumber == 0 ? 'A' : randomNumber == 1 ? 'B' : 'C';

				input.Append(character);
			}
			return input.ToString();
		}

		private static List<string> BuildRandomReplacements(int replacementsCount)
		{
			var replacements = new List<string>();
			for (var i = 0; i < replacementsCount; i++)
			{
				var randomNumber = Seed.Next(0, 3);
				var replaceIteration = randomNumber == 0 ? "AB" : randomNumber == 1 ? "BC" : "CD";

				replacements.Add(replaceIteration);
			}
			return replacements;
		}

		private static long TestImplementation(string input, string replace, string[] replacements,
			Action<string, string, string[]> implementation)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();

			var stopWatch = Stopwatch.StartNew();
			implementation(input, replace, replacements);
			stopWatch.Stop();

			return stopWatch.ElapsedMilliseconds;
		}

		private static void SimpleImplementation(string input, string replace, string[] replacements)
		{
			foreach (var replaceBy in replacements)
			{
				var result = input.Replace(replace, replacements[0]);
			}
		}

		private static void SimpleParallelImplementation(string input, string replace, string[] replacements)
		{
			var rangePartitioner = Partitioner.Create(0, replacements.Length);

			Parallel.ForEach(rangePartitioner, (range, loopState) =>
			{
				for (var i = range.Item1; i < range.Item2; i++)
				{
					var result = input.Replace(replace, replacements[i]);
				}
			});
		}

		


		private static unsafe void UnsafeUnmanagedImplementation(string input, string oldValue, string[] newValues)
		{
		StringBuilder sb = new StringBuilder(input);
#if UNSAFE
		var res = SHSecureStringHelper.ReplaceUnsafeUnmanaged(sb, oldValue, newValues);
#endif
		int i = 0;
		}

		private static void ParallelSubstringImplementation(string input, string replace, string[] replaceBy)
		{
			var startingPosition = 0;
			var indexes = new List<int>();

			int currentPosition;

			while ((currentPosition = input.IndexOf(replace, startingPosition)) >= 0)
			{
				indexes.Add(currentPosition);
				startingPosition = currentPosition + 1;
			}

			var replaceByPartitioner = Partitioner.Create(0, replaceBy.Length);
			var rangePartitioner = Partitioner.Create(0, indexes.Count);

			Parallel.ForEach(replaceByPartitioner, (outerRange, outerLoopState) =>
			{
				for (var g = outerRange.Item1; g < outerRange.Item2; g++)
				{
					var replaceWith = replaceBy[g];

					var finalSize = input.Length - (indexes.Count * replace.Length) + (indexes.Count * replaceWith.Length);
					var finalResult = new char[finalSize];

					Parallel.ForEach(rangePartitioner, (innerRange, innerLoopState) =>
					{
						for (var i = innerRange.Item1; i < innerRange.Item2; i++)
						{
							var currentIndex = indexes[i];
							var prevIndex = i > 0 ? indexes[i - 1] : -replace.Length;

							var n = 0;
							if (prevIndex >= 0)
							{
								n = prevIndex + replace.Length;

								// note that due to offset changes,
								// prevIndex doesn't map to 1:1 if lens are different
								if (replace.Length != replaceWith.Length)
								{
									var offset = (replace.Length - replaceWith.Length) * i;
									var dir = replace.Length < replaceWith.Length;
									n = prevIndex + offset + replaceWith.Length + (dir ? 1 : -1);
								}
							}

							// append everything between two indexes.
							for (var k = prevIndex + replace.Length; k < currentIndex; k++)
								finalResult[n++] = input[k];

							// append replaced text.
							foreach (var ch in replaceWith)
								finalResult[n++] = ch;

							// if dealing with last index.
							// we need to append remaining parts
							if (currentIndex == indexes[indexes.Count - 1])
							{
								for (var k = currentIndex + replace.Length; k < input.Length; k++)
									finalResult[n++] = input[k];
							}
						}
					});
				}
			});
		}

		private unsafe static void FredouImplementation(string input, string replace, string[] replaceBy)
		{
			var inputLength = input.Length;

			var indexes = new List<int>();

			//my own string.indexof to save a few ms
			int len = inputLength;
			fixed (char* i = input, r = replace)
			{
				while (--len > -1)
				{
					//i wish i knew how to do this in 1 compare :-)
					if (i[len] == r[0] && i[len + 1] == r[1])
					{
						indexes.Add(len--);
					}
				}
			}

			var idx = indexes.ToArray();
			len = indexes.Count;

			Parallel.For(0, replaceBy.Length, l =>
				Process(input, inputLength, replaceBy[l], idx, len)
			);
		}

		private unsafe static void Process(string input, int len, string replaceBy, int[] idx, int idxLen)
		{
			var output = new char[len];
			int l;

			fixed (char* o = output, i = input)
			{
				//direct copy, simulate string.copy
				for (l = 0; l < len; ++l)
				{
					o[l] = i[l];
				}

				//oldValue, i also wish to know how to do this in 1 shot
				for (l = 0; l < idxLen; ++l)
				{
					o[idx[l]] = replaceBy[0];
					o[idx[l] + 1] = replaceBy[1];
				}
			}

			//Console.WriteLine(output);
		}


		public static void StringReplacingMain()
		{
			var implementations = new[]
			{
				new Tuple<string, Action<string, string, string[]>>("Simple", SimpleImplementation),
                new Tuple<string, Action<string, string, string[]>>("SimpleParallel", SimpleParallelImplementation),
                new Tuple<string, Action<string, string, string[]>>("ParallelSubstring", ParallelSubstringImplementation),
                new Tuple<string, Action<string, string, string[]>>("Fredou unsafe", FredouImplementation),
#if UNSAFE
				//new Tuple<string, Action<string, string, string[]>>("Unsafe+unmanaged_mem", UnsafeUnmanagedImplementation)
#endif
			};

			Console.WriteLine(OutputFormat, "Implementation", "Average", "Seperate runs");

			var replace = "BC";
			var testCases = new[]
			{
				new {ReplacementCount = 500, InputLength = (int)Math.Pow(10, 6) * 2},
				new {ReplacementCount = 500, InputLength = (int)Math.Pow(10, 6)},
				new {ReplacementCount = 100, InputLength = (int)Math.Pow(10, 6) / 2},
				new {ReplacementCount = 50, InputLength = (int)Math.Pow(10, 3)}
			};

			var result = new Dictionary<string, List<long>>();
			foreach (var testCase in testCases)
			{
				var input = BuildRandomInputString(testCase.InputLength);
				var replacements = BuildRandomReplacements(testCase.ReplacementCount).ToArray();

				foreach (var implementation in implementations)
				{
					var elapsedTime = TestImplementation(input, replace, replacements, implementation.Item2);
					if (!result.ContainsKey(implementation.Item1))
						result[implementation.Item1] = new List<long>();

					result[implementation.Item1].Add(elapsedTime);
				}
			}


			foreach (var implementation in implementations)
			{
				var l = result[implementation.Item1];

				var averageTime = (long)l.Average();
				Console.WriteLine(OutputFormat, implementation.Item1, averageTime,
					string.Join(", ", l.Select(x => x.ToString(CultureInfo.InvariantCulture))));
			}

			Console.ReadKey();
		}
	}
