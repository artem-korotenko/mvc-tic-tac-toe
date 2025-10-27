namespace Examples.Hangman.Console
{
    using System;
    using Examples.Hangman;

    public class ConsoleOutput
    {
        private Hangman game;

        public void ListenTo(Hangman game)
        {
            this.game = game;
            game.GameStarted += OnGameStarted;
            game.WordUpdated += OnWordUpdated;
            game.GuessResult += OnGuessResult;
            game.PlayerWon += OnPlayerWon;
            game.PlayerLost += OnPlayerLost;
        }

        private void OnGameStarted(string word)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Guess the word by entering one letter at a time.");
            Console.WriteLine($"You have {game.AttemptsLeft} attempts left.");
            Console.WriteLine();
        }

        private void OnWordUpdated(char[] guessedLetters)
        {
            Console.Clear();
            Console.WriteLine("HANGMAN GAME");
            Console.WriteLine("============");
            Console.WriteLine();
            Console.WriteLine($"Word: {game.GetDisplayWord()}");
            Console.WriteLine($"Attempts left: {game.AttemptsLeft}");
            Console.WriteLine($"Guessed letters: {game.GetGuessedLettersString()}");
            Console.WriteLine();
            DrawHangman();
            Console.WriteLine();
        }

        private void OnGuessResult(char letter, bool wasSuccessful)
        {
            if (wasSuccessful)
            {
                Console.WriteLine($"Good guess! '{letter}' is in the word.");
            }
            else
            {
                Console.WriteLine($"Sorry, '{letter}' is not in the word.");
            }
        }

        private void OnPlayerWon()
        {
            Console.WriteLine("🎉 Congratulations! You won! 🎉");
            Console.WriteLine($"The word was: {game.CurrentWord}");
            Console.WriteLine();
        }

        private void OnPlayerLost()
        {
            Console.WriteLine("💀 Game Over! You lost! 💀");
            Console.WriteLine($"The word was: {game.CurrentWord}");
            Console.WriteLine();
        }

        private void DrawHangman()
        {
            int attempts = 6 - game.AttemptsLeft;
            
            Console.WriteLine("  +---+");
            Console.WriteLine($"  |   |");
            
            if (attempts >= 1)
                Console.WriteLine("  O   |");
            else
                Console.WriteLine("      |");
                
            if (attempts >= 2)
                Console.WriteLine(" /|\\  |");
            else if (attempts >= 3)
                Console.WriteLine(" /|   |");
            else if (attempts >= 4)
                Console.WriteLine("  |   |");
            else
                Console.WriteLine("      |");
                
            if (attempts >= 5)
                Console.WriteLine(" / \\  |");
            else if (attempts >= 6)
                Console.WriteLine(" /    |");
            else
                Console.WriteLine("      |");
                
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
    }
}
