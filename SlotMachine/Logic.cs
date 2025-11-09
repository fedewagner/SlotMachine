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


    public static int AddUserCredit(int userCredit, int CREDIT_DELTA)
    {
        userCredit += CREDIT_DELTA;
        
        return userCredit;
    }


    public static int CheckingTheCombinations(int gameModus, int userCredit, List<int> optionsLinesMode,
        int[,] userArray, int winnersDelta)
    {
        
        //With this game Modus we only check the Middle horizontal line
        if (gameModus == optionsLinesMode[0])
        {
            //From middle horizontal Line
            userCredit = CheckingHorizontalLine(userArray, winnersDelta, userCredit);
        }
        
        //With this game Modus we only check the all horizontal lines
        if (gameModus == optionsLinesMode[1])
        {
            //From Horizonal Lines
            userCredit = CheckingAllHorizontalLines(userArray, winnersDelta, userCredit);
        }

        //With this game Modus we only check the all vertical and horizontal lines
        else if (gameModus == optionsLinesMode[2])
        {
            //From Horizonal Lines
            userCredit = CheckingAllHorizontalLines(userArray, winnersDelta, userCredit);

            //From Vertical Lines
            userCredit = CheckingAllVerticalLines(userArray, winnersDelta, userCredit);
        }


        //With this gameMode we only check the all vertical and horizontal lines and diagonals
        else if (gameModus == optionsLinesMode[3])
        {
                //From all Horizonal Lines
                userCredit = CheckingAllHorizontalLines(userArray, winnersDelta, userCredit);

                //From Vertical Lines
                userCredit = CheckingAllVerticalLines(userArray, winnersDelta, userCredit);

                //From Diagonal Lines
                userCredit = CheckingDiagagonals(userArray, winnersDelta, userCredit);

            
        }

        UiMethods.ShowsCredit(userCredit);
        return userCredit;
        }
    


    //Methods area
    // check only one middle line
    public static int CheckingHorizontalLine(int[,] userArray, int winnerdelta, int userCredit)
    {
        string message;
        int wonByMiddleLine;
        int middleRow = userArray.GetLength(0) / 2;
        int columns = userArray.GetLength(1);
        int first = userArray[middleRow, 0];
        for (int column = 1; column < columns; column++)
        {
            if (userArray[middleRow, column] != first)
            {
                return userCredit;
            }
        }
        
        wonByMiddleLine = winnerdelta;
        message = $"Well done, you got {wonByMiddleLine}$ from the middle line!";
        
        userCredit += wonByMiddleLine;
        
        UiMethods.PrintingWinnerText(message, userCredit);
        
        return userCredit;
    }


    //check all horizontal Lines
    public static int CheckingAllHorizontalLines(int[,] userArray, int winnerdelta, int userCredit)
    {
        string message;
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
            //a row is winning
            message = $"Well done, you got {wonByHorizontalLines}$ from the horizontal lines!";
            userCredit += wonByHorizontalLines;
            UiMethods.PrintingWinnerText(message, userCredit);
            
        }
        return userCredit;
    }

    //check all Vertical Lines
    public static int CheckingAllVerticalLines(int[,] userArray, int winnerDelta, int userCredit)
    {
        string message;
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
                wonByVerticalLines += winnerDelta;
                anyColumnWinning = true;
            }
        }

        if (anyColumnWinning)
        {
            message = $"Well done, you got {wonByVerticalLines}$ from the vertical lines!";
            userCredit += wonByVerticalLines;
            UiMethods.PrintingWinnerText(message, userCredit);
            
        }
        return userCredit; //no column winning
    }

    public static int CheckingDiagagonals(int[,] userArray, int winningdelta, int userCredit)
    {
        string message;
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
            wonByDiagonals += winningdelta;
            isAnyDiagonalLineWinning = true;
        }

        if (isDiagonal2AWinner)
        {
            wonByDiagonals += winningdelta;
            isAnyDiagonalLineWinning = true;
        }

        if (isAnyDiagonalLineWinning)
        {
            message = $"Well done, you got {wonByDiagonals}$ from the diagonal lines!";
            
            userCredit += wonByDiagonals;
            
            //PRINT WON BY DIAGONALS
            UiMethods.PrintingWinnerText(message, userCredit);
        }
        return userCredit;
    }
}