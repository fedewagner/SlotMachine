namespace SlotMachine;

public class Logic
{
    //Methods area
    // check only one middle line
    public static (bool, int) CheckingHorizontalLine(int[,] userArray, int winnerdelta)
    {
        int wonByMiddleLine;
        int middleRow = userArray.GetLength(0) / 2;
        int columns = userArray.GetLength(1);
        int first = userArray[middleRow, 0];
        for (int column = 1; column < columns; column++)
        {
            if (userArray[middleRow, column] != first)
            {
                wonByMiddleLine = 0;
                return (false, wonByMiddleLine);
            }
        }

        wonByMiddleLine = winnerdelta;
        Console.WriteLine($"Well done, you got {wonByMiddleLine}$ from the middle line!");
        return (true, wonByMiddleLine);
    }


    //check all horizontal Lines
    public static (bool, int) CheckingAllHorizontalLines(int[,] userArray, int winnerdelta)
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
                wonByHorizontalLines += winnerdelta;
                anyRowWinning = true;
            }
        }

        if (anyRowWinning)
        {
            Console.WriteLine($"Well done, you got {wonByHorizontalLines}$ from the horizontal lines!");
            return (true, wonByHorizontalLines);
            ; //a column is winning
        }

        return (false, wonByHorizontalLines); //no column winning
    }

    //check all Vertical Lines
    public static (bool, int) CheckingAllVerticalLines(int[,] userArray, int winnerdelta)
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
            Console.WriteLine($"Well done, you got {wonByVerticalLines}$ from the vertical lines!");
            return (true, wonByVerticalLines); //a column is winning
        }

        return (false, wonByVerticalLines); //no column winning
    }

    public static (bool, int) CheckingDiagagonals(int[,] userArray, int winningdelta)
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
            Console.WriteLine($"Well done, you got {wonByDiagonals}$ from the diagonal lines!");
        }

        return (isAnyDiagonalLineWinning, wonByDiagonals);
    }
}