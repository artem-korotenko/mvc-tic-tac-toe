public class TicTacToeViewModel
{
    public char[] Board { get; init; }

    public char CurrentPlayer { get; init; }

    public TicTacToeMessage Message { get; init; }
}

public enum TicTacToeMessage
{
    PlayerTurn,
    InvalidInput,
    PlayerWins,
    Draw
}