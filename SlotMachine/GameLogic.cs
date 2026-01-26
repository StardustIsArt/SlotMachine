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

    private static void HandlePayout(bool win, int payout, Action winMessage, ref int money)
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
    public static bool CheckHorizontalCenterWin(int[,] reel, ref int money)
    {
        bool win = true;
        int middleRow = reel.GetLength(0) / 2;
        int first = reel[middleRow, 0];
        for (int j = 0; j < reel.GetLength(1); j++)
        {
            if (reel[middleRow, j] != first)
            {
                win = false;
                break;
            }
        }

        HandlePayout(win, MachineConstants.MIDDLE_LINE_PAYOUT, UIMethods.DisplayHorizontalPayout, ref money);
        return win;
    }
    public static bool CheckVerticalCenterWin(int[,] reel, ref int money)
    {
        UIMethods.DisplayVerticalCenterCheck();
        bool win = true;
        int middleRow = reel.GetLength(0) / 2;
        int first = reel[0, middleRow];
        for (int j = 0; j < reel.GetLength(0); j++)
        {
            if (reel[j, MachineConstants.MIDDLE_LINE] != first)
            {
                win = false;
                break;
            }
        }
        HandlePayout(win, MachineConstants.MIDDLE_LINE_PAYOUT, UIMethods.DisplayVerticalPayout, ref money);
        return win;
    }
    public static bool CheckAllHorizontalLinesWin(int[,] reel, ref int money)
    {
        bool anyWins = false;
        for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
        {
            int first = reel[row, 0];
            bool lineWin = true;
            for (int col = 0; col < reel.GetLength(0); col++)
            {
                if (reel[row, col] != first)
                {
                    lineWin = false;
                    break;
                }
            }
            if (lineWin)
            {
                anyWins = true;
                Console.WriteLine($"Line {row + 1} is a winner!");
            }
        }
        HandlePayout(anyWins, MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT, UIMethods.DisplayAllHorizontalLinesPayout, ref money);
        return anyWins;
    }
    public static bool CheckAllVerticalLinesWin(int[,] reel, ref int money)
    {
        bool anyWins = false;
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
                anyWins = true;
                Console.WriteLine($"Line {col + 1} is a winner!");
            }
        }
        HandlePayout(anyWins, MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT, UIMethods.DisplayAllVerticalLinesPayout, ref money);
        if (anyWins)
        {
            UIMethods.DisplayAllVerticalLinesPayout();
            money += MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT;
        }
        else
        {
            UIMethods.DisplayRoundLoss();
            money -= MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT;
        }
        return anyWins;
    }
    public static bool CheckAllDiagonalLinesWin(int[,] reel, ref int money)
    {
        int size = reel.GetLength(0);
        // checking diagonal left-to-right (\)
        bool winLeft = true;
        int firstLeft = reel[0, 0];
                
        for (int j = 1; j < size; j++)
        {
            if (reel[j, j] != firstLeft)
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
        HandlePayout(winLeft || winRight, MachineConstants.DIAGONAL_PAYOUT, UIMethods.DisplayDiagonalPayout, ref money);
        return winLeft || winRight;
    }
}