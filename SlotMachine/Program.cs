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
            UIMethods.PrintStartingMoney(money);
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
                bool win = true;
                if (wager == MachineConstants.CENTER_HORIZONTAL_MODE)   // checking the center horizontal line dynamically
                { 
                    UIMethods.DisplayHorizontalCenterCheck();
                    win = GameLogic.IsHorizontalCenterWinner(reel);
                    HandlePayout(win, MachineConstants.MIDDLE_LINE_PAYOUT, UIMethods.DisplayHorizontalPayout, ref money);
                }
                if (wager == MachineConstants.CENTER_VERTICAL_MODE)  // checking the center vertical line dynamically
                {
                    UIMethods.DisplayVerticalCenterCheck();
                    win = GameLogic.IsVerticalCenterWinner(reel);
                    HandlePayout(win, MachineConstants.MIDDLE_LINE_PAYOUT, UIMethods.DisplayVerticalPayout, ref money);
                }
                if (wager == MachineConstants.ALL_HORIZONTAL_MODE)  // checking all horizontal lines dynamically
                {
                    UIMethods.DisplayAllHorizontalLinesCheck();
                    win = GameLogic.IsAllHorizontalLinesWinners(reel);
                    HandlePayout(win, MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT, UIMethods.DisplayAllHorizontalLinesPayout, ref money);
                }
                if (wager == MachineConstants.ALL_VERTICAL_MODE) // checking all vertical lines dynamically
                {
                    UIMethods.DisplayAllVerticalLinesCheck();
                    win = GameLogic.IsAllVerticalLinesWinners(reel);
                    HandlePayout(win, MachineConstants.VERTICAL_N_HORIZONTAL_ALL_PAYOUT, UIMethods.DisplayAllHorizontalLinesPayout, ref money);
                }
                if (wager == MachineConstants.DIAGONAL_MODE) // checking diagonal lines dynamically
                {
                    UIMethods.DisplayDiagonalLinesCheck();
                    bool diagonalWin = GameLogic.DoAnyDiagonalLinesWin(reel);
                    HandlePayout(diagonalWin, MachineConstants.DIAGONAL_PAYOUT, UIMethods.DisplayDiagonalPayout, ref money);
                }
                if (wager == MachineConstants.ALL_MODE)  // checking all lines dynamically
                {
                    if (GameLogic.IsAllHorizontalLinesWinners(reel) &&
                        GameLogic.IsAllVerticalLinesWinners(reel) &&
                        GameLogic.DoAnyDiagonalLinesWin(reel))
                    {
                        UIMethods.DisplayAllLinesPayout();
                    }
                    UIMethods.DisplayRoundLoss();
                }
                UIMethods.PrintCurrentBalance(money);
            }
        }
        static void HandlePayout(bool win, int payout, Action winMessage, ref int money)
        {
            if (win)
            {
                winMessage();
                money += payout;
            }
            else
            {
                UIMethods.DisplayRoundLoss();
                money -= payout;
            }
        }
    }

