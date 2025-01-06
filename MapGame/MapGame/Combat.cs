using System.Linq.Expressions;
using System.Security.Cryptography;

namespace MapGame;

public class Combat
{
    private RpsHand PlayerHand { get; set; }
    private RpsHand EnemyHand { get; set; }
    private Result RoundResult { get; set; }
    private int EnemyWins { get; set; } = 0;
    private int PlayerWins { get; set; } = 0;
    private bool GameIsOver { get; set; } = false;
    public bool PlayerWonGame;
    
    public void RunCombat()
    {
        while (!GameIsOver)
        {
            DisplayCombatWindow();
            EnemyHand = GetEnemyHand();
            PlayerHand = GetPlayerHand();
            RoundResult = GetRoundResult();
            DisplayRoundResult();
            GameIsOver = CheckIfGameIsOver();
            Console.ReadKey();
        }
        DisplayGameResult();
    }

    private void DisplayRoundResult()
    {
        DisplayCombatWindow();
        CombatDisplay.DisplayBothHands(PlayerHand, EnemyHand);

        if (RoundResult == Result.EnemyWins)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(EnemyHand + " beats " + PlayerHand);
        }
            
        else if (RoundResult == Result.PlayerWins)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(PlayerHand + " beats " + EnemyHand);
        }
        
        Console.WriteLine("Result: " + RoundResult);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private void DisplayGameResult()
    {
        if (PlayerWins >= 3)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("you won. the enemy is dead.");
            PlayerWonGame = true;
        }
            
        else if (EnemyWins >= 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("you lost. you loose 1 HP.");
            PlayerWonGame = false;
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    private void DisplayCombatWindow()
    {
        Console.Clear();
        Console.WriteLine("Enemy Wins: " + EnemyWins + " Player Wins: " + PlayerWins);
    }

    private RpsHand GetEnemyHand()
    {
        Random r = new Random();
        int randomPick = r.Next(0, 3);
        return (RpsHand)randomPick;
    }

    private RpsHand GetPlayerHand()
    {
        do
        {
            Console.WriteLine("Choose 1) Rock, 2) Paper, 3) Scissor.");
            string? answer = Console.ReadLine();
            if (int.TryParse(answer, out int i))
            {
                switch (i)
                {
                    case 1:
                        return RpsHand.Rock;
                    case 2:
                        return RpsHand.Paper;
                    case 3:
                        return RpsHand.Scissor;
                    default:
                        continue;
                }
            }
            switch (answer) // ToDo: cheats - get rid
            {
                case "w":
                    PlayerWins = 3;
                    return RpsHand.Paper;
                case "l":
                    EnemyWins = 3;
                    return RpsHand.Paper;
                default: break;
            }
        } while (true);
    }

    private Result GetRoundResult()
    {
        switch (EnemyHand, PlayerHand)
        {
            case (RpsHand.Paper, RpsHand.Rock):
            case (RpsHand.Rock, RpsHand.Scissor):
            case (RpsHand.Scissor, RpsHand.Paper):
                EnemyWins++;
                return Result.EnemyWins;
            case (RpsHand enemy, RpsHand player) when enemy == player:
                return Result.Draw;
            default:
                PlayerWins++;
                return Result.PlayerWins;
        }
    }

    private bool CheckIfGameIsOver()
    {
        if (PlayerWins >= 3 || EnemyWins >= 3)
            return true;
        else return false;
    }

    public enum RpsHand  {
        Rock, 
        Paper, 
        Scissor
    }
    
    private enum Result {
        PlayerWins,
        EnemyWins,
        Draw
    }
}