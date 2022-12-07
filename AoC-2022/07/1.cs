using AoC_2022._07;

var path = await Utils.GetInput(7);
var output = File.ReadAllText(path).Split('\n').SkipLast(1).ToArray();
var lastLine = output.Last();
var rootDir = new AOCDirectory("/", null);

const string CD = "cd";
const string LS = "ls";
const string DIR = "dir";

recordAOCDirectory(rootDir, output[1..]);

AOCDirectory recordAOCDirectory(AOCDirectory currentDir, string[] output)
{
    if (output.Length != 0)
    {
        var tokens = output.First().Split(" ");
        if (tokens.Contains(CD))
        {
            if (currentDir.Children.ContainsKey(tokens.Last()))
                return recordAOCDirectory(currentDir.Children[tokens.Last()], output[1..]);
            if (tokens.Last() == "..")
                return recordAOCDirectory(currentDir.Parent, output[1..]);
        }
        else if (tokens.Contains(DIR))
            currentDir.Push(new AOCDirectory(tokens.Last(), currentDir));
        else if (!tokens.Contains(LS))
            currentDir.Push(tokens.Last(), int.Parse(tokens.First()));
        return recordAOCDirectory(currentDir, output[1..]);
    }
    return rootDir;
}


var smallDirs = new List<int>();
FindSmallerDirs(rootDir);

List<int> FindSmallerDirs(AOCDirectory dir)
{
    if (dir.Size <= 100000)
        smallDirs.Add(dir.Size);
    if (dir.Children.Any())
    {
        foreach (var child in dir.Children.Values)
            FindSmallerDirs(child);
    }
    return smallDirs;
}

//part one
Console.WriteLine(smallDirs.Sum());

const int TotalDiscSpace = 70000000;
const int SpaceRequired = 30000000;
int unusedSpace = TotalDiscSpace - rootDir.Size;
int minAmountToFreeUp = SpaceRequired - unusedSpace;
var candidatesForDeletion = new List<int>();
FindCandidatesForDeletion(rootDir);

List<int> FindCandidatesForDeletion(AOCDirectory dir)
{
    if (dir.Size >= minAmountToFreeUp)
        candidatesForDeletion.Add(dir.Size);
    if (dir.Children.Any())
    {
        foreach (var child in dir.Children.Values)
            FindCandidatesForDeletion(child);
    }
    return candidatesForDeletion;
}

//part two
Console.WriteLine(candidatesForDeletion.Min());