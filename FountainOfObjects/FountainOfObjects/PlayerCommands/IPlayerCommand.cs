namespace FountainOfObjects;

public interface IPlayerCommand
{
    public void Execute();
}

public interface IPlayerMoveCommand
{
    public void Execute(string direction);
}

public interface IMapSizeHandler
{
    public void SetupMap(Map map, int mapSize);
}