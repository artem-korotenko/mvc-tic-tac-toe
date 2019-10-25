namespace Examples.TicTacToe.Consoled
{
    using Examples.TicTacToe;

    public class ConsoleTicTacToe
    {
        public static void Main(string[] args)
        {
            var  game = new TicTacToeWithEvents(new Player("A"), new Player("B") );
            var output = new ConsoleOutput();
            output.ListenTo(game);

            var input = new ConsoleInput();
            input.StartProcessing(game);
        }
    }
}