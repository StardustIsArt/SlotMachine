namespace SlotMachine;

public class MachineConstants
{
    public const int MONEY_START_OF_GAME = 30;
    
    public const int REEL_SIZE = 3;
    
    public const int MIN_RANDOM = 0;
    public const int MAX_RANDOM = 100;
    public const int ZERO = 0;
    
    // Betting modes
    public const int MIN_BET = 1;
    public const int MAX_BET = 6;
    public const int CENTER_HORIZONTAL_MODE = 1;
    public const int CENTER_VERTICAL_MODE = 2;
    public const int ALL_HORIZONTAL_MODE = 3;
    public const int ALL_VERTICAL_MODE = 4;
    public const int DIAGONAL_MODE = 5;
    public const int ALL_MODE = 6;
    
    // Betting payouts
    public const int MIDDLE_LINE_PAYOUT = 3;
    public const int HORIZONTAL_PAYOUT = 9;
    public const int VERTICAL_N_HORIZONTAL_ALL_PAYOUT = 20;
    public const int DIAGONAL_PAYOUT = 12;
    public const int ALL_PAYOUT = 30;
    
    public const int MIDDLE_LINE = REEL_SIZE / 2;

}