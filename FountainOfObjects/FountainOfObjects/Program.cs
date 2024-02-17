using FountainOfObjects;

Console.Title = "Fountain of Objects";

Game newGame = new Game();

while (true)
{
    newGame.RunRound();
    if (Game.GamePlayer.HasWonGame)
        break;
}

Console.Clear();
Console.WriteLine("You are a hero. You made it.");
Console.WriteLine("Press any key to take a deserved break.");
Console.ReadKey();