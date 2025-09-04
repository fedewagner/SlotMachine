namespace SlotMachine;

public class UI_Methods
{
    const int CREDIT_DELTA = 100;
    const string KEY_FOR_ADDING_CREDIT = "f";
    const string KEY_FOR_GAMING = "p";

    /// <summary>
    /// This methods welcomes the user and give the option to add credit or go into play mode.
    /// </summary>
    /// <returns></returns>
    public static int WelcomeUserAndAddSomeCredit()
    {
        //variables
        int userCredit = 0;
        bool gameMode = false;
        string selection;

        //define keys for user to be pressed
        List<string> options_menu = new List<string> { KEY_FOR_ADDING_CREDIT, KEY_FOR_GAMING };


        //give info to user
        Console.WriteLine("Welcome to the Slot Machine!");

        //Add initial credit
        do
        {
            Console.WriteLine($"Please enter some credit (Press {options_menu[0]})!");
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
        } while (!Equals(selection, KEY_FOR_ADDING_CREDIT));

        userCredit += CREDIT_DELTA;
        Console.WriteLine($"Your current credit: {userCredit} $");

        //add mode credit or go into game mode
        Console.WriteLine($"In case you want to add more money please insert banknote (Press {options_menu[0]})!");
        Console.WriteLine($"Otherwise, to play (Press {options_menu[1]})!");

        while (options_menu.Contains(selection) && !gameMode)
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
                        $"More money? => (Press {options_menu[0]})! or to play (Press {options_menu[1]})!");
                    break;
                }
            }
        }

        return userCredit;
    }

    /// <summary>
    /// This Method makes and shows an empty grid just to improve the UI with the user
    /// </summary>
    public static void DisplayEmptyGrid(int[,] userArray)
    {
    

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
        for (int row = 0; row < userArray.GetLength(0); row++)
        {
            //print first Character each row
            Console.Write("|");
            for (int col = 0; col < userArray.GetLength(0); col++)
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
    /// <param name="optionsLinesModus"></param>
    /// <param name="optionsLinesCosts"></param>
    /// <returns></returns>
    public static (int gameModus, int userCredit) AskForLinesSelection(int userCredit, List<int> optionsLinesModus, List<int> optionsLinesCosts )
    {
        Console.WriteLine($"How many lines to you want to play?");
        Console.WriteLine($"1 middle line  = {optionsLinesCosts[0]}$  (Press {optionsLinesModus[0]})");
        Console.WriteLine($"3 Horizontal lines = {optionsLinesCosts[1]}$  (Press {optionsLinesModus[1]})");
        Console.WriteLine($"3 Horizontal + 3 Vertical lines = {optionsLinesCosts[2]}$  (Press {optionsLinesModus[2]})");
        Console.WriteLine($"3 Horizontal + 3 Vertical lines + 2 Diagonal = {optionsLinesCosts[3]}$ (Press {optionsLinesModus[3]})");

        bool success;
        int selectionLines;
        int gameModus = 0;

        do
        {
            success = int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectionLines);
        } while (!success || !optionsLinesModus.Contains(selectionLines));

        switch (selectionLines)
        {
            case 1:
            {
                gameModus = optionsLinesModus[0]; 
                userCredit -= optionsLinesCosts[0];
                break;
            }
            case 3:
            {
                gameModus = optionsLinesModus[1]; 
                userCredit -= optionsLinesCosts[1];
                break;
            }
            case 6:
            {
                gameModus =  optionsLinesModus[2]; 
                userCredit -= optionsLinesCosts[2];
                break;
            }
            case 8:
            {
                gameModus =  optionsLinesModus[3]; 
                userCredit -= optionsLinesCosts[3];
                break;
            }
        }

        Console.WriteLine($"Your current credit: {userCredit} and selected bet is {gameModus} Lines");

        return (gameModus, userCredit);
    }
    
    
    
    //Method for creating the user grid with random numbers
    const int MIN_FOR_RANDOM_FUNCTION = 1;
    const int MAX_FOR_RANDOM_FUNCTION = 3;

    /// <summary>
    ///This method feeds randomly the grid with the values
    /// </summary>
    /// <param name="dimension">This needs the dimension to know how many values are needed</param>
    /// <returns></returns>
    public static int[,] GeneratingGrid(int dimension)
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