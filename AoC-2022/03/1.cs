var path = await Utils.GetInput(3);

int runningSum = 0;
foreach(var line in File.ReadLines(path))
{
    string firstCompartment = line.Substring(0, line.Length / 2);
    string secondCompartment = line.Substring(line.Length / 2);
    var common = firstCompartment.Intersect(secondCompartment);
    foreach (char c in common)
        runningSum += calculatePriority(c);
}

static int calculatePriority(char c)
{
    if (char.IsLower(c))
        return char.ToUpper(c) - 64;
    return (c - 38);
}

//First part
Console.WriteLine(runningSum);


var group = new List<string>();
runningSum = 0;

foreach (var line in File.ReadLines(path))
{
    group.Add(line);

    if (group.Count == 3)
    {
        runningSum += calculatePriority(findBadge(group));
        group.Clear();
    }
}

static char findBadge(List <string> group)
{
    var firstTwoCommon = string.Concat(group.First().Intersect(group[1]));
    var common = firstTwoCommon.Intersect(group.Last());
    return common.First();
}

//Second part
Console.WriteLine(runningSum);