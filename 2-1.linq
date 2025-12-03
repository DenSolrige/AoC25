<Query Kind="Program" />

void Main()
{
	var ranges = new List<(long,long)>();
	long sum = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-2.txt"))
	{
		// check values %11 and %101 and %1001 and so on
	    ranges = line.Split(',', StringSplitOptions.RemoveEmptyEntries)
							 .Select(x => 
							 {
							 	var range = x.Split('-', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToList();
								//(Math.Floor(Math.Log10(range[0]) + 1)).Dump();
								//(Math.Floor(Math.Log10(range[1]) + 1)).Dump();
								//(range[1] - range[0]).Dump();
								return (range[0], range[1]);
							 })
							 .ToList();
	}
	//ranges.Dump();
	foreach (var range in ranges)
	{
		//range.Dump();
		for(long i = range.Item1; i <= range.Item2; i++)
		{
			var digits = Math.Floor(Math.Log10(i) + 1);
			if (digits % 2 != 0)
			{
				continue;
			}
			
			//i.Dump();
			//digits.Dump();
			var modulus = Math.Pow(10, digits/2) + 1;
			//modulus.Dump();
			//(i % modulus).Dump();
			if (i % modulus == 0)
			{
				//i.Dump();
				sum += i;
			}
		}
	}
	sum.Dump();
}


// You can define other methods, fields, classes and namespaces here