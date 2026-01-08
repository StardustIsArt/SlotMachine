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
            int money = 30;
            Random number = new Random();   
            while (money > 0) {
            Console.WriteLine($"Your starting balance is: ${money}\n");
            Console.WriteLine($"How much would you like to bet: 1 - 6: \n" +
                              $"1 - play horizontal center line\n" +
                              $"2 - play vertical center line\n" +
                              $"3 - play all horizontal lines\n" +
                              $"4 - play all vertical lines\n" +
                              $"5 - play both diagonal lines\n" +
                              $"6 - play all available lines (horizontal, vertical & diagonal)\n");
            Console.WriteLine("What is your choice in wager (1 - 6): ");
            int wager = 0;
            // to check if the user input is valid and in the correct number range.
            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out wager);
                if (!success)
                {
                    Console.WriteLine($"Invalid input, please choose a valid number between 1 and 6.");
                    continue;
                }

                if (wager < MachineConstants.MIN_RANDOM || wager > MachineConstants.MAX_RANDOM)
                {
                    Console.WriteLine($"Invalid input, please choose a valid number between 1 and 6.");
                    continue;
                }
                validInput = true;
            }
            Console.WriteLine($"Your wager is: {wager}\n");
            //  setting up the grid for reel reading and random number in each slot.
            int[,] reel;
            reel =  new int[MachineConstants.REEL_SIZE, MachineConstants.REEL_SIZE];
            for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
            {
                for (int col = 0; col < MachineConstants.REEL_SIZE; col++)
                {
                    reel[row, col] = number.Next(MachineConstants.MIN_RANDOM, MachineConstants.MAX_RANDOM);
                }
            }
            Console.WriteLine();
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
            if (wager == MachineConstants.CENTER_HORIZONTAL_MODE)   // checking the center horizontal line dynamically
            {
                Console.WriteLine("Checking the horizontal center line...");
                bool win = true;
                int middleRow = reel.GetLength(0) / 2;
                int first = reel[middleRow, 0];
                for (int j = 0; j < reel.GetLength(1); j++)
                {
                    if (reel[MachineConstants.MIDDLE_LINE, j] != first)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    Console.WriteLine("You won $3 dollars!");
                    money += MachineConstants.MIDDLE_LINE_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You lost this round. Try again!");
                    money -= MachineConstants.MIDDLE_LINE_PAYOUT;
                }
            }
            if (wager == MachineConstants.CENTER_VERTICAL_MODE)  // checking the center vertical line dynamically
            {
                Console.WriteLine("Checking the vertical center line...");
                bool win = true;
                int middleRow = reel.GetLength(0) / 2;
                int first = reel[0, middleRow];
                for (int j = 0; j < reel.GetLength(0); j++)
                {
                    if (reel[j, MachineConstants.MIDDLE_LINE] != first)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    Console.WriteLine("You won $3 dollars!");
                    money += MachineConstants.MIDDLE_LINE_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You lost this round. Try again!");
                    money -= MachineConstants.MIDDLE_LINE_PAYOUT;
                }
            }
            if (wager == MachineConstants.ALL_HORIZONTAL_MODE)  // checking all horizontal lines dynamically
            {
                Console.WriteLine("Checking all the horizontal lines...");
                bool anyWins = false;
                for (int row = 0; row < MachineConstants.REEL_SIZE; row++)
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
                    money += MachineConstants.HORIZONTAL_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You didn't win any lines this round. Try another bet!");
                    money -= MachineConstants.HORIZONTAL_PAYOUT;
                }
            }
            if (wager == MachineConstants.ALL_VERTICAL_MODE) // checking all vertical lines dynamically
            {
                Console.WriteLine("Checking all the vertical lines...");
                bool anyWins = false;
                for (int col = 0; col < MachineConstants.REEL_SIZE; col++)
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
                    money += MachineConstants.VERTICAL_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You didn't win any lines this round. Try another bet!");
                    money -= MachineConstants.VERTICAL_PAYOUT;
                }
            }
            if (wager == MachineConstants.DIAGONAL_MODE)
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
                    money += MachineConstants.DIAGONAL_PAYOUT;
                }
                else
                {
                    Console.WriteLine("You lost this round. Try another bet!");
                    money -= MachineConstants.DIAGONAL_PAYOUT;
                }
            }
            if (wager == MachineConstants.ALL_MODE)
            {
                Console.WriteLine("You didn't win any lines this round. Try another bet!");
            }
            Console.WriteLine($"Your new balance is: ${money}\n"); 
            }
        }
    }

