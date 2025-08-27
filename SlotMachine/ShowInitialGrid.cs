namespace SlotMachine;

public class ShowInitialGrid
{
    public static void DisplayEmptyGrid()
    {
        int dimension = 3;
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
                Console.ForegroundColor = ConsoleColor.White;
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

        Console.Write("+");
    }
}