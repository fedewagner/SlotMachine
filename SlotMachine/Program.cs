namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {/*
            Design a game where the user can play a make-believe slot machine. 
            The user will be asked to make a wager to play various lines in a 3 x 3 grid. 
            They can play center line, all three horizontal lines, all vertical lines and diagonals.
            For instance the user can enter $3 dollars and play all three horizontal lines. 
            If the top line hits a winning combination, they earn $1 dollar for that line.
        */

            int userCredit = 0;
            
            //welcome and interact with UI to add credit
            userCredit = UI_Methods.WelcomeUserAndAddSomeCredit();
            
            const int DIMENSION = 3;
            int[,] userArray = new int [DIMENSION, DIMENSION];
 
            
            //make and show an empty grid
            SlotMachine.ShowInitialGrid.DisplayEmptyGrid();
            
            //create horizontal method
            //create vertical method
            //create diagonal method
            
            //select the bet 1L = 1$, 3L = 3$, 6L = 8$ or 8L = 12$
            int game_modus = 0;
            game_modus = SlotMachine.LinesSelection.AskForLinesSelection(userCredit);
            
            //Clean screen
            //you bet and credit
            //ADITIONAL: some animation
            
            //feed randomly the grid with the values
            userArray = SlotMachine.RandomGridGeneration.GeneratingGrid();

            //check all the combinations
            bool[] winnersArray = new bool [8];
            winnersArray = SlotMachine.CheckWinners.CheckingWinners(userArray);

            //check the bet and if the user won money

            for (int i = 0; i < winnersArray.Length; i++)
            {
                Console.WriteLine("Line number " + (i + 1) + " is a winner?: "+ winnersArray[i]);
            }
            
            //NEXT STEP: add in the gamemodus an array with 0 and 1 for each line which is active and not
            //NEXT STEP: use that array to multiply the winning lines for a fix amount
            // L1 = 2$
            // L2 = 2$
            // L3 = 2$
            // L4 = 3$
            // L5 = 3$
            // L6 = 3$
            // L7 = 5$
            // L8 = 5$
            
            
            //display prize
            //calculate new credit
            //check out money option
            //insert more money option 


        }
    }
}