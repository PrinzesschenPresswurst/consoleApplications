namespace Hangman;

public class Word
{
    public string WordForGame { get; set; }
    private string[] PossibleWords { get; set; } = {"fart", "godzilla", "kotkot", "alienspasti", "bigger"};

    // constructor
    public Word()
    {
        WordForGame = GetWord();
    }

    private string GetWord()
    {
        Random r = new Random();
        int rInt = r.Next(0, PossibleWords.Length);
        return PossibleWords[rInt];
    }
}