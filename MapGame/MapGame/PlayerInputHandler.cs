namespace MapGame;

public class PlayerInputHandler(MapHandler mapHandler, Player player)
{
    private MapHandler MapHandler { get; set; } = mapHandler;
    private Player Player { get; set; } = player;
    
    int[,] direction = new int[,] { {0, 0} };
    
    public void ListenToInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        
        
        if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            direction[0,0] = 0;
            direction[0,1] = -1;
        }
        if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            direction[0,0] = 0;
            direction[0,1] = 1;
        }
        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            direction[0,0] = -1;
            direction[0,1] = 0;
        }
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            direction[0,0] = 1;
            direction[0,1] = 0;
        }
        char target = MapHandler.SomeMapArray[Player.PlayerPosition[0, 0] + direction[0, 0],
            Player.PlayerPosition[0, 1] + direction[0, 1]];
        EvaluateAction(target);
    }

    private void EvaluateAction(char target)
    {
        switch (target)
        {
            case ' ':
                MovePlayer();
                break;
            case 'X':
                EnterHouse();
                break;
            case 'E':
                Console.WriteLine("you engage in combat");
                break;
        }
    }

    private void MovePlayer()
    {
       MapHandler.SomeMapArray[Player.PlayerPosition[0,0], Player.PlayerPosition[0,1]] = ' '; 
       Player.PlayerPosition[0, 0] += direction[0,0];
       Player.PlayerPosition[0, 1] += direction[0,1];
       MapHandler.DisplayMap();
    }

    private void EnterHouse()
    {
        Console.WriteLine("you enter the house");
        MapHandler.InitializeMapFromObject(new MapHouse());
        MapHandler.DisplayMap();
        // load a new map
        // place new playerposition (maps should be objects with start pos per map?)
    }
}                   