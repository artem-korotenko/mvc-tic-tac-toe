namespace Examples.TicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.AccessControl;

    public class TicTacToe
    {
        private const int FieldSize = 3;

        private readonly Player firstPlayer;

        private readonly Player secondPlayer;

        private Cell[,] field;

        public Player CurrentPlayer { get; private set; }

        public Player Winner { get; private set; }

        public bool IsEnded { get; private set; }

        public Cell[,] GetField() => field.Clone() as Cell[,];

        public Player GetCellValue(int x, int y) => field[x, y].MarkedByPlayer;
//
//        public event Action<Cell[,]> GameStarted;
//        
//        public event Action<Cell[,]> FieldUpdated;
//        
//        public event Action<Player> PlayerWon;
//        
//        public event Action<Player> MatchDrawn;

        public TicTacToe(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;

            CurrentPlayer = firstPlayer;

            PrepareField();
//            GameStarted?.Invoke(GetField());
        }

        public void MakeMove(int x, int y)
        {
            if (IsEnded)
            {
                throw new Exception($"Can not make move to ({x},{y}) - game is ended");
            }

            field[x, y].MarkBy(CurrentPlayer);
            SwitchPlayer();
            CheckGameEnd();
        }

        private void PrepareField()
        {
            field = new Cell[FieldSize, FieldSize];
            for (var x = 0; x < field.GetLength(0); x++)
            {
                for (var y = 0; y < field.GetLength(1); y++)
                {
                    field[x, y] = new Cell();
                }
            }
        }

        private void CheckGameEnd()
        {
            var hasEmptyCells = false;
            foreach (var row in GetAllRows())
            {
                var player = row[0].MarkedByPlayer;
                if (player != null && row.All(cell => cell.MarkedByPlayer == player))
                {
                    IsEnded = true;
                    Winner = player;
                    break;
                }

                if (row.Any(cell => cell.IsEmpty))
                {
                    hasEmptyCells = true;
                }
            }

            if (!hasEmptyCells)
            {
                IsEnded = true;
            }
            
            IEnumerable<List<Cell>> GetAllRows()
            {
                yield return new List<Cell> {field[0, 0], field[0, 1], field[0, 2]};
                yield return new List<Cell> {field[1, 0], field[1, 1], field[1, 2]};
                yield return new List<Cell> {field[2, 0], field[2, 1], field[2, 2]};
                
                yield return new List<Cell> {field[0, 0], field[1, 0], field[2, 0]};
                yield return new List<Cell> {field[0, 1], field[1, 1], field[2, 1]};
                yield return new List<Cell> {field[0, 2], field[1, 2], field[2, 2]};
                
                yield return new List<Cell> {field[0, 0], field[1, 1], field[2, 2]};
                yield return new List<Cell> {field[0, 2], field[1, 1], field[2, 0]};
            }
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == firstPlayer ? secondPlayer : firstPlayer;
        }
    }
}