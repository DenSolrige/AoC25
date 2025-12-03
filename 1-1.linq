<Query Kind="Program" />

void Main()
{
	var zeroHits = 0;
	var dial = 50;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-1.txt"))
	{
	    var turnAmount = (Int32.Parse(line.Substring(1)) % 100) * (line[0] == 'L' ? -1 : 1);
		//("turn amount" + turnAmount).Dump();
		dial = (dial + turnAmount) % 100;
		//("dial " + dial).Dump();
		if (dial == 0)
		{
			zeroHits++;
		}
	}
	zeroHits.Dump();
}

// You can define other methods, fields, classes and namespaces here