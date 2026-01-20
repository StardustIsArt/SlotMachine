namespace SlotMachine;

public class GameLogic
{
    public static int[,] GenerateReel()
    {
        int[,] reel = new int[MachineConstants.REEL_SIZE, MachineConstants.REEL_SIZE];
        for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
        {
            for (int col = 0; col < MachineConstants.REEL_SIZE; col++)
            {
                reel[row, col] = number.Next(MachineConstants.MIN_RANDOM, MachineConstants.MIN_RANDOM);
            }
        }
    }
}