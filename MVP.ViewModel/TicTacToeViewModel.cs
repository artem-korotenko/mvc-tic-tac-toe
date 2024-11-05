public class TicTacToeViewModel
{
    public char[] Board { get; set; }

    public char CurrentPlayer { get; set; }

    public TicTacToeMessage Message { get; set; }
}

public enum TicTacToeMessage
{
    PlayerTurn,
    InvalidInput,
    PlayerWins,
    Draw
}