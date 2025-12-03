<Query Kind="Program" />

void Main()
{
	var ranges = new List<(long,long)>();
	long sum = 0;
	var maxDigits = 0;

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
								maxDigits = Math.Max(maxDigits, (int)Math.Floor(Math.Log10(range[1]) + 1));
								return (range[0], range[1]);
							 })
							 .ToList();
	}
	//ranges.Dump();
	//maxDigits.Dump();
	
	var modulusDict = new Dictionary<int, List<long>>();
	// Pre calc a dictionary of moduli, 
	// 10 is the largest # of digits in the input (could be set after going through the input)
	for (int i = 2; i <= maxDigits; i++)
	{
		var moduli = new List<long>();
		for (int j = i; j > 1; j--)
		{
			// Only interested in factors
			if (i%j == 0)
			{
				long modulus = 0;
				var power = 0;
				var zeros = i/j-1;
				for (int k = 0; k < j; k++)
				{
					modulus += (long)Math.Pow(10, power);
					power += zeros + 1;
				}
				
				moduli.Add(modulus);
			}
		}
		modulusDict.Add(i, moduli);
	}
	//modulusDict.Dump();
	
	foreach (var range in ranges)
	{
		//range.Dump();
		for(long i = range.Item1; i <= range.Item2; i++)
		{
			var digits = (int)Math.Floor(Math.Log10(i) + 1);
			if (digits == 1)
			{
				continue;
			}

			var moduli = modulusDict[digits];
			//i.Dump();
			//digits.Dump();
			//modulus.Dump();
			//(i % modulus).Dump();
			foreach (var modulus in moduli)
			{
				if (i % modulus == 0)
				{
					//i.Dump();
					//modulus.Dump();
					sum += i;
					break;
				}
			}
		}
	}
	sum.Dump();
}


// You can define other methods, fields, classes and namespaces here