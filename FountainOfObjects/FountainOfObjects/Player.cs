namespace FountainOfObjects;

public class Player
{
    public string Playername { get; set; }
    public Room CurrentRoom { get; set; }
    public bool HasEnabledFountain { get; set; } = false;
    public bool HasWonGame { get; set; } = false;

    public Player(Game game)
    {
        Playername = GetPlayerName();
        CurrentRoom = Game.GameMap.StartRoom;
    }
    
    
    // Get Player Name -----------------------------------------
    private string GetPlayerName()
    {
        Console.WriteLine("Hello player, enter your name.");
        string name = Console.ReadLine();
        
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Input a name.");
            name = Console.ReadLine();
        } 
        Console.Clear();
        return name;
    }

    // Get Player Action -----------------------------------------
    public void GetAction()
    {
        Console.WriteLine("What do you want to do?");
        string input = Console.ReadLine();
        if (input == "move east" || input == "e")
        {
            if (CurrentRoom.RoomColumn < 3)
                CurrentRoom.RoomColumn += 1;   
            else HandleWalls();
        }
        
        if (input == "move west"|| input == "w")
        {
            if (CurrentRoom.RoomColumn > 0)
                CurrentRoom.RoomColumn -= 1;   
            else HandleWalls();
        }
        
        if (input == "move north"|| input == "n")
        {
            if (CurrentRoom.CheckIfEntrance() && !HasEnabledFountain)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You cant abandon your quest yet.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (CurrentRoom.CheckIfEntrance() && HasEnabledFountain)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You made it.");
                HasWonGame = true;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (CurrentRoom.RoomRow > 0)
                CurrentRoom.RoomRow -= 1;   
            else HandleWalls();
        }
        
        if (input == "move south"|| input == "s")
        {
            if (CurrentRoom.RoomRow < 3)
                CurrentRoom.RoomRow += 1;   
            else HandleWalls();
        }

        if (input == "oklahoma")
        {
            if (CurrentRoom.CheckIfFountain() && !HasEnabledFountain)
            {
                HasEnabledFountain = true;
                Console.WriteLine("You hear a loud click");
            }
            else if (CurrentRoom.CheckIfFountain() && HasEnabledFountain)
                Console.WriteLine("The fountain is already enabled");
                
        }
    }

    // Player Bumps in Wall -----------------------------------------
    public void HandleWalls()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You bump into a cave wall.");
        Console.ForegroundColor = ConsoleColor.White;
        
    }
}