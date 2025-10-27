using System;
using Examples.Hangman;

namespace Examples.Hangman.Tests
{
    public class HangmanTest
    {
        public static void TestMVC()
        {
            Console.WriteLine("Testing Hangman MVC Pattern...");
            Console.WriteLine("================================");
            
            var game = new Hangman();
            var output = new TestOutput();
            var input = new TestInput();
            
            // Connect view to model (MVC pattern)
            output.ListenTo(game);
            
            // Simulate controller behavior
            input.ProcessInput(game);
            
            Console.WriteLine("MVC Test completed successfully!");
        }
    }
    
    public class TestOutput
    {
        public void ListenTo(Hangman game)
        {
            game.GameStarted += OnGameStarted;
            game.WordUpdated += OnWordUpdated;
            game.GuessResult += OnGuessResult;
            game.PlayerWon += OnPlayerWon;
            game.PlayerLost += OnPlayerLost;
        }
        
        private void OnGameStarted(string word)
        {
            Console.WriteLine($"Game started! Word: {word}");
        }
        
        private void OnWordUpdated(char[] guessedLetters)
        {
            Console.WriteLine($"Current word: {string.Join(" ", guessedLetters)}");
        }
        
        private void OnGuessResult(char letter, bool wasSuccessful)
        {
            Console.WriteLine($"Guess '{letter}': {(wasSuccessful ? "SUCCESS" : "FAILED")}");
        }
        
        private void OnPlayerWon()
        {
            Console.WriteLine("🎉 PLAYER WON! 🎉");
        }
        
        private void OnPlayerLost()
        {
            Console.WriteLine("💀 PLAYER LOST! 💀");
        }
    }
    
    public class TestInput
    {
        public void ProcessInput(Hangman game)
        {
            // Simulate some guesses
            game.StartGame();
            
            // Make some guesses
            game.MakeGuess('A');
            game.MakeGuess('E');
            game.MakeGuess('I');
            game.MakeGuess('O');
            game.MakeGuess('U');
            game.MakeGuess('X');
            game.MakeGuess('Z');
        }
    }
}
