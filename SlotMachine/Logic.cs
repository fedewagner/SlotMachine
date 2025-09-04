namespace SlotMachine;

public class Logic
{
     //Methods area
            // check only one middle line
            public static bool CheckingHorizontalLine(int[,] userArray)
            {
                int middleRow = userArray.GetLength(0) / 2;
                int columns = userArray.GetLength(1);
                int first = userArray[middleRow, 0];
                for (int column = 1; column < columns; column++)
                {
                    if (userArray[middleRow, column] != first)
                    {
                        return false;
                    }
                }
                Console.WriteLine("Well done, you got a middle line!");
                return true;
            }
            
            
            //check all horizontal Lines
            public static bool CheckingAllHorizontalLines(int[,] userArray)
            {
                int rows = userArray.GetLength(0);
                int columns = userArray.GetLength(1);
                for (int row = 0; row < rows; row++)
                {
                    int first = userArray[row, 0];
                    bool rowWin = true;
                    for (int column = 1; column < columns; column++)
                    {
                        if (userArray[row, column] != first)
                        {
                            rowWin = false;
                            break;
                        }
                    }

                    if (rowWin)
                    {
                        Console.WriteLine("Well done, you got a horizontal line!");
                        return true;
                    }
                }
                return false;
            }
            
            //check all Vertical Lines
            public static bool CheckingAllVerticalLines(int[,] userArray)
            {
                int rows = userArray.GetLength(0);
                int columns = userArray.GetLength(1);

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
                        Console.WriteLine("Well done, you got a vertical line!");
                        return true; //a column is winning
                    }
                }
                return false; //no column winning
            }

            public static bool CheckingDiagagonals(int[,] userArray)
            {
                int rows = userArray.GetLength(0);
                int columns = userArray.GetLength(1);
                bool isDiagonal1AWinner = true;
                bool isDiagonal2AWinner = true;
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
                for (int row = lastRow-1, col = 1; row >= 0 && col < columns; row--, col++)
                {
                    if (userArray[row, col] != firstElementDiagonal2)
                    {
                        isDiagonal2AWinner = false;
                        break;
                    }
                }
                Console.WriteLine("Well done, you got a diagonal line!");
                return isDiagonal1AWinner || isDiagonal2AWinner;
            }
}