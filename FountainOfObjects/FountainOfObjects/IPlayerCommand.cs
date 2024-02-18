namespace FountainOfObjects;

public interface IPlayerCommand
{
    public void Execute(Player player);
}

public interface IPlayerMoveCommand
{
    public void Execute(Player player, string direction);
}