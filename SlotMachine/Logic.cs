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


    public static int AddMoneyToUsersCredit(int userCredit, int moneyToAdd)
    {
        userCredit += moneyToAdd;
        return userCredit;
    }


    public static int CheckingTheCombinations(int gameModus, int[,] userArray)
    {
        int wonInTheBet = 0;

        switch (gameModus)
        {
            case Constants.OPTION_1_LINE:
                wonInTheBet = CheckingHorizontalLine(userArray);
                break;
            
            case Constants.OPTION_3_LINES:
                wonInTheBet = CheckingAllHorizontalLines(userArray);
                break;
            
            case Constants.OPTION_6_LINES:
                //From Horizonal Lines
                int wonInTheBetHorizontal = CheckingAllHorizontalLines(userArray);
                //From Vertical Lines
                int wonInTheBetVertical = CheckingAllVerticalLines(userArray);

                wonInTheBet = wonInTheBetHorizontal + wonInTheBetVertical;
                break;
            
            case Constants.OPTION_8_LINES:
                //From all Horizonal Lines
                wonInTheBetHorizontal = CheckingAllHorizontalLines(userArray);
                //From Vertical Lines
                wonInTheBetVertical = CheckingAllVerticalLines(userArray);
                //From Diagonal Lines
                int wonInTheBetDiagonal = CheckingDiagonals(userArray);

                wonInTheBet = wonInTheBetHorizontal + wonInTheBetVertical + wonInTheBetDiagonal;

                break;
        }

        return wonInTheBet;

    }


    //Methods area
    // check only one middle line
    public static  int CheckingHorizontalLine(int[,] userArray)
    {
        int wonByMiddleLine = 0;
        
        int middleRow = userArray.GetLength(0) / 2;
        int columns = userArray.GetLength(1);
        int first = userArray[middleRow, 0];
        for (int column = 1; column < columns; column++)
        {
            if (userArray[middleRow, column] != first)
            {
                return wonByMiddleLine;
            }
        }
        wonByMiddleLine = Constants.WINNING_DELTA;
        
        return wonByMiddleLine ;
    }


    //check all horizontal Lines
    public static int CheckingAllHorizontalLines(int[,] userArray)
    {
        int rows = userArray.GetLength(0);
        int columns = userArray.GetLength(1);
        int wonByHorizontalLines = 0;
        
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
            }
        }
        
        return wonByHorizontalLines;
    }

    //check all Vertical Lines
    public static int CheckingAllVerticalLines(int[,] userArray)
    {
        int rows = userArray.GetLength(0);
        int columns = userArray.GetLength(1);
        int wonByVerticalLines = 0;
        
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
            }
        }
        
        return wonByVerticalLines; //no column winning
    }

    public static int CheckingDiagonals(int[,] userArray)
    {
        int rows = userArray.GetLength(0);
        int columns = userArray.GetLength(1);
        bool isDiagonal1AWinner = true;
        bool isDiagonal2AWinner = true;
        int wonByDiagonals = 0;
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
        }

        if (isDiagonal2AWinner)
        {
            wonByDiagonals += Constants.WINNING_DELTA;
        }
     
        return wonByDiagonals;
    }
}