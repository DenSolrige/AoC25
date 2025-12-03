<Query Kind="Program" />

void Main()
{
	var sum = 0;
	var banks = new List<string>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-3.txt"))
	{
		banks.Add(line);
	}
	//banks.Dump();
	foreach (string bank in banks)
	{
		var leftMaxIndex = bank.Length - 2;
		for (int i = bank.Length - 2; i >= 0; i--)
		{
			if (bank[i] >= bank[leftMaxIndex])
			{
				leftMaxIndex = i;
			}
		}
		var rightMaxIndex = leftMaxIndex + 1;
		for (int i = leftMaxIndex + 1; i < bank.Length; i++)
		{
			if (bank[i] >= bank[rightMaxIndex])
			{
				rightMaxIndex = i;
			}
		}
		var maxJolt = Int32.Parse(""+bank[leftMaxIndex] + bank[rightMaxIndex]);//.Dump();
		sum += maxJolt;
	}
	
	sum.Dump();
}


// You can define other methods, fields, classes and namespaces here