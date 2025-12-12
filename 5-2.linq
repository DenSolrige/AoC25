<Query Kind="Program" />

void Main()
{
	var ranges = new Queue<(long,long)>();
	var consolidatedRanges = new List<(long,long)>();
	bool inIdSection = false;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-5.txt"))
	{
		//line.Dump();
		if (line == string.Empty)
		{
			inIdSection = true;
			continue;
		}
		if (!inIdSection)
		{
			var range = line.Split('-', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToList();
			ranges.Enqueue((range[0], range[1]));
		}
		else {
			break;
		}
	}
	ranges.Dump();
	while (ranges.Count > 0)
	{
		var range = ranges.Dequeue();//.Dump();
		bool addedRange = false;
		for (int i = 0; i < consolidatedRanges.Count; i++)
		{
			var consolidatedRange = consolidatedRanges[i];
			if (range.Item1 >= consolidatedRange.Item1 && range.Item1 <= consolidatedRange.Item2)
			{
				consolidatedRanges.RemoveAt(i);
				ranges.Enqueue((consolidatedRange.Item1, Math.Max(range.Item2, consolidatedRange.Item2)));
				addedRange = true;
				break;
			}
			else if (range.Item2 >= consolidatedRange.Item1 && range.Item2 <= consolidatedRange.Item2)
			{
				consolidatedRanges.RemoveAt(i);
				ranges.Enqueue((Math.Min(range.Item1,consolidatedRange.Item1), consolidatedRange.Item2));
				addedRange = true;
				break;
			}
			else if (consolidatedRange.Item1 >= range.Item1 && consolidatedRange.Item1 <= range.Item2)
			{
				consolidatedRanges.RemoveAt(i);
				ranges.Enqueue((range.Item1, Math.Max(range.Item2, consolidatedRange.Item2)));
				addedRange = true;
				break;
			}
			else if (consolidatedRange.Item2 >= range.Item1 && consolidatedRange.Item2 <= range.Item2)
			{
				consolidatedRanges.RemoveAt(i);
				ranges.Enqueue((Math.Min(range.Item1,consolidatedRange.Item1), range.Item2));
				addedRange = true;
				break;
			}
		}
		if (!addedRange)
		{
			consolidatedRanges.Add(range);
		}
	}
	consolidatedRanges.Dump();
	consolidatedRanges.Select(x => x.Item2 - x.Item1 + 1).Sum().Dump();
}


// You can define other methods, fields, classes and namespaces here