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
            
            //constant
            const int WINNERDELTA = 10;
            
            //variable definition
            int userCredit;

            //welcome and interact with UI to add credit
            userCredit = UI_Methods.WelcomeUserAndAddSomeCredit();

            // select dimension of the grid
            const int DIMENSION = 3;
            int[,] userArray = new int [DIMENSION, DIMENSION];

            //TO_BE_ADDED: create horizontal method
            //TO_BE_ADDED: create vertical method
            //TO_BE_ADDED: create diagonal method

            /*
             Select the bet:
                1L = 1$, 
                3L = 3$, 
                6L = 8$ or 
                8L = 12$
            */
            
            const int OPTION_1_LINE = 1;
            const int OPTION_3_LINES = 3;
            const int OPTION_6_LINES = 6;
            const int OPTION_8_LINES = 8;
    
            const int COST_1_LINE = 1;
            const int COST_3_LINES = 3;
            const int COST_6_LINES = 8;
            const int COST_8_LINES = 12;
            
            List<int> optionsLinesModus = new List<int> { OPTION_1_LINE, OPTION_3_LINES, OPTION_6_LINES, OPTION_8_LINES };
            List<int> optionsLinesCosts = new List<int> { COST_1_LINE, COST_3_LINES, COST_6_LINES, COST_8_LINES };
            
            int game_modus;
            (game_modus, userCredit) = UI_Methods.AskForLinesSelection(userCredit,  optionsLinesModus, optionsLinesCosts);


            //feed randomly the grid with the values
            userArray = UI_Methods.GeneratingGrid(DIMENSION);

            //check all the combinations

            switch (game_modus)
            {
                case OPTION_1_LINE:
                    if (Logic.CheckingHorizontalLine(userArray))
                    {
                        userCredit += WINNERDELTA;
                        Console.WriteLine($"You won {WINNERDELTA}$!");
                    } 
                    break;
                case OPTION_3_LINES:
                    if (Logic.CheckingAllHorizontalLines(userArray))
                    {
                        userCredit += WINNERDELTA;
                        Console.WriteLine($"You won {WINNERDELTA}$!");
                    } 
                    break;
                case OPTION_6_LINES:
                    if (Logic.CheckingAllHorizontalLines(userArray) || Logic.CheckingAllVerticalLines(userArray))
                    {
                        userCredit += WINNERDELTA;
                        Console.WriteLine($"You won {WINNERDELTA}$!");
                    } 
                    break;
                case OPTION_8_LINES:
                    if (Logic.CheckingAllHorizontalLines(userArray) || Logic.CheckingAllVerticalLines(userArray) || Logic.CheckingDiagagonals(userArray))
                    {
                        userCredit += WINNERDELTA;
                        Console.WriteLine($"You won {WINNERDELTA}$!");
                    } 
                    break;
            }
            
            Console.WriteLine($"The user credit is: {userCredit}");
            

            //NEXT STEP: add in the game_modus an array with 0 and 1 for each line which is active and not
            //NEXT STEP: use that array to multiply the winning lines for a fix amount



            //display prize
            //calculate new credit
            //check out money option
            //insert more money option

           

        }
    }
}