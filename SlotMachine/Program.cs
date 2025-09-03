namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Design a game where the user can play a make-believe slot machine.
                The user will be asked to make a wager to play various lines in a 3 x 3 grid.
                They can play center line, all three horizontal lines, all vertical lines and diagonals.
                For instance the user can enter $3 dollars and play all three horizontal lines.
                If the top line hits a winning combination, they earn $1 dollar for that line.
            */

            int userCredit;

            //welcome and interact with UI to add credit
            userCredit = UI_Methods.WelcomeUserAndAddSomeCredit();

            // select dimension of the grid
            const int DIMENSION = 3;
            int[,] userArray = new int [DIMENSION, DIMENSION];

            //make and show an empty grid
            UI_Methods.DisplayEmptyGrid(userArray);

            //TO_BE_ADDED: create horizontal method
            //TO_BE_ADDED: create vertical method
            //TO_BE_ADDED: create diagonal method

            //select the bet 1L = 1$, 3L = 3$, 6L = 8$ or 8L = 12$
            int game_modus;
            game_modus = UI_Methods.AskForLinesSelection(userCredit);

            //TO_BE_ADDED: Clean screen
            //TO_BE_ADDED: you bet and credit
            //TO_BE_ADDED ADITIONAL: some animation

            //feed randomly the grid with the values
            userArray = UI_Methods.GeneratingGrid(DIMENSION);

            //check all the combinations

            bool isOption1AWinner;
            bool isOption2AWinner;
            bool isOption3AWinner;
            bool isOption4AWinner;

            // 1 Middle line mode
            int rowToCheck = userArray.GetLength(0) / 2;
            isOption1AWinner = CheckingHorizontalLine(userArray, rowToCheck);
            Console.WriteLine($"Is the middle line a winner?:  {isOption1AWinner}");

            // 2 Check All horizontal lines mode
            isOption2AWinner = CheckingAllHorizontalLines(userArray);
            Console.WriteLine($"Is any horizontal line a winner?:  {isOption2AWinner}");

            // 3 All vertical lines mode
            isOption3AWinner = CheckingAllVerticalLines(userArray);
            Console.WriteLine($"Is any vertical line a winner?:  {isOption3AWinner}");
            // 4 2 diagonals mode
            isOption4AWinner = CheckingDiagagonals(userArray);
            Console.WriteLine($"Is any diagonal line a winner?:  {isOption4AWinner}");


            //NEXT STEP: add in the game_modus an array with 0 and 1 for each line which is active and not
            //NEXT STEP: use that array to multiply the winning lines for a fix amount



            //display prize
            //calculate new credit
            //check out money option
            //insert more money option

            //Methods area
            // check only one middle line
            static bool CheckingHorizontalLine(int[,] userArray, int rowToCheck)
            {
                int columns = userArray.GetLength(1);
                int first = userArray[rowToCheck, 0];
                for (int column = 1; column < columns; column++)
                {
                    if (userArray[rowToCheck, column] != first)
                    {
                        return false;
                    }
                }

                return true;
            }
            
            
            //check all Vertical Lines
            static bool CheckingAllHorizontalLines(int[,] userArray)
            {
                int rows = userArray.GetLength(0);
                for (int row = 0; row < rows; row++)
                {
                    if (CheckingHorizontalLine(userArray, row))
                        return true;
                }

                return false;
            }
            
            //check all Vertical Lines
            static bool CheckingAllVerticalLines(int[,] userArray)
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

                    if (columnWinning) return true; //a column is winning
                }

                return false; //no column winning
            }

            static bool CheckingDiagagonals(int[,] userArray)
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
                return isDiagonal1AWinner || isDiagonal2AWinner;
            }

        }
    }
}