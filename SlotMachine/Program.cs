    using System.Data;
    using System.Drawing;
    using System.Reflection.Metadata.Ecma335;
    using Console = Colorful.Console;

    namespace SlotMachine;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Step right up and check your luck!\n");
            
            const int REEL_SIZE = 3;
            const int MAX_RANDOM = 100;
            const int MIN_RANDOM = 0;
            const int CENTER_HORIZONTAL_MODE = 1;
            const int CENTER_VERTICAL_MODE = 2;
            const int ALL_HORIZONTAL_MODE = 3;
            const int ALL_VERTICAL_MODE = 4;
            const int DIAGONAL_MODE = 5;
            const int ALL_MODE = 6;
            const int MIDDLE_LINE = REEL_SIZE / 2;
            const int MIDDLE_LINE_PAYOUT = 3;
            const int HORIZONTAL_PAYOUT = 9;
            const int VERTICAL_PAYOUT = 20;
            const int DIAGONAL_PAYOUT = 12;
            int money = 30;
            Random number = new Random();   
            while (money > 0) {
            Console.WriteLine($"Your starting balance is: ${money}\n");
            Console.WriteLine($"How much would you like to bet: $1 - $6: \n" +
                              $"$1 - play horizontal center line\n" +
                              $"$2 - play vertical center line\n" +
                              $"$3 - play all horizontal lines\n" +
                              $"$4 - play all vertical lines\n" +
                              $"$5 - play both diagonal lines\n" +
                              $"$6 - play all available lines (horizontal, vertical & diagonal)\n");
            int wager = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your wager: ${wager}\n");
            
            //  setting up the grid for reel reading and random number in each slot.
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
            if (wager == CENTER_HORIZONTAL_MODE)   // checking the center horizontal line dynamically
            {
                Console.WriteLine("Checking the horizontal center line...");
                bool win = true;
                int middleRow = reel.GetLength(0) / 2;
                int first = reel[middleRow, 0];
                for (int j = 0; j < reel.GetLength(1); j++)
                {
                    if (reel[MIDDLE_LINE, j] != first)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    Console.WriteLine("You won $3 dollars!");
                    money += MIDDLE_LINE_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You lost this round. Try again!");
                    money -= MIDDLE_LINE_PAYOUT;
                }
            }
            if (wager == CENTER_VERTICAL_MODE)  // checking the center vertical line dynamically
            {
                Console.WriteLine("Checking the vertical center line...");
                bool win = true;
                int middleRow = reel.GetLength(0) / 2;
                int first = reel[0, middleRow];
                for (int j = 0; j < reel.GetLength(0); j++)
                {
                    if (reel[j, MIDDLE_LINE] != first)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    Console.WriteLine("You won $3 dollars!");
                    money += MIDDLE_LINE_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You lost this round. Try again!");
                    money -= MIDDLE_LINE_PAYOUT;
                }
            }
            if (wager == ALL_HORIZONTAL_MODE)  // checking all horizontal lines dynamically
            {
                Console.WriteLine("Checking all the horizontal lines...");
                bool anyWins = false;
                for (int row = 0; row < REEL_SIZE; row++)
                {
                    int first = reel[row, 0];
                    bool lineWin = true;
                    
                    for (int col = 0; col < reel.GetLength(0); col++)
                    {
                        if (reel[row, col] != first)
                        {
                            lineWin = false;
                            break;
                        }
                    }
                    if (lineWin)
                    {
                        anyWins = true;
                        Console.WriteLine($"Line {row + 1} is a winner!");
                    }
                }
                if (anyWins)
                {
                    Console.WriteLine("Your won $9 dollars!");
                    money += HORIZONTAL_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You didn't win any lines this round. Try another bet!");
                    money -= HORIZONTAL_PAYOUT;
                }
            }
            if (wager == ALL_VERTICAL_MODE) // checking all vertical lines dynamically
            {
                Console.WriteLine("Checking all the vertical lines...");
                bool anyWins = false;
                for (int col = 0; col < REEL_SIZE; col++)
                {
                    int first = reel[0, col];
                    bool lineWin = true;

                    for (int row = 0; row < reel.GetLength(0); row++)
                    {
                        if (reel[row, col] != first)
                        {
                            lineWin = false;
                            break;
                        }
                    }

                    if (lineWin)
                    {
                        anyWins = true;
                        Console.WriteLine($"Line {col + 1} is a winner!");
                    }
                }

                if (anyWins)
                {
                    Console.WriteLine("Your won $20 dollars!");
                    money += VERTICAL_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You didn't win any lines this round. Try another bet!");
                    money -= VERTICAL_PAYOUT;
                }
            }
            if (wager == DIAGONAL_MODE)
            {
                Console.WriteLine("Checking the diagonal lines...");
                int size = reel.GetLength(0);
                // checking diagonal left-to-right (\)
                bool winLeft = true;
                int firstLeft = reel[0, 0];
                
                for (int j = 1; j < size; j++)
                {
                    if (reel[j, j] != firstLeft)
                    {
                        winLeft = false;
                        break;
                    }   
                }
                // checking diagonal right-to-left (/)
                bool winRight = true;
                int firstRight = reel[0, size - 1];
                for (int j = 1; j < size; j++)
                {
                    if (reel[j, size - 1 - j] != firstRight)
                    {
                        winRight = false;
                        break;
                    }
                }
                
                if (winLeft || winRight)
                {
                    Console.WriteLine("Your won $12 dollars!");
                    money += DIAGONAL_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You lost this round. Try another bet!");
                    money -= DIAGONAL_PAYOUT;
                }
            }
            if (wager == ALL_MODE)
            {
                Console.WriteLine("You didn't win any lines this round. Try another bet!");
            }
            Console.WriteLine($"Your new balance is: ${money}\n"); 
            }
        }
    }

