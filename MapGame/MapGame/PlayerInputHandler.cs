namespace MapGame;

public class PlayerInputHandler(MapHandler mapHandler, Player player)
{
    private MapHandler MapHandler { get; set; } = mapHandler;
    private Player Player { get; set; } = player;
    
    private readonly int[,] _direction = new int[,] { {0, 0} };
    
    public void ListenToInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        
        if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            _direction[0,0] = 0;
            _direction[0,1] = -1;
        }
        if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            _direction[0,0] = 0;
            _direction[0,1] = 1;
        }
        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            _direction[0,0] = -1;
            _direction[0,1] = 0;
        }
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            _direction[0,0] = 1;
            _direction[0,1] = 0;
        }
        char target = MapHandler.SomeMapArray[Player.PlayerPosition[0, 0] + _direction[0, 0],
            Player.PlayerPosition[0, 1] + _direction[0, 1]];
        EvaluateAction(target);
    }

    private void EvaluateAction(char target)
    {
        switch (target)
        {
            case ' ':
                MovePlayer();
                break;
            case '1':
            case '2':
                SwitchMap(target);
                break;
            case 'E':
                Console.WriteLine("you engage in combat");
                break;
        }
    }

    private void MovePlayer()
    {
       MapHandler.SomeMapArray[Player.PlayerPosition[0,0], Player.PlayerPosition[0,1]] = ' '; 
       Player.PlayerPosition[0, 0] += _direction[0,0];
       Player.PlayerPosition[0, 1] += _direction[0,1];
       MapHandler.DisplayMap();
    }

    private void SwitchMap(char target)
    {
        switch (target)
        {
            case '1' when MapHandler.CurrentMap.MapToGoTo1 != null:
                MapHandler.InitializeMapFromObject(MapHandler.CurrentMap.MapToGoTo1);
                break;
            case '2' when MapHandler.CurrentMap.MapToGoTo2 != null:
                MapHandler.InitializeMapFromObject(MapHandler.CurrentMap.MapToGoTo2);
                break;
        }
        MapHandler.DisplayMap();
    }
}                   