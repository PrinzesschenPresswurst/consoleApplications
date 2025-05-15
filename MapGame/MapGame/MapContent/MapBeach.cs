using MapGame.Exercises;

namespace MapGame;

public class MapBeach : BaseMap
{
    public MapBeach()
    { 
        PlayerStartPos = new int[,] { { 10, 20 } };
        MapStoryText = "You wake up on a beach. There is a person.";
        MapString = """
                    ########################################
                    #                                      #
                    #                                      #
                    #                                      #
                    #                                      #
                    #                                      1
                    #                   P                  1
                    #                                      #
                    #                                      #
                    #                                      #
                    #    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   #
                    #    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   #
                    #    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   #
                    #    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   #
                    #########################################
                    """;
        InitializeMapArray();
    }
    public override void LinkMaps()
    {
        MapToGoTo1 = MapLinker.Forest;
        MapToGoTo2 = MapLinker.ForestWell;
    } 

    public override void Interaction()
    {
        Challenge01.RunDialog();
        MapStoryText = "The person nods at you and points to the exit in the east.";
    }
}