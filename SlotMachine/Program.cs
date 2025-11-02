namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Step right up and check your luck!");
        const int SIZE = 3;
        const int MAX_RANDOM = 100;
        const int MIN_RANDOM = 0;
        int[,] grid =  new int[SIZE,SIZE];
        Random number = new Random();       
        int randomNumber = number.Next(MIN_RANDOM, MAX_RANDOM);

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
                Console.Write($"{grid[row, col]}");
                if (col < SIZE - 1) Console.Write(" |");
            }
            Console.WriteLine();
            if (row < SIZE - 1)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    Console.Write("---");
                    if (i < SIZE - 1) Console.Write("+");
                }
                Console.WriteLine();
            }
        }
        
    }
}