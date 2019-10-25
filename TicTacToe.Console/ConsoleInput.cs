namespace TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    internal class ConsoleInput
    {
        public static void Main(string[] args)
        {
            string command = null;

            var  game = new TicTacToeWithEvents(new Player("A"), new Player("B") );
            var output = new ConsoleOutput();
            output.ListenTo(game);
            
            Console.Out.WriteLine("Welcome to greatest Tic Tac Toe game! Type START to play ");
            while (true)
            {
                command = ReadLine.Read("> ");
                var splitCommand = command.Split(new char[0]);
                switch (splitCommand[0].ToLower())
                {
                    case "start":
                        game.StartGame();
                        break;
                    case "exit":
                        break;
                    case "move":
                        var x = int.Parse(splitCommand[1]);
                        var y = int.Parse(splitCommand[2]);
                        game.MakeMove(x, y);
                        break;
                }
                
            }
        }
    }
}