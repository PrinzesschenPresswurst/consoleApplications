namespace FountainOfObjects;

public interface IPlayerCommand
{
    public void Execute();
}

public interface IPlayerMoveCommand
{
    public void Execute(string direction);
}