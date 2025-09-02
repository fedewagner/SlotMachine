namespace SlotMachine;

public class UI_Methods
{
    /// <summary>
    /// This methods welcomes the user and give the option to add credit or go into play mode.
    /// </summary>
    /// <returns></returns>
    public static int WelcomeUserAndAddSomeCredit()
    {
        const int CREDIT_DELTA = 100;
        const string KEY_FOR_ADDING_CREDIT = "f";
        const string KEY_FOR_GAMING = "p";
        
        //variables
        int userCredit = 0;
        bool gameMode = false;
        string selection;
        
        //define keys for user to be pressed
        List<string> options_menu = new List<string> { KEY_FOR_ADDING_CREDIT,  KEY_FOR_GAMING };
 
        
        //give info to user
        Console.WriteLine("Welcome to the Slot Machine!");

        //Add initial credit
        do
        {
            Console.WriteLine($"Please enter some credit (Press {options_menu[0]})!");
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
        } 
        while (!Equals(selection, KEY_FOR_ADDING_CREDIT));
        userCredit += CREDIT_DELTA;
        Console.WriteLine($"Your current credit: {userCredit} $");
        
        //add mode credit or go into game mode
        Console.WriteLine($"In case you want to add more money please insert banknote (Press {options_menu[0]})!");
        Console.WriteLine($"Otherwise, to play (Press {options_menu[1]})!");
            
        while (options_menu.Contains(selection) && !gameMode) {
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
            switch(selection)
            {
                case "p": gameMode = true; break;
                case "f":
                {
                    userCredit += 100; 
                    Console.WriteLine($"Your current credit: {userCredit} $");
                    Console.WriteLine($"More money? => (Press {options_menu[0]})! or to play (Press {options_menu[1]})!");
                    break;
                }
            }
        } 
        
        return userCredit;
    }
    
    /// <summary>
    /// This Method makes and shows an empty grid just to improve the UI with the user
    /// </summary>
    public static void DisplayEmptyGrid(int dimension)
    {
        int[,] userArray = new int [dimension, dimension];

        //Print the upper border (one extra at the beginning and one at the end)
        Console.Write("+");
        for (int column = 0; column < userArray.GetLength(0); column++)
        {
            Console.Write("--+--");
        }

        Console.Write("+");
        Console.WriteLine();

        int item = 0;

        //fill the array
        for (int row = 0; row < dimension; row++)
        {
            //print first Character each row
            Console.Write("|");
            for (int col = 0; col < dimension; col++)
            {
                if (col % 2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    userArray[col, row] = item;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    userArray[col, row] = item;
                }

                //Print the output
                Console.Write("  " + userArray[col, row] + "  ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //print last Character each row
            Console.Write("|");
            Console.WriteLine();
        }

        //Print the bottom border(one extra at the beginning and one at the end)
        Console.Write("+");
        for (int column = 0; column < userArray.GetLength(0); column++)
        {
            Console.Write("--+--");
        }

        Console.WriteLine("+");
    }
    /// <summary>
    /// This Method helps to select the bet 1L = 1$, 3L = 3$, 6L = 8$ or 8L = 12$
    /// </summary>
    /// <param name="userCredit">Is the user credit</param>
    /// <returns></returns>
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
    public static int[,] GeneratingGrid()
    {
        const int MIN_FOR_RANDOM_FUNCTION = 1;
        const int MAX_FOR_RANDOM_FUNCTION = 9;
        
        int dimension = 3;
        int[,] userArray = new int [dimension, dimension];
        
        //Print the upper border (one extra at the beginning and one at the end)
        Console.Write("+");
        for (int column = 0; column < userArray.GetLength(0); column++)
        {
            Console.Write("--+--");
        }

        Console.Write("+");
        Console.WriteLine();

        int item = 0;

        //fill the array
        for (int row = 0; row < dimension; row++)
        {
            //print first Character each row
            Console.Write("|");
            for (int col = 0; col < dimension; col++)
            {
                //random generation
                Random random = new Random();
                int randomItem = random.Next(MIN_FOR_RANDOM_FUNCTION, MAX_FOR_RANDOM_FUNCTION);
                userArray[row, col] = randomItem;
                
                if (col % 2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                //Print the output
                Console.Write("  " + userArray[row, col] + "  ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //print last Character each row
            Console.Write("|");
            Console.WriteLine();
        }

        //Print the bottom border(one extra at the beginning and one at the end)
        Console.Write("+");
        for (int column = 0; column < userArray.GetLength(0); column++)
        {
            Console.Write("--+--");
        }

        Console.WriteLine("+");
        
        return userArray;
    }
}