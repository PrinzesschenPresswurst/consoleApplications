namespace FountainOfObjects;

public class Game
{
    public static Player GamePlayer { get; set; } 
    public static Map GameMap { get; set; } 
    public static Monster GameMonster { get; set; } 
    
    public Game()
    {
        GamePlayer = new Player();
        
        string mapSize = AskMapSize();
        GameMap = new Map(mapSize);
        GameMonster = new Monster();
        GamePlayer.BackToStart();
        
        DisplayIntro();
        GameMap.DisplayMap();
    }
    
    private string AskMapSize()
    {
        Console.WriteLine($"{GamePlayer.PlayerName}, how big should the cave be?");
        Console.WriteLine("small, normal, big?");
        int size;
        string input;
        do
        {
            input = Console.ReadLine();
            size = input switch
            {
                "small" => 4,
                "normal" => 6,
                "big" => 8,
                _ => 0
            }; 
        } while (size == 0);
        return input;
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