<Query Kind="Program" />

void Main()
{
	var grid = new List<List<char>>();
	var accessibleRollCount = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2025-4.txt"))
	{
		grid.Add(line.ToCharArray().ToList());
	}
	//grid.Dump();
	var height = grid.Count;
	var width = grid[0].Count;
	var noMoreRollsCanBeRemoved = false;
	var lastAccessibleRollCount = 0;
	while (!noMoreRollsCanBeRemoved)
	{
		for (int y = 0; y < height; y++)
		{
			var yMin = Math.Max(0, y-1);
			var yMax = Math.Min(height-1, y+1);
			for (int x = 0; x < width; x++)
			{
				if (grid[y][x] != '@')
				{
					continue;
				}
				var xMin = Math.Max(0, x-1);
				var xMax = Math.Min(width-1, x+1);
				var rollCount = 0;
				for (int j = yMin; j <= yMax; j++)
				{
					for (int i = xMin; i <= xMax; i++)
					{
						if (j == y && i == x) 
						{
							continue;
						}
						if (grid[j][i] == '@')
						{
							rollCount++;
						}
					}
				}
				
				//rollCount.Dump();
				if (rollCount < 4)
				{
					grid[y][x] = 'x';
					accessibleRollCount++;
				}
			}
		}
		if (accessibleRollCount != lastAccessibleRollCount)
		{	
			lastAccessibleRollCount = accessibleRollCount;
		}
		else 
		{
			noMoreRollsCanBeRemoved = true;
		}
	}
	//grid.Dump();
	accessibleRollCount.Dump();
}


// You can define other methods, fields, classes and namespaces here