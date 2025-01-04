namespace MapGame;

public static class CombatDisplay
{
    private static string _r = """
                                  _______          .
                              ---'   ____)         .
                                    (_____)        .
                                    (_____)        .
                                    (____)         .
                              ---.__(___)          .
                              """;
    
    private static string _p = """
                                   _______          .
                               ---'   ____)____     .
                                         ______)    .
                                         _______)   .
                                        _______)    .
                               ---.__________)      .
                               """;

    private static string _s = """
                                  _______          .
                              ---'   ____)____     .
                                        ______)    .
                                     __________)   .
                                    (____)         .
                              ---.__(___)          .
                              """;

    
    public static void DisplayPlayerHand(Combat.RpsHand hand)
    {
        switch (hand)
        {
            case Combat.RpsHand.Paper:
                Console.WriteLine(_p);
                break;
            case Combat.RpsHand.Rock:
                Console.WriteLine(_r);
                break;
            case Combat.RpsHand.Scissor:
                Console.WriteLine(_s);
                break;
        }
    }

    public static void DisplayEnemyHand(Combat.RpsHand hand)
    {
        switch (hand)
        {
            case Combat.RpsHand.Paper:
                SwitchHand(_p);
                break;
            case Combat.RpsHand.Rock:
                SwitchHand(_r);
                break;
            case Combat.RpsHand.Scissor:
                SwitchHand(_s);
                break;
        }
    }

    private static void SwitchHand(string s)
    {
        List<string> handList = s.Split(['\n'], StringSplitOptions.RemoveEmptyEntries).ToList();
        List<string> enemyHandList = handList.Select(line => new string(line.Reverse().ToArray())).ToList();
        for (int i = 0; i < enemyHandList.Count; i++)
        {
            enemyHandList[i] = enemyHandList[i].Replace('(', '#'); 
            enemyHandList[i] = enemyHandList[i].Replace(')', '('); 
            enemyHandList[i] = enemyHandList[i].Replace('#', ')');; 
            Console.WriteLine(enemyHandList[i]);
        }
    }

    public static void DisplayBothHands(Combat.RpsHand playerHand, Combat.RpsHand enemyHand)
    {
        string playerhandstring = "";
        string enemyhandstring = "";
        switch (playerHand)
        {
            case Combat.RpsHand.Paper:
                playerhandstring = _p;
                break;
            case Combat.RpsHand.Rock:
                playerhandstring = _r;
                break;
            case Combat.RpsHand.Scissor:
                playerhandstring = _s;
                break;
        }
        List<string> playerHandList = playerhandstring.Split(['\n', '\r'],StringSplitOptions.RemoveEmptyEntries).ToList();
        
        switch (enemyHand)
        {
            case Combat.RpsHand.Paper:
                enemyhandstring = _p;
                break;
            case Combat.RpsHand.Rock:
                enemyhandstring = _r;
                break;
            case Combat.RpsHand.Scissor:
                enemyhandstring = _s;
                break;
        }
        
        List<string> enemyhandList = enemyhandstring.Split(['\n', '\r'],StringSplitOptions.RemoveEmptyEntries).ToList();
        List<string> enemyHandListFlip = enemyhandList.Select(line => new string(line.Reverse().ToArray())).ToList();
        
        for (int i = 0; i < enemyHandListFlip.Count; i++)
        {
            enemyHandListFlip[i] = enemyHandListFlip[i].Replace('(', '#'); 
            enemyHandListFlip[i] = enemyHandListFlip[i].Replace(')', '('); 
            enemyHandListFlip[i] = enemyHandListFlip[i].Replace('#', ')');; 
        }
        
        for (int i = 0; i < playerHandList.Count; i++)
        {
            Console.WriteLine(playerHandList[i] + "   " + enemyHandListFlip[i]);
        }
    }
}