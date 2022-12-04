var path = await Utils.GetInput(4);

int runningSum = 0;
foreach(var line in File.ReadLines(path))
{
    List<int> ranges = line.Split(',','-').Select(int.Parse).ToList<int>();
    var firstSection = Enumerable.Range(ranges[0], ranges[1] - ranges[0] + 1);
    var secondSection = Enumerable.Range(ranges[2], ranges[3] - ranges[2] + 1);
    if (secondSection.All(i => firstSection.Contains(i)) 
        || firstSection.All(i => secondSection.Contains(i)))
        runningSum += 1;
}

//first part
Console.WriteLine(runningSum);

runningSum = 0;
foreach (var line in File.ReadLines(path))
{
    List<int> ranges = line.Split(',', '-').Select(int.Parse).ToList<int>();
    var firstSection = Enumerable.Range(ranges[0], ranges[1] - ranges[0] + 1);
    var secondSection = Enumerable.Range(ranges[2], ranges[3] - ranges[2] + 1);
    if (secondSection.Any(i => firstSection.Contains(i)))
        runningSum += 1;
}

//second part
Console.WriteLine(runningSum);