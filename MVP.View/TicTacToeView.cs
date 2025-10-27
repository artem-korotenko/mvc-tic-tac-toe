


public class TicTacToeView
{
    public void Display(TicTacToeViewModel viewModel)
    {
        Console.Clear();
        Console.WriteLine("\n");
        Console.WriteLine(" {0} | {1} | {2} ", viewModel.Board[0], viewModel.Board[1], viewModel.Board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", viewModel.Board[3], viewModel.Board[4], viewModel.Board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", viewModel.Board[6], viewModel.Board[7], viewModel.Board[8]);
        Console.WriteLine("\n");

        switch (viewModel.Message)
        {
            case TicTacToeMessage.PlayerTurn:
                Console.WriteLine($"Player {viewModel.CurrentPlayer}, choose your field: ");
                break;
            case TicTacToeMessage.InvalidInput:
                Console.WriteLine("Invalid input, please try again.");
                break;
            case TicTacToeMessage.PlayerWins:
                Console.WriteLine($"Player {viewModel.CurrentPlayer} wins!");
                break;
            case TicTacToeMessage.Draw:
                Console.WriteLine("It's a draw!");
                break;
        }
    }

    public int GetPlayerInput()
    {
        return int.TryParse(Console.ReadLine(), out int field) ? field : -1;
    }

}