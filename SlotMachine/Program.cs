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

            const int CREDIT_DELTA = 100;
            const string KEY_FOR_ADDING_CREDIT = "f";
            const string KEY_FOR_GAMING = "p";
            
            int dimension = 3;
            
            List<string> options_menu = new List<string> { KEY_FOR_ADDING_CREDIT,  KEY_FOR_GAMING };
            int[,] userArray = new int [dimension, dimension];
            
            //variables
            int userCredit = 0;
            bool gameMode = false;
            string selection;

            //give info to user
            Console.WriteLine("Welcome to the Slot Machine!");

            //Add initial credit
            do
            {
                Console.WriteLine("Please enter some credit (Press F)!");
                selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
            } 
            while (!Equals(selection, KEY_FOR_ADDING_CREDIT));
            userCredit += CREDIT_DELTA;
            Console.WriteLine($"Your current credit: {userCredit} $");
            
            //add mode credit or go into game mode
            Console.WriteLine("In case you want to add more money please insert banknote (Press F)!");
            Console.WriteLine("Otherwise, to play (Press P)!");
            
            while (options_menu.Contains(selection) && !gameMode) {
                selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
                switch(selection)
                {
                    case "p": gameMode = true; break;
                    case "f":
                    {
                        userCredit += 100; 
                        Console.WriteLine($"Your current credit: {userCredit} $");
                        Console.WriteLine("More money? => (Press F)! or to play (Press P)!");
                        break;
                    }
                }
            } 
            
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