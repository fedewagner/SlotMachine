namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //give intro an explain rules
            UiMethods.WelcomeUser();
            
            //welcome and interact with UI to add credit
            int userCredit = 0;
            bool gameMode;
            string selection;
            
            //Adding credit for the user and asking for play mode
            do
            {
                //add mode credit 
                UiMethods.OfferAddingCredit();
            
                //or go into game mode
                UiMethods.OfferGamingMode();
                
                //read key method
                (userCredit, gameMode, selection) = UiMethods.ReadUserKey(userCredit);
                
            } while ((selection == Constants.KEY_FOR_ADDING_CREDIT || selection == Constants.KEY_FOR_GAMING ) && !gameMode); //if the gamemode is activated then we leave this loop

            //in case the user has more money, then he can play
            while (userCredit > 0)
            {
                // defining the game modus  
                int gameModus = UiMethods.AskForLinesSelection();

                //checking the selected mode
                (userCredit, bool isMoneyEnough) = UiMethods.CheckingSelectedMode(userCredit, gameModus);

                //if user want to check out
                if (gameModus == Constants.OPTION_CHECK_OUT)
                {
                    break; // we go out from Playing Modus
                }
                
                //if user has enough money
                if (isMoneyEnough)
                {
                    //feed randomly the grid with the values
                    int[,] userArray = Logic.GeneratingElementsForGrid();

                    //print the grid with the values
                    UiMethods.PrintingGrid(userArray);

                    //Checking the combinations and calculating the new user credit if wins
                    int wonInTheBet;
                    
                    (userCredit, wonInTheBet) = Logic.CheckingTheCombinations(gameModus, userCredit, userArray);
                    
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