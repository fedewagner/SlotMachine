namespace SlotMachine;

public class CheckWinners
{
    public static bool[] CheckingWinners(int[,] userArray)
    {
        bool[] winnersArray = new bool[8];
        bool IS_LINE_V1_A_WINNER = false;
        bool IS_LINE_V2_A_WINNER = false;
        bool IS_LINE_V3_A_WINNER = false;
        bool IS_LINE_H1_A_WINNER = false;
        bool IS_LINE_H2_A_WINNER = false;
        bool IS_LINE_H3_A_WINNER = false;
        bool IS_LINE_D1_A_WINNER = false;
        bool IS_LINE_D2_A_WINNER = false;

        //check horizontal
        if (userArray[1, 0] == userArray[1, 1] && userArray[1, 1] == userArray[1, 2])
        {
            IS_LINE_H1_A_WINNER = true;
        }

        if (userArray[0, 0] == userArray[0, 1] && userArray[0, 1] == userArray[0, 2])
        {
            IS_LINE_H2_A_WINNER = true;
        }

        if (userArray[2, 0] == userArray[2, 1] && userArray[2, 1] == userArray[2, 2])
        {
            IS_LINE_H3_A_WINNER = true;
        }

        //check vertical
        if (userArray[0, 1] == userArray[1, 1] && userArray[1, 1] == userArray[2, 1])
        {
            IS_LINE_V1_A_WINNER = true;
        }

        if (userArray[0, 0] == userArray[1, 0] && userArray[1, 0] == userArray[2, 0])
        {
            IS_LINE_V2_A_WINNER = true;
        }

        if (userArray[0, 2] == userArray[1, 2] && userArray[1, 2] == userArray[2, 2])
        {
            IS_LINE_V3_A_WINNER = true;
        }

        //check diagonals
        if (userArray[2, 0] == userArray[1, 1] && userArray[1, 1] == userArray[0, 2])
        {
            IS_LINE_D1_A_WINNER = true;
        }

        if (userArray[0, 0] == userArray[1, 1] && userArray[1, 1] == userArray[2, 2])
        {
            IS_LINE_D2_A_WINNER = true;
        }

        //Assign
        winnersArray[0] = IS_LINE_H1_A_WINNER;
        winnersArray[1] = IS_LINE_H2_A_WINNER;
        winnersArray[2] = IS_LINE_H3_A_WINNER;
        winnersArray[3] = IS_LINE_V1_A_WINNER;
        winnersArray[4] = IS_LINE_V2_A_WINNER;
        winnersArray[5] = IS_LINE_V3_A_WINNER;
        winnersArray[6] = IS_LINE_D1_A_WINNER;
        winnersArray[7] = IS_LINE_D2_A_WINNER;

        return winnersArray;
    }
}