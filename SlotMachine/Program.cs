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
            const int OPTION_1_LINE = 1;
            const int OPTION_3_LINES = 3;
            const int OPTION_6_LINES = 6;
            const int OPTION_8_LINES = 8;
            
            List<string> options_menu = new List<string> { KEY_FOR_ADDING_CREDIT,  KEY_FOR_GAMING };
            List<int> optionsLinesModus = new List<int> { 1,3,6,8 };
            
            //variable
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
            userCredit = userCredit + CREDIT_DELTA;
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
                        userCredit = userCredit + 100; 
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
            Console.WriteLine($"How many lines to you want to play?");
            Console.WriteLine($"1 Line  = 1$  (Press {OPTION_1_LINE})");
            Console.WriteLine($"3 Lines = 3$  (Press {OPTION_3_LINES})");
            Console.WriteLine($"6 Lines = 6$  (Press {OPTION_6_LINES})");
            Console.WriteLine($"8 Lines = 12$ (Press {OPTION_8_LINES})");

            bool success;
            int selection_lines;
            int game_modus = 0;
            
            do
            {
                success = int.TryParse(Console.ReadKey(true).KeyChar.ToString() , out selection_lines);
            } 
            while (!success || !optionsLinesModus.Contains(selection_lines));

            switch (selection_lines)
            {
                case OPTION_1_LINE: game_modus = OPTION_1_LINE; break;
                case OPTION_3_LINES: game_modus = OPTION_3_LINES; break;
                case OPTION_6_LINES: game_modus = OPTION_6_LINES; break;
                case OPTION_8_LINES: game_modus = OPTION_8_LINES; break;
            }
            Console.WriteLine($"Your current credit: {userCredit} and selected bet is {game_modus} Lines$");
            
            //ADITIONAL: some animation
            
            //feed randomly the grid with the values
            //check all the combinations
            //check the bet and if the user won money
            //display prize
            //calculate new credit
            //check out money option
            //insert more money option 


        }
    }
}