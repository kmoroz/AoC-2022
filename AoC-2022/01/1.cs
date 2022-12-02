var path = await Utils.GetInput(1);

List<int> runningSum = new List<int>();
int runningCount = 0;

foreach(var line in File.ReadAllLines(path))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        runningSum.Add(runningCount);
        runningCount = 0;
    }
    else
    {
        runningCount += int.Parse(line);
    }
}

//Part 1
Console.WriteLine(runningSum.Max());

//Part 2
var result = runningSum.OrderByDescending(i => i).Take(3).Sum();
Console.WriteLine(result);