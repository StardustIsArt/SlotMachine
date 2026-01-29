namespace SlotMachine;
public class GameLogic
{
    public static int[,] GenerateReel(Random random)
    {
        int[,] reel = new int[MachineConstants.REEL_SIZE, MachineConstants.REEL_SIZE];
        for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
        {
            for (int col = 0; col < MachineConstants.REEL_SIZE; col++)
            {
                reel[row, col] = random.Next(MachineConstants.MIN_RANDOM, MachineConstants.MAX_RANDOM);
            }
        }
        return reel;
    }
    public static void HandlePayout(bool win, int payout, Action winMessage, ref int money)
    {
        if (win)
        {
            winMessage();
            money += payout;
        }
        else
        {
            UIMethods.DisplayRoundLoss();
            money -= payout;
        }
    }
    public static bool IsHorizontalCenterWinner(int[,] reel)
    {
        int middleRow = reel.GetLength(0) / 2;
        int first = reel[middleRow, 0];
        for (int j = 0; j < reel.GetLength(1); j++)
        {
            if (reel[middleRow, j] != first)
            {
                return false;
            }
        }
        return true;
    }
    public static bool IsVerticalCenterWinner(int[,] reel)
    {
        int middleRow = reel.GetLength(0) / 2;
        int first = reel[0, middleRow];
        for (int j = 0; j < reel.GetLength(0); j++)
        {
            if (reel[j, MachineConstants.MIDDLE_LINE] != first)
            {
                return false;
            }
        }
        return true;
    }
    public static bool IsAllHorizontalLinesWinners(int[,] reel)
    {
        for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
        {
            int first = reel[row, 0];
            bool lineWin = true;
            for (int col = 1; col < reel.GetLength(1); col++)
            {
                if (reel[row, col] != first)
                {
                    lineWin = false;
                    break;
                }
            }
            if (lineWin)
            {
                return true;
            }
        }
        return false;
    }
    public static bool IsAllVerticalLinesWinners(int[,] reel)
    {
        for (int col = 0; col < MachineConstants.REEL_SIZE; col++)
        {
            int first = reel[0, col];
            bool lineWin = true;
            for (int row = 0; row < reel.GetLength(0); row++)
            {
                if (reel[row, col] != first)
                {
                    lineWin = false;
                    break;
                }
            }
            if (lineWin)
            {
                return true;
            }
        }
        return false;
    }
    public static bool DoAnyDiagonalLinesWin(int[,] reel)
    {
        int size = reel.GetLength(0);
        // checking diagonal left-to-right (\)
        bool winLeft = true;
        int firstLeft = reel[0, 0];
                
        for (int i = 1; i < size; i++)
        {
            if (reel[i, i] != firstLeft)
            {
                winLeft = false;
                break;
            }   
        }
        // checking diagonal right-to-left (/)
        bool winRight = true;
        int firstRight = reel[0, size - 1];
        for (int j = 1; j < size; j++)
        {
            if (reel[j, size - 1 - j] != firstRight)
            {
                winRight = false;
                break;
            }
        }
        return winLeft || winRight;
    }
}