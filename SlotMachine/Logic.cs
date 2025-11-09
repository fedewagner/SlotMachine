namespace SlotMachine;

public class Logic
{
    /// <summary>
    /// Method for generating the random numbers
    /// </summary>
    /// <returns></returns>
    public static int[,] GeneratingElementsForGrid()
    {
        int[,] userArray = new int [Constants.DIMENSION, Constants.DIMENSION];
        Random random = new Random();
        
        for (int row = 0; row < userArray.GetLength(0); row++)
        {
            for (int col = 0; col < userArray.GetLength(1); col++)
            {
                
                //random generation
                int randomItem =
                    random.Next(Constants.MIN_FOR_RANDOM_FUNCTION,
                        Constants.MAX_FOR_RANDOM_FUNCTION +
                        1); //+1 is to include also the max value as an option in the random function
                userArray[row, col] = randomItem;
            }
        }

        return userArray;
    }


    public static int AddUserCredit(int userCredit)
    {
        userCredit += Constants.CREDIT_DELTA;
        return userCredit;
    }


    public static (int userCredit, int wonInTheBet) CheckingTheCombinations(int gameModus, int userCredit,
        int[,] userArray)
    {
        //With this game Modus we only check the Middle horizontal line
        int wonInTheBet = 0;
        int wonInTheBetHorizontal;
        int wonInTheBetVertical;
        int wonInTheBetDiagonal;
        
        if (gameModus == Constants.MODI_OPTIONS_LIST[0])
        {
            //From middle horizontal Line
            (userCredit, wonInTheBet) = CheckingHorizontalLine(userArray, userCredit);
        }
        
        //With this game Modus we only check the all horizontal lines
        if (gameModus == Constants.MODI_OPTIONS_LIST[1])
        {
            //From Horizonal Lines
            (userCredit, wonInTheBet) = CheckingAllHorizontalLines(userArray, userCredit);
        }

        //With this game Modus we only check the all vertical and horizontal lines
        else if (gameModus == Constants.MODI_OPTIONS_LIST[2])
        {
            //From Horizonal Lines
            (userCredit, wonInTheBetHorizontal) = CheckingAllHorizontalLines(userArray, userCredit);
            
            //From Vertical Lines
            (userCredit, wonInTheBetVertical) = CheckingAllVerticalLines(userArray, userCredit);
            
            wonInTheBet = wonInTheBetHorizontal + wonInTheBetVertical;
        }


        //With this gameMode we only check the all vertical and horizontal lines and diagonals
        else if (gameModus == Constants.MODI_OPTIONS_LIST[3])
        {
                //From all Horizonal Lines
                (userCredit, wonInTheBetHorizontal) = CheckingAllHorizontalLines(userArray, userCredit);

                //From Vertical Lines
                (userCredit, wonInTheBetVertical) = CheckingAllVerticalLines(userArray, userCredit);

                //From Diagonal Lines
                (userCredit, wonInTheBetDiagonal) = CheckingDiagonals(userArray, userCredit);
                
                wonInTheBet = wonInTheBetHorizontal + wonInTheBetVertical + wonInTheBetDiagonal;
                
        }
        return (userCredit,  wonInTheBet);
        }
    


    //Methods area
    // check only one middle line
    public static (int, int) CheckingHorizontalLine(int[,] userArray, int userCredit)
    {
        int wonByMiddleLine = 0;
        
        int middleRow = userArray.GetLength(0) / 2;
        int columns = userArray.GetLength(1);
        int first = userArray[middleRow, 0];
        for (int column = 1; column < columns; column++)
        {
            if (userArray[middleRow, column] != first)
            {
                return (userCredit, wonByMiddleLine);
            }
        }
        
        wonByMiddleLine = Constants.WINNING_DELTA;
        userCredit += wonByMiddleLine;
        
        return (userCredit, wonByMiddleLine) ;
    }


    //check all horizontal Lines
    public static (int userCredit, int) CheckingAllHorizontalLines(int[,] userArray, int userCredit)
    {
        int rows = userArray.GetLength(0);
        int columns = userArray.GetLength(1);
        int wonByHorizontalLines = 0;
        bool anyRowWinning = false;
        
        for (int row = 0; row < rows; row++)
        {
            int first = userArray[row, 0];
            bool rowWinning = true;
            for (int column = 1; column < columns; column++)
            {
                if (userArray[row, column] != first)
                {
                    rowWinning = false;
                    break;
                }
            }

            if (rowWinning)
            {
                wonByHorizontalLines += Constants.WINNING_DELTA;
                anyRowWinning = true;
            }
        }

        if (anyRowWinning)
        {
            //a row is winning
            userCredit += wonByHorizontalLines; 
        }
        return (userCredit,  wonByHorizontalLines);
    }

    //check all Vertical Lines
    public static (int userCredit, int) CheckingAllVerticalLines(int[,] userArray, int userCredit)
    {
        int rows = userArray.GetLength(0);
        int columns = userArray.GetLength(1);
        int wonByVerticalLines = 0;
        bool anyColumnWinning = false;
        
        for (int column = 0; column < columns; column++)
        {
            int first = userArray[0, column];
            bool columnWinning = true;
            for (int row = 1; row < rows; row++)
            {
                if (userArray[row, column] != first) //this column doesn't win
                {
                    columnWinning = false;
                    break; //this row doesn't win
                }
            }

            if (columnWinning)
            {
                wonByVerticalLines += Constants.WINNING_DELTA;
                anyColumnWinning = true;
            }
        }

        if (anyColumnWinning)
        {
            userCredit += wonByVerticalLines;
            
        }
        return (userCredit,  wonByVerticalLines); //no column winning
    }

    public static (int userCredit, int) CheckingDiagonals(int[,] userArray, int userCredit)
    {
        int rows = userArray.GetLength(0);
        int columns = userArray.GetLength(1);
        bool isDiagonal1AWinner = true;
        bool isDiagonal2AWinner = true;
        int wonByDiagonals = 0;
        bool isAnyDiagonalLineWinning = false;
        int firstElementDiagonal1 = userArray[0, 0];
        
        for (int row = 1, col = 1; row < rows && col < columns; row++, col++)
        {
            if (userArray[row, col] != firstElementDiagonal1)
            {
                isDiagonal1AWinner = false;
                break;
            }
        }

        int lastRow = userArray.GetLength(0) - 1;
        int firstElementDiagonal2 = userArray[lastRow, 0];
        for (int row = lastRow - 1, col = 1; row >= 0 && col < columns; row--, col++)
        {
            if (userArray[row, col] != firstElementDiagonal2)
            {
                isDiagonal2AWinner = false;
                break;
            }
        }

        if (isDiagonal1AWinner)
        {
            wonByDiagonals += Constants.WINNING_DELTA;
            isAnyDiagonalLineWinning = true;
        }

        if (isDiagonal2AWinner)
        {
            wonByDiagonals += Constants.WINNING_DELTA;
            isAnyDiagonalLineWinning = true;
        }

        if (isAnyDiagonalLineWinning)
        {
            userCredit += wonByDiagonals;
            
        }
        return (userCredit,  wonByDiagonals);
    }
}