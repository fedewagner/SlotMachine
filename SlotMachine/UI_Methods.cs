using System.Xml.Schema;

namespace SlotMachine;

public class UiMethods
{

    public static void WelcomeUser()
    {
        //give info to user
        Console.WriteLine("Welcome to the Slot Machine!");
        Console.WriteLine("You can play for Horizontal, Vertical and Diagonal Lines");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Everytime you get a line, you'll win {Constants.WINNING_DELTA}$!!!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void ShowsCredit(int userCredit)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Your current credit: {userCredit} $");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void OfferAddingCredit()
    {
        //uses the defined keys for adding credit
        Console.WriteLine($"If you want to add some credit (Press {Constants.KEY_FOR_ADDING_CREDIT})!");
    }

    public static void OfferGamingMode()
    {
        Console.WriteLine($"Otherwise, to play (Press {Constants.KEY_FOR_GAMING})!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }


    /// <summary>
    /// read the key entered by the user 
    /// </summary>
    /// <returns></returns>
    public static string CheckUserKeyInput()
    {
        string selection;

        do
        {
            //read key method
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_ADDING_CREDIT || selection == Constants.KEY_FOR_GAMING))
            {
                Console.WriteLine($"Please press ´{Constants.KEY_FOR_ADDING_CREDIT}´ or ´{Constants.KEY_FOR_GAMING}´ ");
            }
        } while (!(selection == Constants.KEY_FOR_ADDING_CREDIT || selection == Constants.KEY_FOR_GAMING) ); //repeat if the key is not valid

        return selection;
    }
    
    /// <summary>
    /// This Method helps to select the bet 1L = 1$, 3L = 3$, 6L = 8$ or 8L = 12$
    /// </summary>
    /// <returns></returns>
    public static int AskForLinesSelection()
    {
        //Printing options for the user and the line selection
        PrintLineOptions();
        
        bool success;
        int selectedLine;
        int gameMode;
        
        //check if the selection is valid
        do
        {
            success = int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectedLine);
            if (selectedLine != Constants.OPTION_1_LINE && 
                selectedLine != Constants.OPTION_3_LINES && 
                selectedLine != Constants.OPTION_6_LINES && 
                selectedLine != Constants.OPTION_8_LINES && 
                selectedLine != Constants.OPTION_CHECK_OUT)
            {
                Console.WriteLine($"Please press {Constants.OPTION_1_LINE}, {Constants.OPTION_3_LINES}, {Constants.OPTION_6_LINES}, {Constants.OPTION_8_LINES} or {Constants.OPTION_CHECK_OUT}!");
            }
            
        } while (!success || (selectedLine != Constants.OPTION_1_LINE && 
                              selectedLine != Constants.OPTION_3_LINES && 
                              selectedLine != Constants.OPTION_6_LINES && 
                              selectedLine != Constants.OPTION_8_LINES && 
                              selectedLine != Constants.OPTION_CHECK_OUT));
        
        gameMode = selectedLine;
        
        return gameMode;
    }
    

    //Line options with costs
    static public void PrintLineOptions()
    {
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine("How many lines would you like to play? Please select one option");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"1 middle line  = {Constants.OPTION_1_LINE}$  (Press {Constants.COST_1_LINE}$))");
        Console.WriteLine($"3 Horizontal lines = {Constants.OPTION_3_LINES}$  (Press {Constants.COST_3_LINES}$))");
        Console.WriteLine(
            $"3 Horizontal + 3 Vertical lines = {Constants.OPTION_6_LINES}$  (Press {Constants.COST_6_LINES})");
        Console.WriteLine(
            $"3 Horizontal + 3 Vertical lines + 2 Diagonal = {Constants.OPTION_8_LINES}$ (Press {Constants.COST_8_LINES})");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"In case you want to check out the money then press '{Constants.OPTION_CHECK_OUT}'");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    
    //Check out
    public static void UserChecksOut(int userCredit)
    {
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You finished playing with the credit: {userCredit}$");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("---------------------------------------------------------------------------");
    }

    /// <summary>
    /// This enables to check if the userCredit is enough or not
    /// </summary>
    /// <param name="userCredit"></param>
    /// <param name="gameModus"></param>
    /// <param name="selectedBetCost"></param>
    /// <returns></returns>
    public static bool CheckingCredit(int userCredit, int selectedBetCost)
    {
        bool isMoneyEnough;
        
        if (userCredit >= selectedBetCost)
        {
            isMoneyEnough = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Your credit: {userCredit}$ is enough");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("---------------------------------------------------------------------------");
        }
        else
        {
            isMoneyEnough = false;
            Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {selectedBetCost}$");
            Console.WriteLine("Please select another option");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        return isMoneyEnough;
    }
    
    public static int RestingUsersCredit(int userCredit, int selectedBetCost)
    {
        userCredit -= selectedBetCost;
        return userCredit;
    }
    
    
    
    
    ///  <summary>
    /// This method feeds randomly the grid with the values
    ///  </summary>
    ///  <param name="userArray">The matrix with the values</param>
    ///  <returns></returns>
    public static void PrintingGrid(int[,] userArray)
    {
        //Print the upper border (one extra at the beginning and one at the end)
        Console.WriteLine("The generated grid is...");

        Console.Write("+");
        for (int column = 0; column < userArray.GetLength(0); column++)
        {
            Console.Write("--+--");
        }

        Console.Write("+");
        Console.WriteLine();

        // int item = 0;

        //fill the array
        for (int row = 0; row < userArray.GetLength(0); row++)
        {
            //print first Character each row
            Console.Write("|");
            for (int col = 0; col < userArray.GetLength(1); col++)
            {
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
    }

    static public void PrintingWinnerText(int wonInTheBet)
    {
        if (wonInTheBet >= 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You won {wonInTheBet}$ in the bet!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    /// <summary>
    /// This method is to check all combinations, calculate the total won money and print it in the screen
    /// </summary>
    /// <param name="userCredit"></param>
    /// <returns></returns>
    

    public static void AskingUserToLeaveBecauseOfNoMoneyLeft(int userCredit)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You finished playing with the credit: {userCredit}$");
        Console.Write("You don't have credits to play, please insert more money to keep playing");
    }
}