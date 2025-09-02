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

            int userCredit;
            
            //welcome and interact with UI to add credit
            userCredit = UI_Methods.WelcomeUserAndAddSomeCredit();
            
            // select dimension of the grid
            const int DIMENSION = 3;
            int[,] userArray = new int [DIMENSION, DIMENSION];
 
            //make and show an empty grid
            UI_Methods.DisplayEmptyGrid(DIMENSION);
            
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
            userArray = Data_Source.GeneratingGrid(DIMENSION);

            //check all the combinations
            // 1 Middle line mode
            // 2 All horizontal lines mode
            // 3 All vertical lines mode
            // 4 2 diagonals mode
            
            bool[] winnersArray = new bool [4];
            winnersArray = UI_Methods.CheckingWinners(userArray, DIMENSION);

            //check the bet and if the user won money

            for (int i = 0; i < winnersArray.Length; i++)
            {
                Console.WriteLine("Is option " + (i + 1) + " a winner?: "+ winnersArray[i]);
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