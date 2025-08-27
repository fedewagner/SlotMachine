namespace SlotMachine;

public class LinesSelection
{
    public static int AskForLinesSelection(int userCredit)
    {
        const int OPTION_1_LINE = 1;
        const int OPTION_3_LINES = 3;
        const int OPTION_6_LINES = 6;
        const int OPTION_8_LINES = 8;
        
        List<int> optionsLinesModus = new List<int> { 1,3,6,8 };
        
        Console.WriteLine($"How many lines to you want to play?");
        Console.WriteLine($"1 Line  = 1$  (Press {OPTION_1_LINE})");
        Console.WriteLine($"3 Lines = 3$  (Press {OPTION_3_LINES})");
        Console.WriteLine($"6 Lines = 6$  (Press {OPTION_6_LINES})");
        Console.WriteLine($"8 Lines = 12$ (Press {OPTION_8_LINES})");

        bool success;
        int selection_lines;
        int game_modus = 0;
            
        do
        {
            success = int.TryParse(Console.ReadKey(true).KeyChar.ToString() , out selection_lines);
        } 
        while (!success || !optionsLinesModus.Contains(selection_lines));

        switch (selection_lines)
        {
            case OPTION_1_LINE: game_modus = OPTION_1_LINE; break;
            case OPTION_3_LINES: game_modus = OPTION_3_LINES; break;
            case OPTION_6_LINES: game_modus = OPTION_6_LINES; break;
            case OPTION_8_LINES: game_modus = OPTION_8_LINES; break;
        }
        Console.WriteLine($"Your current credit: {userCredit} and selected bet is {game_modus} Lines");
        
        return game_modus;
    }
}