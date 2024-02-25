namespace FountainOfObjects;

public class Game
{
    public static Player? GamePlayer { get; private set; } 
    public static Map? GameMap { get; private set; } 
    
    public Game()
    {
        GamePlayer = new Player();
        GameMap = new Map();
        DisplayIntro();
        GameMap.DisplayMap();
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
    
    private void DisplayIntro()
    {
        Console.WriteLine("You open the map the mysterious man gave you:");
        Console.WriteLine("You take in all information as it is dark in the cave.");
        Console.WriteLine($"Good luck, {Game.GamePlayer.PlayerName}");
    }
}