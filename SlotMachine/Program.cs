namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List declarations with the packed constants
            //List for option with amount of lines
            List<int> optionsLinesModus = new List<int>
                { Constants.OPTION_1_LINE, Constants.OPTION_3_LINES, Constants.OPTION_6_LINES, Constants.OPTION_8_LINES, Constants.OPTION_CHECK_OUT };
            
            //List for the cost of the different options
            List<int> optionsLinesCosts = new List<int> 
                { Constants.COST_1_LINE, Constants.COST_3_LINES, Constants.COST_6_LINES, Constants.COST_8_LINES };
            
            //List with the key options
            List<string> optionsMenu = new List<string> { Constants.KEY_FOR_ADDING_CREDIT, Constants.KEY_FOR_GAMING };

            
            //give intro an explain rules
            UiMethods.WelcomeUser(Constants.WINNING_DELTA);
            
            //welcome and interact with UI to add credit
            int userCredit = 0;
            bool gameMode;
            string selection;
            
            //Adding credit for the user and asking for play mode
            do
            {
                //add mode credit 
                UiMethods.OfferAddingCredit(optionsMenu);
            
                //or go into game mode
                UiMethods.OfferGamingMode(optionsMenu);
                
                //read key method
                (userCredit, gameMode, selection) = UiMethods.ReadUserKey(userCredit, optionsMenu);
                
            } while (optionsMenu.Contains(selection) && !gameMode); //if the gamemode is activated then we leave this loop

            //in case the user has more money, then he can play
            while (userCredit > 0)
            {
                // defining the game modus  
                int gameModus = UiMethods.AskForLinesSelection(optionsLinesModus, optionsLinesCosts);

                //checking the selected mode
                (userCredit, bool isMoneyEnough) = UiMethods.CheckingSelectedMode(userCredit, gameModus, optionsLinesModus ,optionsLinesCosts);

                //if user want to check out
                if (gameModus == Constants.OPTION_CHECK_OUT)
                {
                    break; // we go out from Playing Modus
                }
                
                //if user has enough money
                if (isMoneyEnough)
                {
                    //feed randomly the grid with the values
                    int[,] userArray = Logic.GeneratingElementsForGrid(Constants.DIMENSION, Constants.MIN_FOR_RANDOM_FUNCTION,
                        Constants.MAX_FOR_RANDOM_FUNCTION);

                    //print the grid with the values
                    UiMethods.PrintingGrid(userArray);

                    //Checking the combinations and calculating the new user credit if wins
                    int wonInTheBet;
                    
                    (userCredit, wonInTheBet) = Logic.CheckingTheCombinations(gameModus, userCredit, optionsLinesModus, userArray,
                        Constants.WINNING_DELTA);
                    
                    //Printing message
                    UiMethods.PrintingWinnerText(wonInTheBet);
                    
                    //printing user credit
                    UiMethods.ShowsCredit(userCredit);
                }
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