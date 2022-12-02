var path = await Utils.GetInput(2);

var yourChoices = new List<char> { 
'X', //rock/lose
'Y', //paper/draw
'Z' //scissors/win
};
var victoryOutcomes = new Dictionary<char, char>() {
    { 'A', 'Y'},
    { 'B', 'Z'},
    { 'C', 'X' }
};

var drawOutcomes = new Dictionary<char, char>() {
    { 'A', 'X'},
    { 'B', 'Y'},
    { 'C', 'Z' }
};

var game = new List<(char opponentsChoice, char yourChoice)>();

foreach(var line in File.ReadAllLines(path))
{
    game.Add((line.First(), line.Last()));
}

int totalScore = 0;
foreach(var round in game)
{
    if (victoryOutcomes[round.opponentsChoice] == round.yourChoice)
        totalScore += 6;
    else if (drawOutcomes[round.opponentsChoice] == round.yourChoice)
        totalScore += 3;
    totalScore += yourChoices.IndexOf(round.yourChoice) + 1;
}

//first part
Console.WriteLine(totalScore);

var newGame = new List<(char opponentsChoice, char desiredOutcome)>(game);
totalScore = 0;
const char Draw = 'Y';
const char Defeat = 'X';

var defeatOutcomes = new Dictionary<char, char>() {
    { 'A', 'Z'},
    { 'B', 'X'},
    { 'C', 'Y' }
};

foreach (var round in newGame)
{
    if (round.desiredOutcome == Draw)
        totalScore += yourChoices.IndexOf(drawOutcomes[round.opponentsChoice]) + 3;
    else if (round.desiredOutcome == Defeat)
        totalScore += yourChoices.IndexOf(defeatOutcomes[round.opponentsChoice]);
    else
        totalScore += yourChoices.IndexOf(victoryOutcomes[round.opponentsChoice]) + 6;
    totalScore += 1;
}

//second part
Console.WriteLine(totalScore);