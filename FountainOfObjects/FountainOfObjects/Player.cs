namespace FountainOfObjects;

public class Player
{
    public string PlayerName { get; set; }
    public int ArrowAmount { get; set; }
    public Room CurrentRoom { get; set; } = new Room(0,0);
    public bool HasEnabledFountain { get; set; }
    public bool HasWonGame { get; set; } 
    private IPlayerCommand? Command { get; set; } 
    private IPlayerMoveCommand? MoveCommand { get; set; }

    public Player()
    {
        PlayerName = GetPlayerName();
        ArrowAmount = 3;
    }

    // Get Player Name -----------------------------------------
    private string GetPlayerName()
    {
        Console.WriteLine("Hello player, enter your name.");
        string? name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Input a name.");
            name = Console.ReadLine();
        }

        Console.Clear();
        return name;
    }
    
    public void DisplayArrows()
    {
        Console.WriteLine($"You have still {ArrowAmount} arrows left.");
    }

    // Get Player Action -----------------------------------------
    public void GetAction()
    {
        if (CurrentRoom.CheckIfHasMonster())
        {
            BackToStart();
            return;
        }
        
        Console.WriteLine("What do you want to do?");
        string? input = Console.ReadLine();
        
        HandleMovement(input);
        HandleCommand(input);
    }

    private void HandleMovement(string? input)
    {
        MoveCommand = new MoveCommand();
        
        if (input == "move east" || input == "e")
            MoveCommand.Execute("east");
        if (input == "move west" || input == "w")
            MoveCommand.Execute("west");
        if (input == "move north" || input == "n")
            MoveCommand.Execute("north");
        if (input == "move south" || input == "s")
            MoveCommand.Execute("south");
    }

    private void HandleCommand(string? input)
    {
        if (input == "oklahoma")
            Command = new FountainCommand();
        else if (input == "help")
            Command = new HelpCommand();
        else if (input == "map")
            Command = new MapCommand();
        else if (input == "shoot")
            Command = new ShootCommand();
        else if (input == "cheat")
            Command = new CheatCommand();
        else return;
        
        Command.Execute();
    }

    public void BackToStart()
    {
        CurrentRoom.RoomRow = 0;
        CurrentRoom.RoomColumn = 0;
    }
}