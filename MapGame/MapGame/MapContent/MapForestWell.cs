namespace MapGame;

public class MapForestWell : BaseMap
{
    public MapForestWell()
    {
        PlayerStartPos  = new int[,] { {6, 1} };
        MapStoryText = "that is odd, you feel like you have already been here...";
        MapString = """
                    ########################################
                    #                                      #
                    #     ^       ^       ^       ^        #
                    #    ^^^     ^^^     ^^^     ^^^       #
                    #     |       |       |       |        #
                    #                                      #
                    1                                      #
                    1                                      #
                    #            ______                    #
                    #           /      \           E       #
                    #          /________\                  #
                    #     E       [  ]                     #
                    #           |      |      ^       ^    #
                    #            ------      ^^^     ^^^   #
                    #          E              |       |    #
                    #                                      #
                    #     ^       ^        E               #
                    #    ^^^     ^^^                       #
                    #     |       |                        #
                    #                                      #
                    #########################################
                    """;
        InitializeMapArray();
    }
    public override void LinkMaps()
    {
        MapToGoTo1 = MapLinker.Forest;
        MapToGoTo2 = null;
    }
}