namespace SlotMachine;

public class Constants
{
    //constants
    public const int WINNING_DELTA = 50;
    public const int DIMENSION = 3;
            
    //const for credit
    public const int CREDIT_DELTA = 100;
            
    //const for options
    public const string KEY_FOR_ADDING_CREDIT = "f";
    public const string KEY_FOR_GAMING = "p";
            
    //Min and max
    public const int MIN_FOR_RANDOM_FUNCTION = 1;
    public const int MAX_FOR_RANDOM_FUNCTION = 9; //this value will be also include. Recommendation below 9

    //options for the game modus
    public const int OPTION_1_LINE = 1;
    public const int OPTION_3_LINES = 3;
    public const int OPTION_6_LINES = 6;
    public const int OPTION_8_LINES = 8;
    public const int OPTION_CHECK_OUT = 9;

    //cost of each modus
    public const int COST_1_LINE = 1;
    public const int COST_3_LINES = 3;
    public const int COST_6_LINES = 8;
    public const int COST_8_LINES = 12;
    
// List declarations with the packed constants
    //List for option with amount of lines
    public static readonly List<int> MODI_OPTIONS_LIST = new() { OPTION_1_LINE, OPTION_3_LINES, OPTION_6_LINES, OPTION_8_LINES, OPTION_CHECK_OUT };
    
    //List for the cost of the different options
    public static readonly List<int> LINES_OPTIONS_COSTS_LIST = new() { COST_1_LINE, COST_3_LINES, COST_6_LINES, COST_8_LINES };
            
    //List with the key options
    public static readonly List<string> KEYS_OPTIONS_LIST = new() { KEY_FOR_ADDING_CREDIT, KEY_FOR_GAMING };



    
    
}