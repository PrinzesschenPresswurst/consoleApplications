using Console_Minesweeper;

Console.Title = "Minesweeper" ;

StartNewGame();
return;

void StartNewGame()
{
    Console.Clear();
    Board board = new Board(10,9, 10);
    Game game = new Game(board);
    PlayAgainHandler playAgainHandler = new PlayAgainHandler();
    
    if (playAgainHandler.WantsToPlayAgain)
        StartNewGame();
}