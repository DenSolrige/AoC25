<Query Kind="Program" />

void Main()
{
	var ranges = new List<(long,long)>();
	var ids = new List<long>();
	var goodIds = new HashSet<long>();
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
			ranges.Add((range[0], range[1]));
		}
		else {
			ids.Add(long.Parse(line));
		}
	}
	//ranges.Dump();
	//ids.Dump();
	foreach (var range in ranges)
	{
		foreach (var id in ids)
		{
			if (id >= range.Item1 && id <= range.Item2)
			{
				goodIds.Add(id);
			}
			else if (id > range.Item2)
			{
				//break;
			}
		}
	}
	goodIds.Count.Dump();
}


// You can define other methods, fields, classes and namespaces here