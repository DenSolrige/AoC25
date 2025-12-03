<Query Kind="Program" />

void Main()
{
	var zeroHits = 0;
	int dial = 50;
	// 6530
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-1.txt"))
	{
	    int turnAmount = (Int32.Parse(line.Substring(1))) * (line[0] == 'L' ? -1 : 1);
		("turn amount " + turnAmount).Dump();
		int fullTurns = Math.Abs(turnAmount / 100);
		("fullTurns " + fullTurns).Dump();
		zeroHits += fullTurns;
		turnAmount = turnAmount % 100;
		("last dial " + dial).Dump();
		("dial * lastDial less than zero " + ((dial + turnAmount) % 100 * dial < 0)).Dump();
		
		if (dial == 0 || (dial + turnAmount) % 100 * dial < 0 || dial + turnAmount > 100 || dial + turnAmount < -100)
		{
			zeroHits++;
		}
		dial = (dial + turnAmount) % 100;
		("new dial " + dial + "\n").Dump();
	}
	zeroHits.Dump();
}

// You can define other methods, fields, classes and namespaces here