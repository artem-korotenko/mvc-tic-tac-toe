namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public  class ConsoleInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            string command = null;
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