<Query Kind="Program" />

void Main()
{
	var lines = new List<List<long>>();
	var operands = new List<string>();
	long sum = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-6.txt"))
	{
		var splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
		//splitLine.Dump();
		if (splitLine[0] == "+" || splitLine[0] == "*")
		{
			operands = splitLine;
		}
		else 
		{
			lines.Add(splitLine.Select(x => long.Parse(x)).ToList());
		}
	}
	//lines.Dump();
	//operands.Dump();
	for (int i = 0; i < lines[0].Count; i++)
	{
		if (operands[i] == "+")
		{
			foreach (var line in lines)
			{
				sum += line[i];
			}
		}
		else 
		{
			long product = 1;
			foreach (var line in lines)
			{
				product *= line[i];
			}
			sum += product;
		}
	}
	sum.Dump();
}


// You can define other methods, fields, classes and namespaces here