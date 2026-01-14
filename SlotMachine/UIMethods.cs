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
                          $"{MachineConstants.CENTER_HORIZONTAL_MODE} - play horizontal center line\n" +
                          $"{MachineConstants.CENTER_VERTICAL_MODE} - play vertical center line\n" +
                          $"{MachineConstants.ALL_HORIZONTAL_MODE} - play all horizontal lines\n" +
                          $"{MachineConstants.ALL_VERTICAL_MODE} - play all vertical lines\n" +
                          $"{MachineConstants.DIAGONAL_MODE} - play both diagonal lines\n" +
                          $"{MachineConstants.ALL_MODE} - play all available lines (horizontal, vertical & diagonal)\n");
    }

    public static void PrintStartingMoney()
    {
        int money = MachineConstants.MONEY_START_OF_GAME;
        Console.WriteLine($"Your starting balance is: {money}\n");
    }

    public static void PrintWagerBet()
    {
        int wager = MachineConstants.ZERO;
        Console.WriteLine($"Your bet is: {wager}\n");
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
    // to check if the user input is valid and in the correct number range.
    public static void GetValidInput()
    {
        int wager;
        bool validInput = false;
        while (!validInput)
        {
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out wager);
            if (!success)
            {
                Console.WriteLine($"Invalid input, please choose a valid number between {MachineConstants.CENTER_HORIZONTAL_MODE} and {MachineConstants.ALL_MODE}.");
                continue;
            }
            if (wager < MachineConstants.MIN_RANDOM || wager > MachineConstants.MAX_RANDOM)
            {
                Console.WriteLine($"Invalid input, please choose a valid number between {MachineConstants.CENTER_HORIZONTAL_MODE} and {MachineConstants.ALL_MODE}.");
                continue;
            }
            validInput = true;
        }
    }
}