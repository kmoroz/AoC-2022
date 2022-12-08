var path = await Utils.GetInput(8);
var map = File.ReadAllText(path).Split('\n').SkipLast(1).ToArray();
int[] limits = { 0, map.Length - 1, map.First().Length - 1 };
int rowLength = map.Length - 1;
var colLength = map.First().Length - 1;

int calculateExterior()
{
    int size = map.Length * 2 + (map.First().Length - 2) * 2;

    return size;
}

int calculateInterior()
{
    int total = 0;

    for (int x = 1; x < rowLength; x++)
    {
        var row = map[x];

        for (int y = 1; y < colLength; y++)
        {
            List<List<int>> neighbours = new List<List<int>>();
            neighbours.Add(findTopNeighbours(x, y));
            neighbours.Add(findBottomNeighbours(x, y));
            //right neighbours
            neighbours.Add(row.Substring(y + 1).ToCharArray().Select(i => int.Parse(i.ToString())).ToList());
            //left neighbours
            neighbours.Add(row.Substring(0, y - 0).ToCharArray().Select(i => int.Parse(i.ToString())).ToList());
            var coordinate = int.Parse(map[x][y].ToString());
            if (isVisible(neighbours, coordinate))
                total += 1;
        }
    }
    return total;
}

//part one
Console.WriteLine(calculateInterior() + calculateExterior());

bool isVisible(List<List<int>> neighbours, int i)
{
    return neighbours.Any(neighbour => !neighbour.Any(tree => tree >= i));
}

List<int> findTopNeighbours(int x, int y)
{
    List<int> neighbours = new List<int>();

    for (int i = x - 1; i >= 0; i--)
    {
        neighbours.Add(int.Parse(map[i][y].ToString()));
    }

    return neighbours;
}

List<int> findBottomNeighbours(int x, int y)
{
    List<int> neighbours = new List<int>();

    for (int i = x + 1; i <= rowLength; i++)
    {
        neighbours.Add(int.Parse(map[i][y].ToString()));
    }

    return neighbours;
}

int calculateScenicScore(int i, List<List<int>> neighbours)
{
    int total = 1;
    int score = 0;

    foreach (var neighbour in neighbours)
    {
        score = 0;
        foreach (var tree in neighbour)
        {
            if (tree < i)
                score += 1;
            else
            {
                score += 1;
                break;
            }
        }
        total *= score;
    }
    return total;
}

int findBestScenicScore()
{
    List<int> scores = new List<int>();

    for (int x = 1; x < rowLength; x++)
    {
        var row = map[x];

        for (int y = 1; y < colLength; y++)
        {
            List<List<int>> neighbours = new List<List<int>>();
            neighbours.Add(findTopNeighbours(x, y));
            neighbours.Add(findBottomNeighbours(x, y));
            //right neighbours
            neighbours.Add(row.Substring(y + 1).ToCharArray().Select(i => int.Parse(i.ToString())).ToList());
            //left neighbours
            neighbours.Add(row.Substring(0, y - 0).ToCharArray().Select(i => int.Parse(i.ToString())).Reverse().ToList());
            var coordinate = int.Parse(map[x][y].ToString());
            scores.Add(calculateScenicScore(coordinate, neighbours));
        }
    }
    return scores.Max();
}

//part two
Console.WriteLine(findBestScenicScore());