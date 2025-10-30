namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World! This is a slot machine for you!");

        int[,] grid =  new int[3,3];
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                grid[row, col] = ' ';
            }
        }

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write($"{grid[row, col]}");
                if (col < 3 - 1) Console.Write(" |");
            }
            Console.WriteLine();
            if (row < 3 - 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("---");
                    if (i < 3 - 1) Console.Write("+");
                }
                Console.WriteLine();
            }
        }
       
    }
}