using System.Text;
using MapGame;

Console.Title = "Map Game";
Console.OutputEncoding = Encoding.UTF8;
Player player = new Player();
GameStateHandler gameStateHandler = new GameStateHandler(player);
PlayerInputHandler playerInputHandler = new PlayerInputHandler(gameStateHandler, player);
gameStateHandler.DisplayGame();

while (true)
    playerInputHandler.ListenToInput();

Console.ReadKey();