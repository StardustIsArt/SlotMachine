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
                if (wager == MachineConstants.CENTER_HORIZONTAL_MODE)   // checking the center horizontal line dynamically
                { 
                    UIMethods.DisplayHorizontalCenterCheck();
                    GameLogic.CheckHorizontalCenterWin(reel, ref money);
                }
                if (wager == MachineConstants.CENTER_VERTICAL_MODE)  // checking the center vertical line dynamically
                {
                    UIMethods.DisplayVerticalCenterCheck();
                    GameLogic.CheckVerticalCenterWin(reel, ref money);
                }
                if (wager == MachineConstants.ALL_HORIZONTAL_MODE)  // checking all horizontal lines dynamically
                {
                    UIMethods.DisplayAllHorizontalLinesCheck();
                    GameLogic.CheckAllHorizontalLinesWin(reel, ref money);
                }
                if (wager == MachineConstants.ALL_VERTICAL_MODE) // checking all vertical lines dynamically
                {
                    UIMethods.DisplayAllVerticalLinesCheck();
                    GameLogic.CheckAllVerticalLinesWin(reel, ref money);
                }
                if (wager == MachineConstants.DIAGONAL_MODE) // checking diagonal lines dynamically
                {
                    UIMethods.DisplayDiagonalLinesCheck();
                    GameLogic.CheckAllDiagonalLinesWin(reel, ref money);
                }
                if (wager == MachineConstants.ALL_MODE)  // checking all lines dynamically
                {
                    if (GameLogic.CheckAllHorizontalLinesWin(reel, ref money) &&
                        GameLogic.CheckAllVerticalLinesWin(reel, ref money) &&
                        GameLogic.CheckAllDiagonalLinesWin(reel, ref money))
                    {
                        UIMethods.DisplayAllLinesPayout();
                    }
                    UIMethods.DisplayRoundLoss();
                }
                UIMethods.PrintCurrentBalance(money);
            }
        }
    }

