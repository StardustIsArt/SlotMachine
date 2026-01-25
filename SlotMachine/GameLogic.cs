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

    public static void CheckHorizontalCenterWin(int[,] reel, ref int money)
    {
        UIMethods.DisplayHorizontalCenter();
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
        if (win)
        {
            UIMethods.DisplayHorizontalPayout();
            money += MachineConstants.MIDDLE_LINE_PAYOUT;
        }
        else
        {
            UIMethods.DisplayRoundLoss();
            money -= MachineConstants.MIDDLE_LINE_PAYOUT;
        }
        
    }
}