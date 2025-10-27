namespace Examples.Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hangman
    {
        private const int MaxAttempts = 6;
        private readonly string[] words = { "ENGINEERING", "COMPUTER", "SOFTWARE", "ALGORITHM", "DEVELOPMENT", "ARCHITECTURE" };
        
        private string currentWord;
        private char[] guessedLetters;
        private HashSet<char> guessedChars;
        private int attemptsLeft;

        public string CurrentWord => currentWord;
        public char[] GuessedLetters => (char[])guessedLetters.Clone();
        public HashSet<char> GuessedChars => new HashSet<char>(guessedChars);
        public int AttemptsLeft => attemptsLeft;
        public bool IsGameEnded { get; private set; }
        public bool IsWon { get; private set; }
        public bool IsLost => IsGameEnded && !IsWon;

        public event Action<string> GameStarted;
        public event Action<char[]> WordUpdated;
        public event Action<char, bool> GuessResult; // char = guessed letter, bool = was successful
        public event Action PlayerWon;
        public event Action PlayerLost;

        public void StartGame()
        {
            var random = new Random();
            currentWord = words[random.Next(words.Length)];
            guessedLetters = new char[currentWord.Length];
            guessedChars = new HashSet<char>();
            attemptsLeft = MaxAttempts;
            IsGameEnded = false;
            IsWon = false;

            // Initialize guessed letters with underscores
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            GameStarted?.Invoke(currentWord);
            WordUpdated?.Invoke(guessedLetters);
        }

        public void MakeGuess(char letter)
        {
            if (IsGameEnded)
            {
                throw new InvalidOperationException("Game has already ended");
            }

            letter = char.ToUpper(letter);
            
            if (guessedChars.Contains(letter))
            {
                return; // Already guessed this letter, ignore
            }

            guessedChars.Add(letter);

            bool found = false;
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == letter)
                {
                    guessedLetters[i] = letter;
                    found = true;
                }
            }

            if (!found)
            {
                attemptsLeft--;
            }

            // Notify about the guess result (business logic)
            GuessResult?.Invoke(letter, found);
            WordUpdated?.Invoke(guessedLetters);
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            if (attemptsLeft <= 0)
            {
                IsGameEnded = true;
                PlayerLost?.Invoke();
            }
            else if (guessedLetters.All(letter => letter != '_'))
            {
                IsGameEnded = true;
                IsWon = true;
                PlayerWon?.Invoke();
            }
        }

        public string GetDisplayWord()
        {
            return string.Join(" ", guessedLetters);
        }

        public string GetGuessedLettersString()
        {
            return string.Join(", ", guessedChars.OrderBy(c => c));
        }
    }
}
