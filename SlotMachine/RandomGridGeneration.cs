using System.Reflection.Metadata.Ecma335;

namespace SlotMachine;

public class RandomGridGeneration
{
    public static Array GeneratingGrid()
    {
        const int MIN_FOR_RANDOM_FUNCTION = 1;
        const int MAX_FOR_RANDOM_FUNCTION = 9;
        
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
                //random generation
                Random random = new Random();
                int randomItem = random.Next(MIN_FOR_RANDOM_FUNCTION, MAX_FOR_RANDOM_FUNCTION);
                userArray[col, row] = randomItem;
                
                if (col % 2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
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
        
        return userArray;
    }
}