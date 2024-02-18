namespace FountainOfObjects;

public class Player
{
    private readonly Room _startRoom = new Room(0, 0);
    public string PlayerName { get; set; }
    public Room CurrentRoom { get; set; } = new Room(0, 0);
    public bool HasEnabledFountain { get; set; } = false;
    public bool HasWonGame { get; set; } = false;
    private IPlayerCommand? Command { get; set; } 
    private IPlayerMoveCommand? MoveCommand { get; set; }

    public Player()
    {
        PlayerName = GetPlayerName();
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
        else return;
        
        Command.Execute();
    }

    private void BackToStart()
    {
        CurrentRoom.RoomRow = _startRoom.RoomRow;
        CurrentRoom.RoomColumn = _startRoom.RoomColumn;
    }
}