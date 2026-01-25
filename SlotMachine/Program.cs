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
                //UIMethods.PrintCurrentBalance(money);
                UIMethods.AskWagerChoice();
                int wager = UIMethods.GetValidInput();
                UIMethods.PrintWagerBet(wager);
                // setting up the grid for reel reading and random number in each slot.
                int[,] reel = GameLogic.GenerateReel(number);
                Console.WriteLine();
                UIMethods.PrintReel(reel);
                if (wager == MachineConstants.CENTER_HORIZONTAL_MODE)   // checking the center horizontal line dynamically
                {
                   GameLogic.CheckHorizontalCenterWin(reel, ref money);
                }
                if (wager == MachineConstants.CENTER_VERTICAL_MODE)  // checking the center vertical line dynamically
                {
                    GameLogic.CheckVerticalCenterWin(reel, ref money);
                }
                if (wager == MachineConstants.ALL_HORIZONTAL_MODE)  // checking all horizontal lines dynamically
                {
                    UIMethods.DisplayAllHorizontalLineCheck();
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
                        UIMethods.DisplayHorizontalPayout();
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
                    UIMethods.DisplayAllVerticalLineCheck();
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
                        UIMethods.DisplayAllVerticalLinePayout();
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
                    UIMethods.DisplayDiagonalLineCheck();
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
                        UIMethods.DisplayRoundLoss();
                        money -= MachineConstants.DIAGONAL_PAYOUT;
                    }
                }
                if (wager == MachineConstants.ALL_MODE)
                {
                    Console.WriteLine("You didn't win any lines this round. Try another bet!");
                }
                UIMethods.PrintCurrentBalance(money);
            }
        }
    }

