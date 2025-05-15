namespace MapGame;

public static class MapLinker
{
    public static readonly BaseMap Forest = new MapForest();
    public static readonly BaseMap House = new MapHouse();
    public static readonly BaseMap ForestWell = new MapForestWell();
    public static readonly BaseMap Beach = new MapBeach();
    
    public static void LinkUpMaps()
    {
        Forest.LinkMaps();
        House.LinkMaps();
        ForestWell.LinkMaps();
        Beach.LinkMaps();
    }
}