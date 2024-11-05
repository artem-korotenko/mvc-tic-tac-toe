public class TicTacToePresenter(TicTacToeModel model, TicTacToeView view)
{
    public void Run()
    {
        while (!model.IsGameEnded())
        {
            var viewModel = CreateViewModel(TicTacToeMessage.PlayerTurn);
            view.Display(viewModel);

            int field = view.GetPlayerInput();
            if (field != -1)
            {
                model.MakeMove(field);
            }
            else
            {
                viewModel = CreateViewModel(TicTacToeMessage.InvalidInput);
                view.Display(viewModel);
            }
        }

        var finalMessage = model.HasWinner() ? TicTacToeMessage.PlayerWins : TicTacToeMessage.Draw;
        var finalViewModel = CreateViewModel(finalMessage);
        view.Display(finalViewModel);
    }

    private TicTacToeViewModel CreateViewModel(TicTacToeMessage message)
    {
        return new TicTacToeViewModel
        {
            Board = model.Board,
            CurrentPlayer = model.CurrentPlayer,
            Message = message
        };
    }
}