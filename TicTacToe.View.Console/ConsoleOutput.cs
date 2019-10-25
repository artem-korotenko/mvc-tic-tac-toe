namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class ConsoleOutput
    {
        private TicTacToeWithEvents game;

        public void ListenTo(TicTacToeWithEvents game)
        {
            this.game = game;
            game.GameStarted += GameOnGameStarted;
            game.FieldUpdated += OnFieldUpdated;
            game.PlayerWon += OnPlayerWon;
            game.MatchDrawn += OnMatchDrawn;
        }

        private void OnMatchDrawn()
        {
            Console.Out.WriteLine($"Game is over! No winner found");
        }

        private void OnPlayerWon(Player player)
        {
            Console.Out.WriteLine($"Game is over! Player {player.Name} won!");
        }

        private void OnFieldUpdated(Cell[,] field)
        {
            Console.Write($" {v(field[0,0])} ║ {v(field[0,1])} ║ {v(field[0,2])} \n");
            Console.Write("═══╬═══╬═══\n");
            Console.Write($" {v(field[1,0])} ║ {v(field[1,1])} ║ {v(field[1,2])} \n");
            Console.Write("═══╬═══╬═══\n");
            Console.Write($" {v(field[2,0])} ║ {v(field[2,1])} ║ {v(field[2,2])} \n\n");
            
            string v(Cell cell)
            {
                return cell.IsEmpty ? " " : cell.MarkedByPlayer.Name;
            }
        }

        private void GameOnGameStarted(Cell[,] obj)
        {
            Console.Out.WriteLine("Game is started! Make your first move with MOVE X Y");
        }
    }
}