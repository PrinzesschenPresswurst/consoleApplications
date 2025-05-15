namespace MapGame.Exercises;

public static class Challenge01
{
    private static bool _nameWasSet;
    private static string? _name ;
    
    public static void RunDialog()
    {
        
        if (_nameWasSet)
        {
            Console.WriteLine($"Dude: \"Have a good one {_name}\"");
            return;
        }

        else if (!_nameWasSet)
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("I am some dude, what is you name?");
        
            _name = Console.ReadLine();
            while (true)
            {
                if (_name != null && !_name.Any(char.IsLetter))
                {
                    Console.WriteLine("Name must contain at least one letter.");
                    _name = Console.ReadLine();
                }
                    
                else
                    break;
            }
           
            _nameWasSet = true;
            Console.WriteLine($"Cool, hello {_name}.");
            
            Console.ReadKey();
            Console.Clear();
        }
    }
}