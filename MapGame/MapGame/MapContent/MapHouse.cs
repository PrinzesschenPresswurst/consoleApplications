namespace MapGame;

public class MapHouse : BaseMap
{
    public MapHouse()
    {
        PlayerStartPos  = new int[,] { {8, 9} };
        MapStoryText = " On first glance you can see only two beds, nothing special...";
        MapString = """
                    ####################
                    #      [   ]       #
                    #                  #
                    #  +----+  +----+  #
                    #  |    |  |    |  #
                    #  |____|  |____|  #
                    #                  #
                    #   ____    ____   #
                    #  |____|  |____|  #
                    #########11##########
                    """;
        InitializeMapArray();
    }
    
    public override void LinkMaps()
    {
        MapToGoTo1 = MapLinker.Forest;
        MapToGoTo2 = null;
    }
}