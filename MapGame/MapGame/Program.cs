
using MapGame;

Console.Title = "Map Game";


Player player = new Player();
MapHandler mapHandler = new MapHandler(player);
PlayerInputHandler playerInputHandler = new PlayerInputHandler(mapHandler, player);
mapHandler.DisplayMap();


while (true)
    playerInputHandler.ListenToInput();


Console.ReadKey();