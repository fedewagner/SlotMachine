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
/// read the key entered by the user and then based on the choice, either add credit or go to game mode
/// </summary>
/// <param name="userCredit"></param>
/// <returns></returns>
    public static (int, bool, string) ReadUserKey( int userCredit)
    {
        bool gameMode = false;
        string selection;
        
        do
        {
           //read key method
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_ADDING_CREDIT || selection == Constants.KEY_FOR_GAMING ))
            {
                Console.WriteLine($"Please press ´{Constants.KEY_FOR_ADDING_CREDIT}´ or ´{Constants.KEY_FOR_GAMING}´ ");
            }
        } while (!(selection == Constants.KEY_FOR_ADDING_CREDIT || selection == Constants.KEY_FOR_GAMING )); //repeat if the key is not valid
        

        switch (selection)
        {
            case "p":
            {
                if (userCredit > 0)
                {gameMode = true; break;}
                Console.WriteLine($"Your current credit {userCredit}$ isn´t enough!");
                break;
            }
            case "f":
            {
                userCredit = Logic.AddUserCredit(userCredit);
                //Prints credit
                ShowsCredit(userCredit);
                break;
            }
            
        }
        return (userCredit, gameMode, selection);
    }


    /// <summary>
    /// This Method helps to select the bet 1L = 1$, 3L = 3$, 6L = 8$ or 8L = 12$
    /// </summary>
    /// <param name="userCredit">Is the user credit</param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="optionsLinesCosts"></param>
    /// <returns></returns>
    public static int AskForLinesSelection()
    {
        //Printing options for the user and the line selection
        PrintLineOptions(Constants.MODI_OPTIONS_LIST, Constants.LINES_OPTIONS_COSTS_LIST);
        
        bool success;
        int selectedLine;
        int gameMode;
        
        //check if the selection is valid
        do
        {
            success = int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectedLine);
            if (!Constants.MODI_OPTIONS_LIST.Contains(selectedLine))
            {
                Console.WriteLine($"Please press {Constants.MODI_OPTIONS_LIST[0]}, {Constants.MODI_OPTIONS_LIST[1]}, {Constants.MODI_OPTIONS_LIST[2]}, {Constants.MODI_OPTIONS_LIST[3]} or {Constants.MODI_OPTIONS_LIST[4]}!");
            }
            
        } while (!success || !Constants.MODI_OPTIONS_LIST.Contains(selectedLine));
        
        gameMode = selectedLine;
        return (gameMode);
    }

    /// <summary>
    /// This method check the Selected mode by the user and then check if the money is enough returning a TRUE if the money is available
    /// </summary>
    /// <param name="userCredit"></param>
    /// <param name="gameModus"></param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="optionsLinesCosts"></param>
    /// <returns></returns>
    public static (int, bool) CheckingSelectedMode(int userCredit, int gameModus)
    {
        bool isMoneyEnough = true;
        
        //depending on the selection then the app prints something different
        if (gameModus == Constants.MODI_OPTIONS_LIST[4]) //start with the case of checking out
        {
            //case for checking out
            UserChecksOut(userCredit);
        }

        //continue with the most expensive case = 12$ and check the money
        else if (gameModus == Constants.MODI_OPTIONS_LIST[3])
        {
            (isMoneyEnough, userCredit) = RestingUsersCredit(userCredit, gameModus, Constants.LINES_OPTIONS_COSTS_LIST[3]);
        }

        else if (gameModus == Constants.MODI_OPTIONS_LIST[2])
        {
            (isMoneyEnough, userCredit) = RestingUsersCredit(userCredit, gameModus,Constants.LINES_OPTIONS_COSTS_LIST[2]);
        }

        else if (gameModus == Constants.MODI_OPTIONS_LIST[1])
        {
            (isMoneyEnough, userCredit) = RestingUsersCredit(userCredit, gameModus,Constants.LINES_OPTIONS_COSTS_LIST[1]);
        }

        else if (gameModus == Constants.MODI_OPTIONS_LIST[0])
        {
            (isMoneyEnough, userCredit) = RestingUsersCredit(userCredit, gameModus,Constants.LINES_OPTIONS_COSTS_LIST[0]);
        }

        return (userCredit, isMoneyEnough);
    }

    //Line options with costs
    static public void PrintLineOptions(List<int> optionsLinesMode, List<int> optionsLinesCosts)
    {
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine("How many lines would you like to play? Please select one option");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"1 middle line  = {optionsLinesCosts[0]}$  (Press {optionsLinesMode[0]})");
        Console.WriteLine($"3 Horizontal lines = {optionsLinesCosts[1]}$  (Press {optionsLinesMode[1]})");
        Console.WriteLine(
            $"3 Horizontal + 3 Vertical lines = {optionsLinesCosts[2]}$  (Press {optionsLinesMode[2]})");
        Console.WriteLine(
            $"3 Horizontal + 3 Vertical lines + 2 Diagonal = {optionsLinesCosts[3]}$ (Press {optionsLinesMode[3]})");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"In case you want to check out the money then press '{optionsLinesMode[4]}'");
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
    /// This enable to check if the userCredit is enough or not
    /// </summary>
    /// <param name="userCredit"></param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="selectedBetCost"></param>
    /// <returns></returns>
    public static (bool,int) RestingUsersCredit(int userCredit, int gameModus, int selectedBetCost)
    {
        bool isMoneyEnough;
        if (userCredit >= selectedBetCost)
        {
            isMoneyEnough = true;
            userCredit -= selectedBetCost;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Your current credit: {userCredit}$ and selected bet is {gameModus} Lines");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("---------------------------------------------------------------------------");
        }
        else
        {
            isMoneyEnough = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {selectedBetCost}$");
            Console.WriteLine("Please select another option");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        return (isMoneyEnough, userCredit);
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
    /// <param name="gameMode"></param>
    /// <param name="userCredit"></param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="userArray"></param>
    /// <param name="winnersDelta"></param>
    /// <returns></returns>
    

    public static void AskingUserToLeaveBecauseOfNoMoneyLeft(int userCredit)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You finished playing with the credit: {userCredit}$");
        Console.Write("You don't have credits to play, please insert more money to keep playing");
    }
}