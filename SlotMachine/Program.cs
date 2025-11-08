using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Step right up and check your luck!\n");
        const int REEL_SIZE = 3;
        const int MAX_RANDOM = 100;
        const int MIN_RANDOM = 0;
        const int MONEY = 30;
        Random number = new Random();       
        int randomNumber = number.Next(MIN_RANDOM, MAX_RANDOM);
        
        Console.WriteLine($"Your starting balance is: ${MONEY}\n");
        Console.WriteLine($"How much would you like to bet: $1 - $6: \n" +
                          $"$1 - play horizontal center line\n" +
                          $"$2 - play vertical center line\n" +
                          $"$3 - play all 3 horizontal lines\n" +
                          $"$4 - play all 3 vertical lines\n" +
                          $"$5 - play both diagonal lines\n" +
                          $"$6 - play all available lines (horizontal, vertical & diagonal)\n");
        int wager = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Your wager and lines to play: ${wager}\n");
        
        int[,] reel;
        reel =  new int[REEL_SIZE, REEL_SIZE];
        for (int row = 0; row < REEL_SIZE; row++)
        {
            for (int col = 0; col < REEL_SIZE; col++)
            {
                reel[row, col] = ' ';
            }
        }
        Console.WriteLine();
        for (int row = 0; row < REEL_SIZE; row++)
        {
            for (int col = 0; col < REEL_SIZE; col++)
            {
                Console.Write($" " +number.Next(MIN_RANDOM, MAX_RANDOM));
                if (col < REEL_SIZE - 1) Console.Write(" |");
            }
            Console.WriteLine();
            if (row < REEL_SIZE - 1)
            {
                for (int i = 0; i < REEL_SIZE; i++)
                {
                    Console.Write("----");
                    if (i < REEL_SIZE - 1) Console.Write("+");
                }
                Console.WriteLine();
            }
        }

        if (wager == 1)
        {
            Console.WriteLine("Checking the horizontal center line...");
            if (reel[1, 0] == reel[1, 1] && reel[1, 1] == reel[1, 2])
            {
                Console.WriteLine("You won $3 dollars!");
            }
        }
        if (wager == 2)
        {
            Console.WriteLine("Checking the vertical center line...");
        }
        if (wager == 3)
        {
            Console.WriteLine("Checking all the horizontal lines...");
        }
        if (wager == 4)
        {
            Console.WriteLine("Checking all the vertical lines...");
        }
        if (wager == 5)
        {
            Console.WriteLine("Checking the diagonal lines...");
        }
        if (wager == 6)
        {
            Console.WriteLine("Checking the all available lines...");
        }
    }
}