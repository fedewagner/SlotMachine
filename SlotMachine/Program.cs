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
            const int WINNERDELTA = 50;
            const int DIMENSION = 3;
            
            //Min and max
            const int MIN_FOR_RANDOM_FUNCTION = 1;
            const int MAX_FOR_RANDOM_FUNCTION = 9;

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
            int userCredit = UiMethods.WelcomeUserAndAddSomeCredit(WINNERDELTA);

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
                    UiMethods.AskForLinesSelection(userCredit, optionsLinesModus, optionsLinesCosts);

                if (gameModus == OPTION_CHECK_OUT)
                {
                    break;
                }

                //feed randomly the grid with the values
                userArray = UiMethods.GeneratingGrid(DIMENSION, MIN_FOR_RANDOM_FUNCTION, MAX_FOR_RANDOM_FUNCTION);

                //Checking the combinations and calculating the new user credit
                userCredit = UiMethods.CheckingTheCombinations(gameModus, userCredit, optionsLinesModus, userArray,
                    WINNERDELTA);
            }

            //check if there is enough money for each game modus to play
            if (userCredit <= 0)
            {
                UiMethods.AskingUserToLeaveBecauseOfNoMoneyLeft(userCredit);
            }
            
            
            //insert more money option
            
        }
    }
}