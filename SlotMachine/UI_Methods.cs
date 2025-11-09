using System.Xml.Schema;

namespace SlotMachine;

public class UiMethods
{

    public static void WelcomeUser(int WINNING_DELTA)
    {
        //give info to user
        Console.WriteLine("Welcome to the Slot Machine!");
        Console.WriteLine("You can play for Horizontal, Vertical and Diagonal Lines");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Everytime you get a line, you'll win {WINNING_DELTA}$!!!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void ShowsCredit(int userCredit)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Your current credit: {userCredit} $");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void OfferAddingCredit(List<string> optionsMenu)
    {
        //uses the defined keys for adding credit
        Console.WriteLine($"If you want to add some credit (Press {optionsMenu[0]})!");
    }

    public static void OfferGamingMode(List<string> optionsMenu)
    {
        Console.WriteLine($"Otherwise, to play (Press {optionsMenu[1]})!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }



/// <summary>
/// read the key entered by the user and then based on the choice, either add credit or go to game mode
/// </summary>
/// <param name="userCredit"></param>
/// <returns></returns>
    public static (int, bool, string) ReadUserKey( int userCredit, int CREDIT_DELTA, List<string> optionsMenu)
    {
        bool gameMode = false;
        string selection;
        
        do
        {
           //read key method
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!optionsMenu.Contains(selection))
            {
                Console.WriteLine($"Please press ´{optionsMenu[0]}´ or ´{optionsMenu[1]}´ ");
            }
        } while (!optionsMenu.Contains(selection)); //repeat if the key is not valid
        

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
                userCredit = Logic.addUserCredit(userCredit, CREDIT_DELTA);
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
    public static (int , int , bool ) AskForLinesSelection(int userCredit, List<int> optionsLinesMode, List<int> optionsLinesCosts)
    
    {
        bool isMoneyEnough = true;

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

        bool success;
        int selectionLines;
        int gameMode = 0;
        
        //check if the selection is valid
        do
        {
            success = int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectionLines);
        } while (!success || !optionsLinesMode.Contains(selectionLines));

        //depending on the selection then the app prints something different
        if (selectionLines == optionsLinesMode[4]) //start with the case of checking out
        {
            //case for checking out
            gameMode = optionsLinesMode[4];
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You finished playing with the credit: {userCredit}$");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        //continue with the most expensive case = 12$ and check the money
        else if (selectionLines == optionsLinesMode[3])
        {
            (isMoneyEnough, userCredit, gameMode) = CheckingUserCredit(userCredit, optionsLinesMode[3], optionsLinesCosts[3]);
        }

        else if (selectionLines == optionsLinesMode[2])
        {
            (isMoneyEnough, userCredit, gameMode) = CheckingUserCredit(userCredit, optionsLinesMode[2], optionsLinesCosts[2]);
        }

        else if (selectionLines == optionsLinesMode[1])
        {
            (isMoneyEnough, userCredit, gameMode) = CheckingUserCredit(userCredit, optionsLinesMode[1], optionsLinesCosts[1]);
        }

        else if (selectionLines == optionsLinesMode[0])
        {
            (isMoneyEnough, userCredit, gameMode) = CheckingUserCredit(userCredit, optionsLinesMode[0], optionsLinesCosts[0]);
        }

        return (gameMode, userCredit, isMoneyEnough);
    }

    /// <summary>
    /// This enable to check if the userCredit is enough or not
    /// </summary>
    /// <param name="userCredit"></param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="selectedBetCost"></param>
    /// <returns></returns>
    public static (bool,int,int) CheckingUserCredit(int userCredit, int optionsLinesMode, int selectedBetCost)
    {
        bool isMoneyEnough;
        int gameMode;
        
        if (userCredit >= selectedBetCost)
        {
            isMoneyEnough = true;
            gameMode = optionsLinesMode;
            userCredit -= selectedBetCost;
            Console.WriteLine($"Your current credit: {userCredit} and selected bet is {gameMode} Lines");
            Console.WriteLine("---------------------------------------------------------------------------");
        }
        else
        {
            isMoneyEnough = false;
            gameMode = 0;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {selectedBetCost}$");
            Console.WriteLine("Please select another option");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        return (isMoneyEnough, userCredit, gameMode);
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

    /// <summary>
    /// This method is to check all combinations, calculate the total won money and print it in the screen
    /// </summary>
    /// <param name="gameMode"></param>
    /// <param name="userCredit"></param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="userArray"></param>
    /// <param name="winnersDelta"></param>
    /// <returns></returns>
    public static int CheckingTheCombinations(int gameMode, int userCredit, List<int> optionsLinesMode,
        int[,] userArray, int winnersDelta)
    {
        //With this game Modus we only check the Middle horizontal line
        if (gameMode == optionsLinesMode[0])
        {
            //From middle horizontal Line
            (var isMiddleLineAWinner, int wonByHorizontalLine, string messageMiddleLine) =
                Logic.CheckingHorizontalLine(userArray, winnersDelta);
            if (isMiddleLineAWinner)
            {
                userCredit += wonByHorizontalLine;
                Console.WriteLine(messageMiddleLine);
            }
        }
        //With this game Modus we only check the all horizontal lines
        else if (gameMode == optionsLinesMode[1])
        {
            //From Horizonal Lines
            (var isAnyHorizontalLineWinning, int wonByHorizontalLines, string messageHLines) =
                Logic.CheckingAllHorizontalLines(userArray, winnersDelta);
            if (isAnyHorizontalLineWinning)
            {
                var totalWon = wonByHorizontalLines;
                userCredit += totalWon;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(messageHLines);
                Console.WriteLine($"You won {totalWon}$!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        //With this game Modus we only check the all vertical and horizontal lines
        else if (gameMode == optionsLinesMode[2])
        {
            //From Horizonal Lines
            (var isAnyHorizontalLineWinning, int wonByHorizontalLines, string messageHLines) =
                Logic.CheckingAllHorizontalLines(userArray, winnersDelta);

            //From Vertical Lines
            (var isAnyVerticalLineWinning, int wonByVerticalLines, string messageVLines) =
                Logic.CheckingAllVerticalLines(userArray, winnersDelta);

            if (isAnyHorizontalLineWinning || isAnyVerticalLineWinning)
            {
                var totalWon = wonByHorizontalLines + wonByVerticalLines;
                userCredit += totalWon;
                Console.ForegroundColor = ConsoleColor.Green;
                if (messageHLines != "")
                {
                    Console.WriteLine(messageHLines);
                }

                if (messageVLines != "")
                {
                    Console.WriteLine(messageVLines);
                }

                Console.WriteLine($"You won {totalWon}$!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        //With this gameMode we only check the all vertical and horizontal lines and diagonals
        else if (gameMode == optionsLinesMode[3])
        {
            //From all Horizonal Lines
            (var isAnyHorizontalLineWinning, int wonByHorizontalLines, string messageHLines) =
                Logic.CheckingAllHorizontalLines(userArray, winnersDelta);

            //From Vertical Lines
            (var isAnyVerticalLineWinning, int wonByVerticalLines, string messageVLines) =
                Logic.CheckingAllVerticalLines(userArray, winnersDelta);

            //From Diagonal Lines
            (var isAnyDiagonalLineWinning, int wonByDiagonals, string messageDLines) =
                Logic.CheckingDiagagonals(userArray, winnersDelta);


            if (isAnyHorizontalLineWinning || isAnyVerticalLineWinning ||
                isAnyDiagonalLineWinning)
            {
                var totalWon = wonByHorizontalLines + wonByVerticalLines + wonByDiagonals;
                userCredit += totalWon;
                Console.ForegroundColor = ConsoleColor.Green;
                if (messageHLines != "")
                {
                    Console.WriteLine(messageHLines);
                }

                if (messageVLines != "")
                {
                    Console.WriteLine(messageVLines);
                }

                if (messageDLines != "")
                {
                    Console.WriteLine(messageDLines);
                }

                Console.WriteLine($"You won {totalWon}$!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        if (userCredit != 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The user credit is: {userCredit}$");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        return userCredit;
    }

    public static void AskingUserToLeaveBecauseOfNoMoneyLeft(int userCredit)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You finished playing with the credit: {userCredit}$");
        Console.Write("You don't have credits to play, please insert more money to keep playing");
    }
}