
using AoC_2022._05;

var path = await Utils.GetInput(5);

var file = File.ReadAllText(path).Replace("[", " ").Replace("]", " ").Split("\n\n");
var stackInstructions = file[0].Split('\n').SkipLast(1);
var movingInstructions = file[1].Replace("move ", String.Empty).Replace(" from", String.Empty).Replace(" to", String.Empty).Split('\n').SkipLast(1);
List<List<int>> movingCoordinates = new List<List<int>>();

foreach(var row in movingInstructions)
{
    var temp = row.Split(" ").Select(int.Parse).ToList<int>();
    movingCoordinates.Add(temp);
}

var colLength = stackInstructions.Max(row => row.Length);
var rowLength = stackInstructions.Count();

var stacks = createStacks();
CrateMover.CrateMover9000(movingCoordinates, stacks);

//part one
foreach(var stack in stacks)
{
    Console.Write(stack.Crates[0]);
}
Console.Write('\n');


stacks = createStacks();
CrateMover.CrateMover9001(movingCoordinates, stacks); ;

//part two
foreach (var stack in stacks)
{
    Console.Write(stack.Crates[0]);
}

List<Stack> createStacks()
{
    var stacks = new List<Stack>();
    for (var col = 0; col < colLength; col++)
    {
        var newStack = new Stack();

        for (var row = 0; row < rowLength; row++)
        {
            var location = stackInstructions.ElementAt(row)[col];
            if (Char.IsLetter(stackInstructions.ElementAt(row)[col]))
                newStack.Crates.Add(stackInstructions.ElementAt(row)[col]);
        }
        if (newStack.Crates.Count > 0)
            stacks.Add(newStack);
    }
    return stacks;
}