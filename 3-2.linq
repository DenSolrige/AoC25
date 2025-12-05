<Query Kind="Program" />

void Main()
{
	long sum = 0;
	var banks = new List<string>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-3.txt"))
	{
		banks.Add(line);
	}
	//banks.Dump();
	foreach (string bank in banks)
	{
		var maxJolt = "";
		var availableLeftmostIndex = 0;
		for (int j = 12; j > 0; j--)
		{
			var leftMaxIndex = bank.Length - j;
			for (int i = bank.Length - j; i >= availableLeftmostIndex; i--)
			{
				if (bank[i] >= bank[leftMaxIndex])
				{
					leftMaxIndex = i;
				}
			}
			availableLeftmostIndex = leftMaxIndex + 1;
			maxJolt += bank[leftMaxIndex];
		}
		
		//maxJolt.Dump();
		sum += long.Parse(maxJolt);
	}
	
	sum.Dump();
}


// You can define other methods, fields, classes and namespaces here