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

            //constants
            const int WINNERDELTA = 100;
            const int DIMENSION = 3;

            //options for the game modus
            const int OPTION_1_LINE = 1;
            const int OPTION_3_LINES = 3;
            const int OPTION_6_LINES = 6;
            const int OPTION_8_LINES = 8;
            const int OPTION_CHECK_OUT = 9;

            //cost of each modus
            const int COST_1_LINE = 1;
            const int COST_3_LINES = 3;
            const int COST_6_LINES = 8;
            const int COST_8_LINES = 12;

            //welcome and interact with UI to add credit
            int userCredit = UI_Methods.WelcomeUserAndAddSomeCredit();

            // select dimension of the grid
            int[,] userArray = new int [DIMENSION, DIMENSION];

            /*
             Select the bet:
                1L = 1$,
                3L = 3$,
                6L = 8$ or
                8L = 12$
            */
            List<int> optionsLinesModus = new List<int>
                { OPTION_1_LINE, OPTION_3_LINES, OPTION_6_LINES, OPTION_8_LINES, OPTION_CHECK_OUT };
            List<int> optionsLinesCosts = new List<int> { COST_1_LINE, COST_3_LINES, COST_6_LINES, COST_8_LINES };


            while (userCredit > 0)
            {
                // defining the game modus  
                (int gameModus, userCredit) =
                    UI_Methods.AskForLinesSelection(userCredit, optionsLinesModus, optionsLinesCosts);

                if (gameModus == OPTION_CHECK_OUT)
                {
                    break;
                }

                //feed randomly the grid with the values
                userArray = UI_Methods.GeneratingGrid(DIMENSION);

                //Checking the combinations and calculating the new user credit
                userCredit = UI_Methods.CheckingTheCombinations(gameModus, userCredit, optionsLinesModus,
                    optionsLinesCosts, userArray, WINNERDELTA);
            }

            if (userCredit <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You finished playing with the credit: {userCredit}");
                Console.Write("You don't have creadits to play, please insert more money to keep playing");
            }
            
            


        
            //insert more money option
           

            //NEXT STEP: add in the game_modus an array with 0 and 1 for each line which is active and not
            //NEXT STEP: use that array to multiply the winning lines for a fix amount
        }
    }
}