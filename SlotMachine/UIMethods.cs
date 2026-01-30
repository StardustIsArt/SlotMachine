using System.Reflection.PortableExecutable;

namespace SlotMachine;

public class UIMethods
{
    public static void PrintWelcomeMessage()
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
    public static void PrintStartingMoney(int money)
    {
        Console.WriteLine($"Your starting balance is: ${money}\n");
    }
    public static void PrintWagerBet(int wager)
    {
        Console.WriteLine($"Your bet is: {wager}\n");
    }
    public static void AskWagerChoice()
    {
        Console.WriteLine($"What is your choice in wager ({MachineConstants.MIN_BET} - {MachineConstants.MAX_BET}): ");
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
    public static int GetValidInput()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int wager))
            {
                Console.WriteLine(
                    "Invalid input, please choose a valid number between " +
                    $"{MachineConstants.MIN_BET} and {MachineConstants.MAX_BET}.");
                continue;
            }
            if (wager < MachineConstants.MIN_RANDOM || wager > MachineConstants.MAX_RANDOM)
            {
                Console.WriteLine(
                    "Invalid input, please choose a valid number between " +
                    $"{MachineConstants.MIN_BET} and {MachineConstants.MAX_BET}.");
                continue;
            }
            return wager;
        }
    }
    public static int PrintCurrentBalance(int money)
    {
        Console.WriteLine($"Your new balance is: ${money}\n");
        return money;
    }
    public static void DisplayHorizontalCenterCheck()
    {
        Console.WriteLine("Check the horizontal center line...");
        System.Threading.Thread.Sleep(300);
    }
    public static void DisplayAllHorizontalLinesCheck()
    {
        Console.WriteLine("Check the all horizontal line check...");
        System.Threading.Thread.Sleep(300);
    }
    public static void DisplayVerticalCenterCheck()
    {
        Console.WriteLine("Check the vertical center line...");
        System.Threading.Thread.Sleep(300);
    }
    public static void DisplayAllVerticalLinesCheck()
    {
        Console.WriteLine("Check the all vertical lines...");
        System.Threading.Thread.Sleep(300);
    }
    public static void DisplayDiagonalLinesCheck()
    {
        Console.WriteLine("Check the diagonal lines...");
        System.Threading.Thread.Sleep(300);
    }
    public static void DisplayHorizontalPayout()
    {
        Console.WriteLine($"You won ${MachineConstants.HORIZONTAL_PAYOUT} dollars!");
    }
    public static void DisplayVerticalPayout()
    {
        Console.WriteLine($"You won ${MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT} dollars!");
    }
    public static void DisplayAllHorizontalLinesPayout()
    {
        Console.WriteLine($"You won ${MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT} dollars!");
    }
    public static void DisplayAllVerticalLinesPayout()
    {
        Console.WriteLine($"You won ${MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT} dollars!");
    }
    public static void DisplayDiagonalPayout()
    {
        Console.WriteLine($"Your won ${MachineConstants.DIAGONAL_PAYOUT} dollars!");   
    }
    public static void DisplayAllLinesPayout()
    {
        Console.WriteLine($"You won ${MachineConstants.ALL_PAYOUT} dollars!");
    }
    public static void DisplayRoundLoss()
    {
        Console.WriteLine("You Lost this round. Try again.");
    }
}
    
