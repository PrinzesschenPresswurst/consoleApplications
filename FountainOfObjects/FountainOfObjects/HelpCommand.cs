namespace FountainOfObjects;

public class HelpCommand : IPlayerCommand
{
    public void Execute()
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