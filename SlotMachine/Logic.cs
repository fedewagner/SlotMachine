namespace SlotMachine;

public class Logic
{
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
        Random random = new Random();
        
        for (int row = 0; row < userArray.GetLength(0); row++)
        {
            for (int col = 0; col < userArray.GetLength(1); col++)
            {
                
                //random generation
                int randomItem =
                    random.Next(minForRandomFunction,
                        maxForRandomFunction +
                        1); //+1 is to include also the max value as an option in the random function
                userArray[row, col] = randomItem;
            }
        }

        return userArray;
    }


    public static int addUserCredit(int userCredit, int CREDIT_DELTA)
    {
        userCredit += CREDIT_DELTA;
        
        return userCredit;
    }

    //Methods area
    // check only one middle line
    public static (bool, int, string) CheckingHorizontalLine(int[,] userArray, int winnerdelta)
    {
        string message = "";
        int wonByMiddleLine;
        int middleRow = userArray.GetLength(0) / 2;
        int columns = userArray.GetLength(1);
        int first = userArray[middleRow, 0];
        for (int column = 1; column < columns; column++)
        {
            if (userArray[middleRow, column] != first)
            {
                wonByMiddleLine = 0;
                return (false, wonByMiddleLine, message);
            }
        }

        wonByMiddleLine = winnerdelta;
        message = $"Well done, you got {wonByMiddleLine}$ from the middle line!";
        return (true, wonByMiddleLine, message);
    }


    //check all horizontal Lines
    public static (bool, int, string) CheckingAllHorizontalLines(int[,] userArray, int winnerdelta)
    {
        string message = "";
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
                wonByHorizontalLines += winnerdelta;
                anyRowWinning = true;
            }
        }

        if (anyRowWinning)
        {
            message = $"Well done, you got {wonByHorizontalLines}$ from the horizontal lines!";
            return (true, wonByHorizontalLines, message);
            ; //a column is winning
        }

        return (false, wonByHorizontalLines, message); //no column winning
    }

    //check all Vertical Lines
    public static (bool, int, string) CheckingAllVerticalLines(int[,] userArray, int winnerdelta)
    {
        string message = "";
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
                if (userArray[row, column] != first) //this row doesn't win
                {
                    columnWinning = false;
                    break; //this row doesn't win
                }
            }

            if (columnWinning)
            {
                wonByVerticalLines += winnerdelta;
                anyColumnWinning = true;
            }
        }

        if (anyColumnWinning)
        {
            message = $"Well done, you got {wonByVerticalLines}$ from the vertical lines!";

            return (true, wonByVerticalLines, message); //a column is winning
        }

        return (false, wonByVerticalLines, message); //no column winning
    }

    public static (bool, int, string) CheckingDiagagonals(int[,] userArray, int winningdelta)
    {
        string message = "";
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
            wonByDiagonals = +winningdelta;
            isAnyDiagonalLineWinning = true;
        }

        if (isDiagonal2AWinner)
        {
            wonByDiagonals = +winningdelta;
            isAnyDiagonalLineWinning = true;
        }

        if (isAnyDiagonalLineWinning)
        {
            message = $"Well done, you got {wonByDiagonals}$ from the diagonal lines!";
        }

        return (isAnyDiagonalLineWinning, wonByDiagonals, message);
    }
}