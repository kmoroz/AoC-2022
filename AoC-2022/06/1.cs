var path = await Utils.GetInput(6);

var datastreamBuffer = File.ReadAllText(path);
int packetLength = 4;
int messageLength = 14;

Console.WriteLine(findMarker());
Console.WriteLine(findMessage());


int findMarker()
{
    for (int i = 0; i < datastreamBuffer.Length; i++)
    {
        List<char> fourChars = datastreamBuffer.Substring(i, packetLength).ToList();
        bool areUnique = fourChars.Distinct().Count() == fourChars.Count();
        if (areUnique)
            return i + packetLength;
    }
    return 0;
}

int findMessage()
{
    for (int i = 0; i < datastreamBuffer.Length; i++)
    {
        List<char> fourChars = datastreamBuffer.Substring(i, messageLength).ToList();
        bool areUnique = fourChars.Distinct().Count() == fourChars.Count();
        if (areUnique)
            return i + messageLength;
    }
    return 0;
}