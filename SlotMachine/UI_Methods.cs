namespace SlotMachine;

public class UI_Methods
{
    public static int WelcomeUserAndAddSomeCredit()
    {
        const int CREDIT_DELTA = 100;
        const string KEY_FOR_ADDING_CREDIT = "f";
        const string KEY_FOR_GAMING = "p";
        
        //variables
        int userCredit = 0;
        bool gameMode = false;
        string selection;
        
        //define keys for user to be pressed
        List<string> options_menu = new List<string> { KEY_FOR_ADDING_CREDIT,  KEY_FOR_GAMING };
 
        
        //give info to user
        Console.WriteLine("Welcome to the Slot Machine!");

        //Add initial credit
        do
        {
            Console.WriteLine($"Please enter some credit (Press {options_menu[0]})!");
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
        } 
        while (!Equals(selection, KEY_FOR_ADDING_CREDIT));
        userCredit += CREDIT_DELTA;
        Console.WriteLine($"Your current credit: {userCredit} $");
        
        //add mode credit or go into game mode
        Console.WriteLine($"In case you want to add more money please insert banknote (Press {options_menu[0]})!");
        Console.WriteLine($"Otherwise, to play (Press {options_menu[1]})!");
            
        while (options_menu.Contains(selection) && !gameMode) {
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();
            switch(selection)
            {
                case "p": gameMode = true; break;
                case "f":
                {
                    userCredit += 100; 
                    Console.WriteLine($"Your current credit: {userCredit} $");
                    Console.WriteLine($"More money? => (Press {options_menu[0]})! or to play (Press {options_menu[1]})!");
                    break;
                }
            }
        } 
        
        return userCredit;
    }
}