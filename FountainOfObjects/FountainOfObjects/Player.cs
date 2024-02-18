namespace FountainOfObjects;

public class Player
{
    private readonly Room _startRoom = new Room(0, 0);
    public string PlayerName { get; set; }
    public Room CurrentRoom { get; set; } = new Room(0, 0);
    public bool HasEnabledFountain { get; set; } = false;
    public bool HasWonGame { get; set; } = false;

    public Player(Game game)
    {
        PlayerName = GetPlayerName();
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
        if (CurrentRoom.CheckIfHasMonster())
        {
            CurrentRoom.RoomRow = _startRoom.RoomRow;
            CurrentRoom.RoomColumn = _startRoom.RoomColumn;
            return;
        }
        
        Console.WriteLine("What do you want to do?");
        string input = Console.ReadLine();
        
        // movement
        if (input == "move east" || input == "e")
        {
            if (CurrentRoom.RoomColumn < 3)
                CurrentRoom.RoomColumn += 1;
            else HandleWalls();
        }

        if (input == "move west" || input == "w")
        {
            if (CurrentRoom.RoomColumn > 0)
                CurrentRoom.RoomColumn -= 1;
            else HandleWalls();
        }

        if (input == "move north" || input == "n")
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

        if (input == "move south" || input == "s")
        {
            if (CurrentRoom.RoomRow < 3)
                CurrentRoom.RoomRow += 1;
            else HandleWalls();
        }

        // fountain

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

        // other

        if (input == "help")
        {
            DisplayHelp();
        }

        if (input == "map")
        {
            if (CurrentRoom.CheckIfEntrance())
            {
                HasEnabledFountain = true;
                Game.GameMap.DisplayMap();
            }
            else
                Console.WriteLine("It is too dark to see anything.");
        }
    }

    // Player Bumps in Wall -----------------------------------------
    private void HandleWalls()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You bump into a cave wall.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Get Help
    private void DisplayHelp()
    {
        string help = """

                      ------------------------------------------------------------------------
                      Movement
                      You can move around the cavern.
                      Just type "move north", "move east", "move west", "move south".

                      Fountain
                      Once you found the fountain you have to enable it typing the magic word.
                      If you dont remember the magic word, consult your map.
                      
                      Monsters
                      You can sense monsters in an adjacent room.
                      If you run into one you will teleport to the cave entrance.

                      Map
                      Only at the cave entrance is enough light to look at the map.
                      Just type "map".
                      ------------------------------------------------------------------------

                      """;
        Console.WriteLine(help);
    }
}