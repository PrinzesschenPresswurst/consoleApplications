namespace MapGame;

public class GameStateHandler
{
    private Player Player { get; set; }
    public BaseMap CurrentMap = new BaseMap();
    
    public GameStateHandler(Player player)
    {
        Player = player;
        MapLinker.LinkUpMaps();
        InitializeMap(MapLinker.Forest);
    }
    
    public void InitializeMap (BaseMap map)
    {
        CurrentMap = map;
        Player.PlayerPosition = map.PlayerStartPos;
    }
    
    private void PlacePlayer()
    {
        CurrentMap.MapArray[Player.PlayerPosition[0,0],Player.PlayerPosition[0,1]] = Player.PlayerChar;
    }

    public void DisplayGame()
    {
        Console.SetCursorPosition(0, 0); 
        Console.CursorVisible = false; // hide weirdo flickering
        DisplayHud();
        DisplayMap();
        DisplayNarrativeText();
        Console.CursorVisible = true;
    }
    
    private void DisplayMap()
    {
        PlacePlayer();
        
        for (int i = 0; i < CurrentMap.MapArray.GetLength(0); i++)
        {
            for (int j = 0; j < CurrentMap.MapArray.GetLength(1); j++)
            {
                switch (CurrentMap.MapArray[i, j])
                {
                    case 'E':
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(CurrentMap.MapArray[i,j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '1':
                    case '2':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('X');
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.Write(CurrentMap.MapArray[i,j]);
                        break;
                }
            }
            Console.WriteLine();
        }
    }

    private void DisplayNarrativeText()
    {
        Console.WriteLine();
        Console.WriteLine(CurrentMap.MapStoryText);
    }

    private void DisplayHud()
    {
        if (Player.PlayerHealth < 1)
        {
            Console.WriteLine("you are ded");
            return;
        }
           
        string fullHeart = "\u2665";
        string emptyHeart = "\u2661";
        int totalHealth = 3;
        int lostHealth = totalHealth - Player.PlayerHealth;

        for (int i = 0; i < Player.PlayerHealth; i++)
        {
            Console.Write(fullHeart);
        }
        for (int i = 0; i < lostHealth; i++)
        {
            Console.Write(emptyHeart);
        }
        Console.WriteLine();
    }
}