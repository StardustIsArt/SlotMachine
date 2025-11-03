using System.Data;

namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Step right up and check your luck!\n");
        const int SIZE = 3;
        const int MAX_RANDOM = 100;
        const int MIN_RANDOM = 0;
        
        Random number = new Random();       
        int randomNumber = number.Next(MIN_RANDOM, MAX_RANDOM);
        int[,] grid =  new int[randomNumber, randomNumber];
        for (int row = 0; row < SIZE; row++)
        {
            for (int col = 0; col < SIZE; col++)
            {
                grid[row, col] = ' ';
            }
        }

        for (int row = 0; row < SIZE; row++)
        {
            for (int col = 0; col < SIZE; col++)
            {
                Console.Write($" { randomNumber }");
                if (col < SIZE - 1) Console.Write(" |");
            }
            Console.WriteLine();
            if (row < SIZE - 1)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    Console.Write("----");
                    if (i < SIZE - 1) Console.Write("+");
                }
                Console.WriteLine();
            }
            
        }

    }
}