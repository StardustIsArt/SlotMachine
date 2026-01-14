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
}