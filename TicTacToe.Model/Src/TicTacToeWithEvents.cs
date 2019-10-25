namespace Examples.TicTacToe
{
    using System;

    public class TicTacToeWithEvents : TicTacToe
    {
        public event Action<Cell[,]> GameStarted;
        
        public event Action<Cell[,]> FieldUpdated;
        
        public event Action<Player> PlayerWon;
        
        public event Action MatchDrawn;
        
        public TicTacToeWithEvents(Player firstPlayer, Player secondPlayer) : base(firstPlayer, secondPlayer)
        {
        }

        protected override void PrepareField()
        {
            base.PrepareField();
            GameStarted?.Invoke(GetField());
        }

        protected override void MarkCell(int x, int y, Player player)
        {
            base.MarkCell(x, y, player);
            FieldUpdated?.Invoke(GetField());
        }

        protected override void EndGame(Player winner = null)
        {
            base.EndGame(winner);
            if (winner == null)
            {
                MatchDrawn?.Invoke();
            }
            else
            {
                PlayerWon?.Invoke(winner);
            }
        }
    }
}