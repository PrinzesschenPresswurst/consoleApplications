using FountainOfObjects;

Console.Title = "Fountain of Objects";

Game newGame = new Game();
newGame.DisplayIntro();

while (true)
{
    newGame.RunRound();
    if (Game.GamePlayer.HasWonGame)
        break;
}

Console.ReadKey();