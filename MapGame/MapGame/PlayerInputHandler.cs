namespace MapGame;

public class PlayerInputHandler(GameStateHandler gameStateHandler, Player player)
{
    private GameStateHandler GameStateHandler { get; set; } = gameStateHandler;
    private Player Player { get; set; } = player;
    
    private readonly int[,] _direction = new int[,] { {0, 0} };
    
    public void ListenToInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        // Default: Reset _direction to no movement
        _direction[0, 0] = 0;
        _direction[0, 1] = 0;
        
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

        int[,] targetPosition = { { Player.PlayerPosition[0, 0] + _direction[0, 0], Player.PlayerPosition[0, 1] + _direction[0, 1] } };
        char target = GameStateHandler.CurrentMap.MapArray[Player.PlayerPosition[0, 0] + _direction[0, 0],
            Player.PlayerPosition[0, 1] + _direction[0, 1]];
        EvaluateAction(target, targetPosition);
    }

    private void EvaluateAction(char target, int[,]targetPosition)
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
                HandleCombat(targetPosition);
                break;
        }
    }

    private void MovePlayer()
    {
       GameStateHandler.CurrentMap.MapArray[Player.PlayerPosition[0,0], Player.PlayerPosition[0,1]] = ' '; 
       Player.PlayerPosition[0, 0] += _direction[0,0];
       Player.PlayerPosition[0, 1] += _direction[0,1];
       GameStateHandler.DisplayGame();
    }

    private void SwitchMap(char target)
    {
        switch (target)
        {
            case '1' when GameStateHandler.CurrentMap.MapToGoTo1 != null:
               GameStateHandler.InitializeMap(GameStateHandler.CurrentMap.MapToGoTo1);
                break;
            case '2' when GameStateHandler.CurrentMap.MapToGoTo2 != null:
              GameStateHandler.InitializeMap(GameStateHandler.CurrentMap.MapToGoTo2);
                break;
        }
        GameStateHandler.DisplayGame();
    }

    private void HandleCombat(int [,]targetPosition)
    {
        Combat combat = new Combat();
        combat.RunCombat();
        
        if (combat.PlayerWonGame)
            GameStateHandler.CurrentMap.MapArray[targetPosition[0,0],targetPosition[0,1]] = ' ';

        if (!combat.PlayerWonGame)
            Player.PlayerHealth--;
           
        GameStateHandler.DisplayGame();
    }
}                   