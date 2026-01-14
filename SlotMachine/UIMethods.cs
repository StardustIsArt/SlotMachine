namespace SlotMachine;

public class UIMethods
{
    public static void PrintWelcome()
    {
        Console.WriteLine("Step right up and check your luck!\n");
    }
    public static void PrintBettingOptions()
    {
        Console.WriteLine($"How much would you like to bet: 1 - 6: \n" +
                          $"1 - play horizontal center line\n" +
                          $"2 - play vertical center line\n" +
                          $"3 - play all horizontal lines\n" +
                          $"4 - play all vertical lines\n" +
                          $"5 - play both diagonal lines\n" +
                          $"6 - play all available lines (horizontal, vertical & diagonal)\n");
    }
    public static void PrintWagerChoice()
    {
        Console.WriteLine("What is your choice in wager (1 - 6): ");
    }

    public static void PrintReel(int[,] reel)
    {
        for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
        {
            for (int col = 0; col < MachineConstants.REEL_SIZE; col++)
            {
                Console.Write($" {reel[row, col]}");
                if (col < MachineConstants.REEL_SIZE - 1) Console.Write(" |");
            }
            Console.WriteLine();
            if (row < MachineConstants.REEL_SIZE - 1)
            {
                for (int i = 0; i < MachineConstants.REEL_SIZE; i++)
                {
                    Console.Write("----");
                    if (i < MachineConstants.REEL_SIZE - 1) Console.Write("+");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}