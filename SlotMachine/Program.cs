using System.Data;

namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Step right up and check your luck!\n");
        const int REEL_SIZE = 3;
        const int MAX_RANDOM = 100;
        const int MIN_RANDOM = 0;
        const int MONEY = 25;
        Random number = new Random();       
        int randomNumber = number.Next(MIN_RANDOM, MAX_RANDOM);
        
        Console.WriteLine($"Your starting balance is: ${MONEY}\n");
        Console.WriteLine($"How much would you like to bet: $1 - $6: \n" +
                          $"$1 - play horizontal middle line\n" +
                          $"$2 - play vertical middle line\n" +
                          $"$3 - play all 3 horizontal lines\n" +
                          $"$4 - play all 3 vertical lines\n" +
                          $"$5 - play x diagonal lines\n" +
                          $"$6 - play all available lines\n");
        int wager = Convert.ToInt32(Console.ReadLine());
        
        
        int[,] reel;
        reel =  new int[REEL_SIZE, REEL_SIZE];
        for (int row = 0; row < REEL_SIZE; row++)
        {
            for (int col = 0; col < REEL_SIZE; col++)
            {
                reel[row, col] = randomNumber;
            }
        }
        Console.WriteLine();
        for (int row = 0; row < REEL_SIZE; row++)
        {
            for (int col = 0; col < REEL_SIZE; col++)
            {
                Console.Write($"   ");
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
        
        
    }
}