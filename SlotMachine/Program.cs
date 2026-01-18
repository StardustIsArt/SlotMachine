    using System.Data;
    using System.Drawing;
    using System.Reflection.Metadata.Ecma335;
    using Console = Colorful.Console;

    namespace SlotMachine;
    class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcomeMessage();
            int money = MachineConstants.MONEY_START_OF_GAME;
            UIMethods.PrintStartingMoney();
            UIMethods.PrintBettingOptions();
            Random number = new Random();   
            while (money > 0)
            {
                UIMethods.PrintCurrentBalance();
                UIMethods.AskWagerChoice();
                int wager = UIMethods.GetValidInput();
                UIMethods.PrintWagerBet(wager);
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
                UIMethods.PrintReel(reel);
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

                UIMethods.PrintCurrentBalance();
            }
        }
    }

