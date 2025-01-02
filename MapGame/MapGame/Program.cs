
using MapGame;

Console.Title = "Map Game";


Player player = new Player();
Map map = new Map(player);
PlayerInputHandler playerInputHandler = new PlayerInputHandler(map, player);
map.DisplayMap();


while (true)
    playerInputHandler.ListenToInput();


Console.ReadKey();