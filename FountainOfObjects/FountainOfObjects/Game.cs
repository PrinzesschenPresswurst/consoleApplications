namespace FountainOfObjects;

public class Game
{
    public static Player GamePlayer { get; private set; } = new Player();
    public static Map GameMap { get; private set; } = new Map();
    private static DateTime MapEnterTime { get; set; } 
    private static DateTime MapExitTime { get; set; } 
    private static TimeSpan TimeSpentInCavern { get; set; }
    
    public Game()
    {
        GamePlayer = GamePlayer;
        GameMap = GameMap;
        MapEnterTime = DateTime.Now;
    }
    
    public void RunRound()
    {
        GivePlayerInfo();
        GamePlayer.GetAction();
    }
    
    private static void GivePlayerInfo()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"You are in a room at (row = {GamePlayer.CurrentRoom.RoomRow}, column = {GamePlayer.CurrentRoom.RoomColumn})");
        Console.WriteLine(GamePlayer.CurrentRoom.GetRoomText());
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    public void DisplayIntro()
    {
        Console.WriteLine("You open the map the mysterious man gave you:");
        Console.WriteLine("You take in all information as it is dark in the cave.");
        Console.WriteLine($"Good luck, {Game.GamePlayer.PlayerName}");
        GameMap.DisplayMap();
    }

    public static void EndGameWon()
    {
        GamePlayer.HasWonGame = true;
        GetTime();
        DisplayResult();
    }

    private static void GetTime()
    {
        MapExitTime = DateTime.Now;
        TimeSpentInCavern = MapExitTime - MapEnterTime;
    }

    private static void DisplayResult()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You are a hero. You made it.");
        Console.WriteLine($"You spent {TimeSpentInCavern.Minutes} minutes and {TimeSpentInCavern.Seconds} seconds in the cavern");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to take a deserved break.");
        
    }
}