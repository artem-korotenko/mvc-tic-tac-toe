public class TicTacToeModel
{
    public char[] Board { get; } = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public char CurrentPlayer { get; private set; } = 'X';
    public int Turn { get; private set; } = 0;

    public void MakeMove(int field)
    {
        if (field is >= 1 and <= 9 && Board[field - 1] != 'X' && Board[field - 1] != 'O')
        {
            Board[field - 1] = CurrentPlayer;
            if (!HasWinner())
            {
                CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
            }
            Turn++;
        }
    }

    public bool IsGameEnded() => Turn >= 9 || HasWinner();

    public char? Winner => HasWinner() ? (CurrentPlayer == 'X' ? 'X' : 'O') : null;

    public bool HasWinner()
    {
        int[,] winningCombinations = {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Rows
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columns
            { 0, 4, 8 }, { 2, 4, 6 } // Diagonals
        };

        for (int i = 0; i < winningCombinations.GetLength(0); i++)
        {
            if (Board[winningCombinations[i, 0]] == Board[winningCombinations[i, 1]] &&
                Board[winningCombinations[i, 1]] == Board[winningCombinations[i, 2]])
            {
                return true;
            }
        }

        return false;
    }
}