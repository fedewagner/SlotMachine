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
            bool gameMode = false;
            string selection;
            
            
            //Adding credit for the user and asking for play mode
            bool isAddingMoneyOrPlaying;
            
            do
            {
                //add mode credit 
                UiMethods.OfferAddingCredit();
            
                //or go into game mode
                UiMethods.OfferGamingMode();
                
                //read key method and avoid other inputs
                selection = UiMethods.CheckUserKeyInput();
                
                //Switch if F or P for checking the pressed key
                switch (selection)
                {
                    case Constants.KEY_FOR_GAMING: //user pressed "p"
                    {
                        gameMode = UiMethods.CheckEnoughMoney(userCredit);
                        break;
                    }
                    case Constants.KEY_FOR_ADDING_CREDIT: //user pressed "f"
                    {
                        userCredit = Logic.AddUserCredit(userCredit);
                        //Prints credit
                        UiMethods.ShowsCredit(userCredit);
                        break;
                    }
                }
                
                //variable for checking logic
                isAddingMoneyOrPlaying = (selection == Constants.KEY_FOR_ADDING_CREDIT || selection == Constants.KEY_FOR_GAMING);

            } while (isAddingMoneyOrPlaying && !gameMode); //if the gamemode is activated then we leave this loop

            //in case the user has more money, then he can play
            while (userCredit > 0)
            {
                // defining the game modus  
                int gameModus = UiMethods.AskForLinesSelection();

                //checking the credit

                bool isMoneyEnough = false;
               
                switch (gameModus)
                    {
                    
                    case Constants.OPTION_8_LINES:
                        isMoneyEnough = UiMethods.CheckingCredit(userCredit, Constants.COST_8_LINES);
                        if (isMoneyEnough)
                        {
                            userCredit = UiMethods.RestingUsersCredit(userCredit, Constants.COST_8_LINES);
                        }
                        break;
                    
                    case Constants.OPTION_6_LINES:
                        isMoneyEnough = UiMethods.CheckingCredit(userCredit, Constants.COST_6_LINES);
                        if (isMoneyEnough)
                        {
                            userCredit = UiMethods.RestingUsersCredit(userCredit, Constants.COST_6_LINES);
                        }
                        break;
                    
                    case Constants.OPTION_3_LINES:
                        isMoneyEnough = UiMethods.CheckingCredit(userCredit, Constants.COST_3_LINES);
                        if (isMoneyEnough)
                        {
                            userCredit = UiMethods.RestingUsersCredit(userCredit, Constants.COST_3_LINES);
                        }
                        break;
                    
                    case Constants.OPTION_1_LINE:
                        isMoneyEnough = UiMethods.CheckingCredit(userCredit, Constants.COST_1_LINE);
                        if (isMoneyEnough)
                        {
                            userCredit = UiMethods.RestingUsersCredit(userCredit, Constants.COST_1_LINE);
                        }
                        break;
                }
                
                //if user want to check out
                if (gameModus == Constants.OPTION_CHECK_OUT)
                {
                    UiMethods.UserChecksOut(userCredit);
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