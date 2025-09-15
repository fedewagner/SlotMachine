using System.Xml.Schema;

namespace SlotMachine;

public class UiMethods
{
    /// <summary>
    /// This methods welcomes the user and give the option to add credit or go into play mode.
    /// </summary>
    /// <returns></returns>
    public static int WelcomeUserAndAddSomeCredit(int winningdelta, int CREDIT_DELTA, string KEY_FOR_ADDING_CREDIT, string KEY_FOR_GAMING)
    {
        //variables
        int userCredit = 0;
        bool gameMode = false;
        string selection;

        //define keys for user to be pressed
        List<string> optionsMenu = new List<string> { KEY_FOR_ADDING_CREDIT, KEY_FOR_GAMING };


        //give info to user
        Console.WriteLine("Welcome to the Slot Machine!");
        Console.WriteLine("You can play for Horizontal, Vertical and Diagonal Lines");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Everytime you get a line, you'll win {winningdelta}$!!!");
        Console.ForegroundColor = ConsoleColor.Gray;

        //Add initial credit
        do
        {
            Console.WriteLine($"Please enter some credit (Press {optionsMenu[0]})!");
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
        } while (!Equals(selection, KEY_FOR_ADDING_CREDIT));

        userCredit += CREDIT_DELTA;
        Console.WriteLine($"Your current credit: {userCredit} $");

        //add mode credit or go into game mode
        Console.WriteLine($"In case you want to add more money please insert banknote (Press {optionsMenu[0]})!");
        Console.WriteLine($"Otherwise, to play (Press {optionsMenu[1]})!");

        while (optionsMenu.Contains(selection) && !gameMode)
        {
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
            switch (selection)
            {
                case "p": gameMode = true; break;
                case "f":
                {
                    userCredit += 100;
                    Console.WriteLine($"Your current credit: {userCredit} $");
                    Console.WriteLine(
                        $"More money? => (Press {optionsMenu[0]})! or to play (Press {optionsMenu[1]})!");
                    break;
                }
            }
        }

        return userCredit;
    }


    /// <summary>
    /// This Method helps to select the bet 1L = 1$, 3L = 3$, 6L = 8$ or 8L = 12$
    /// </summary>
    /// <param name="userCredit">Is the user credit</param>
    /// <param name="optionsLinesMode"></param>
    /// <param name="optionsLinesCosts"></param>
    /// <returns></returns>
    public static (int gameModus, int userCredit, bool isMoneyEnoght) AskForLinesSelection(int userCredit, List<int> optionsLinesMode,
        List<int> optionsLinesCosts)
    {
        bool isMoneyEnough = true;
        
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine("How many lines would you like to play? Please select one option");
        Console.WriteLine($"1 middle line  = {optionsLinesCosts[0]}$  (Press {optionsLinesMode[0]})");
        Console.WriteLine($"3 Horizontal lines = {optionsLinesCosts[1]}$  (Press {optionsLinesMode[1]})");
        Console.WriteLine(
            $"3 Horizontal + 3 Vertical lines = {optionsLinesCosts[2]}$  (Press {optionsLinesMode[2]})");
        Console.WriteLine(
            $"3 Horizontal + 3 Vertical lines + 2 Diagonal = {optionsLinesCosts[3]}$ (Press {optionsLinesMode[3]})");
        Console.WriteLine($"In case you want to check out the money then press '{optionsLinesMode[4]}'");
        
        bool success;
        int selectionLines;
        int gameMode = 0;
        
        do
        {
            success = int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectionLines);
        } while (!success || !optionsLinesMode.Contains(selectionLines));

        if (selectionLines == optionsLinesMode[4]) //start with the case of checking out
        {
            //case for checking out
            gameMode = optionsLinesMode[4];
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You finished playing with the credit: {userCredit}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        //continue with the most expensive case = 12$ and check the money
        else if (selectionLines == optionsLinesMode[3])
        {
            if (userCredit >= optionsLinesCosts[3])
            {
                isMoneyEnough = true;
                gameMode = optionsLinesMode[3];
                userCredit -= optionsLinesCosts[3];
                Console.WriteLine($"Your current credit: {userCredit} and selected bet is {gameMode} Lines");
                Console.WriteLine("---------------------------------------------------------------------------"); 
            }
            else
            {
                isMoneyEnough = false;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {optionsLinesCosts[3]}$");
                Console.WriteLine("Please select another option");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        else if (selectionLines == optionsLinesMode[2])
        {
            if (userCredit >= optionsLinesCosts[2])
            {
                isMoneyEnough = true;
                gameMode = optionsLinesMode[2];
                userCredit -= optionsLinesCosts[2];
                Console.WriteLine($"Your current credit: {userCredit} and selected bet is {gameMode} Lines");
                Console.WriteLine("---------------------------------------------------------------------------");
            }
            else
            {
                isMoneyEnough = false;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {optionsLinesCosts[2]}$");
                Console.WriteLine("Please select another option");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
        }

        else if (selectionLines == optionsLinesMode[1])
        {
            if (userCredit >= optionsLinesCosts[1])
            {
                isMoneyEnough = true;
                gameMode = optionsLinesMode[1];
                userCredit -= optionsLinesCosts[1];
                Console.WriteLine($"Your current credit: {userCredit} and selected bet is {gameMode} Lines");
                Console.WriteLine("---------------------------------------------------------------------------");
            }
            else
            {
                isMoneyEnough = false;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {optionsLinesCosts[1]}$");
                Console.WriteLine("Please select another option");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        else if (selectionLines == optionsLinesMode[0])
        {
            if (userCredit >= optionsLinesCosts[0])
            {
                isMoneyEnough = true;
                gameMode = optionsLinesMode[0];
                userCredit -= optionsLinesCosts[0];
                Console.WriteLine($"Your current credit: {userCredit} and selected bet is {gameMode} Lines");
                Console.WriteLine("---------------------------------------------------------------------------");
            }
            else
            {
                isMoneyEnough = false;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"User Credit: {userCredit}$ is lower than the cost: {optionsLinesCosts[0]}$");
                Console.WriteLine("Please select another option");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
        }
            
        return (gameMode, userCredit, isMoneyEnough);
    }



    /// <summary>
    /// Method for generating the random numbers
    /// </summary>
    /// <param name="dimension"></param>
    /// <param name="minForRandomFunction"></param>
    /// <param name="maxForRandomFunction"></param>
    /// <returns></returns>
    public static int[,] GeneratingElementsForGrid(int dimension, int minForRandomFunction, int maxForRandomFunction)
    {
        int[,] userArray = new int [dimension, dimension];

        for (int row = 0; row < userArray.GetLength(0); row++)
        {
            for (int col = 0; col < userArray.GetLength(1); col++)
            {
                //random generation
                Random random = new Random();
                int randomItem =
                    random.Next(minForRandomFunction,  maxForRandomFunction +  1); //+1 is to include also the max value as an option in the random function
                userArray[row, col] = randomItem;
            }
        }

        return userArray;
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
    public static int CheckingTheCombinations(int gameMode, int userCredit, List<int> optionsLinesMode, int[,] userArray, int winnersDelta )
    {
        
        //With this game Modus we only check the Middle horizontal line
        if (gameMode == optionsLinesMode[0])
        {
            //From middle horizontal Line
            (var isMiddleLineAWinner, int wonByHorizontalLine, string messageMiddleLine) = Logic.CheckingHorizontalLine(userArray, winnersDelta);
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
            (var isAnyHorizontalLineWinning, int wonByHorizontalLines, string messageHLines) = Logic.CheckingAllHorizontalLines(userArray, winnersDelta);
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
        Console.WriteLine($"The user credit is: {userCredit}");
        return userCredit;
       
    }

    public static void AskingUserToLeaveBecauseOfNoMoneyLeft(int userCredit)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You finished playing with the credit: {userCredit}");
        Console.Write("You don't have credits to play, please insert more money to keep playing");
    }
}