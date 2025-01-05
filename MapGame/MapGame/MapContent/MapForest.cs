namespace MapGame;

public  class MapForest : BaseMap
{
    public MapForest()
    { 
        PlayerStartPos = new int[,] { { 2, 2 } };
        MapStoryText = "you can see a cabin. Some enemies are patrolling around it. There might be a secret in there.";
        MapString = """
                    ########################################
                    #                                      #
                    #     ^       ^       ^       ^        #
                    #    ^^^     ^^^     ^^^     ^^^       #
                    #     |       |       |       |        #
                    #                                      #
                    #    E                      E          #
                    #          _______                     2
                    #         /       \                    2
                    #        /         \                   #
                    #       +-----------+      ^       ^   #
                    #       |   [  ]    |     ^^^     ^^^  #
                    #       |    __     |      |       |   #
                    #       |   |  |    |                  #
                    #       |___|11|____|                  #
                    #                                      #
                    #     ^       ^                        #
                    #    ^^^     ^^^                       #
                    #     |       |                E       #
                    #                                      #
                    #########################################
                    """;
        InitializeMapArray();
    }
    public override void LinkMaps()
    {
        MapToGoTo1 = MapLinker.House;
        MapToGoTo2 = MapLinker.ForestWell;
    }
}