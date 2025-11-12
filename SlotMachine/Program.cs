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
        Console.WriteLine($"Your wager: ${wager}\n");
        
        int[,] reel;
        reel =  new int[REEL_SIZE, REEL_SIZE];
        for (int row = 0; row < REEL_SIZE; row++)
        {
            for (int col = 0; col < REEL_SIZE; col++)
            {
                reel[row, col] = number.Next(MIN_RANDOM, MAX_RANDOM);
            }
        }
        Console.WriteLine();
        for (int row = 0; row < REEL_SIZE; row++)
        {
            for (int col = 0; col < REEL_SIZE; col++)
            {
                Console.Write($" {reel[row, col]}");
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
        
        const int CENTER_HORIZONTAL_MODE = 1;
        const int CENTER_VERTICAL_MODE = 2;
        const int ALL_HORIZONTAL_MODE = 3;
        const int ALL_VERTICAL_MODE = 4;
        const int DIAGONAL_MODE = 5;
        const int ALL_MODE = 6;
        
        if (wager == CENTER_HORIZONTAL_MODE)
        {
            Console.WriteLine("Checking the horizontal center line...");
            bool win = true;
            int first = reel[1, 0];
            for (int j = 0; j < reel.GetLength(1); j++)
            {
                if (reel[1, j] != first) 
                {
                    Console.WriteLine("You won $3 dollars!");
                    win = false;
                    break;
                }
            }
        }
        if (wager == CENTER_VERTICAL_MODE)
        {
            Console.WriteLine("Checking the vertical center line...");
            bool win = true;
            int first = reel[0, 1];
            for (int j = 0; j < reel.GetLength(0); j++)
            {
                if (reel[0, j] != first)
                {
                    Console.WriteLine("You won $3 dollars!");
                    win = false;
                    break;
                }
            }
        }
        if (wager == ALL_HORIZONTAL_MODE)
        {
            Console.WriteLine("Checking all the horizontal lines...");
            bool win = true;
            int firstLeft = reel[0, 0];
            int firstCenter = reel[0, 1];
            int firstRight = reel[0, 2];
            for (int j = 0; j < reel.GetLength(0); j++)
            {
                if (reel[0, j] != firstLeft)
                {
                    win = false;
                    break;
                }
            }
            for (int j = 1; j < reel.GetLength(1); j++)
            {
                if (reel[0, j] != firstLeft)
                {
                    win = false;
                    break;
                }
            }
            for (int j = 2; j < reel.GetLength(2); j++)
            {
                if (reel[0, j] != firstLeft)
                {
                    win = false;
                    break;
                }
            }
            if (win)
            {
                Console.WriteLine("Your won $9 dollars!");
            }
            else
            {
                Console.WriteLine("You didn't win any lines this round. Try another bet!");
            }
        }
        if (wager == ALL_VERTICAL_MODE)
        {
            Console.WriteLine("Checking all the vertical lines...");
        }
        if (wager == DIAGONAL_MODE)
        {
            Console.WriteLine("Checking the diagonal lines...");
        }
        if (wager == ALL_MODE)
        {
            Console.WriteLine("Checking all available lines...");
            
        }
    }
}

