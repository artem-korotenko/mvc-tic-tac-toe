# Hangman Game - MVC Pattern Implementation

This is a Hangman game implemented using the **Model-View-Controller (MVC)** pattern, designed to be refactored to MVP (Model-View-Presenter) pattern.

## Project Structure

```
Hangman.Model/           # Model - Contains business logic
├── Hangman.cs          # Core game logic, state management
└── HangmanTest.cs      # Test class demonstrating MVC

Hangman.View.Console/    # View - Handles display and user interface
└── ConsoleOutput.cs    # Console-based view implementation

Hangman.Console.Input/   # Controller - Handles user input
└── ConsoleInput.cs     # Input processing and command handling

Hangman.Console.App/     # Application entry point
└── Program.cs          # Main application that wires MVC components
```

## MVC Pattern Implementation

### Model (`Hangman.cs`)
- **Responsibility**: Contains all business logic
- **Features**:
  - Word selection and game state management
  - Guess validation and processing
  - Win/lose condition checking
  - Event notifications for state changes
- **Events**:
  - `GameStarted(string word)` - When a new game begins
  - `WordUpdated(char[] guessedLetters)` - When the display word changes
  - `GuessResult(char letter, bool wasSuccessful)` - When a guess is made
  - `PlayerWon()` - When player wins
  - `PlayerLost()` - When player loses

### View (`ConsoleOutput.cs`)
- **Responsibility**: Handles all display logic
- **Features**:
  - Listens to model events
  - Displays game state (word, attempts, hangman drawing)
  - Shows success/failure messages
  - Handles win/lose display

### Controller (`ConsoleInput.cs`)
- **Responsibility**: Thin layer for input handling
- **Features**:
  - Processes user commands (START, RESTART, EXIT, GUESS)
  - Validates input format
  - Delegates to model methods
  - **No business logic** - just input/output coordination

## Key MVC Principles Demonstrated

1. **Separation of Concerns**: Each component has a single responsibility
2. **Model Independence**: Model has no knowledge of view or controller
3. **Event-Driven Communication**: Model notifies view of changes via events
4. **Thin Controller**: Controller only handles input/output, no business logic
5. **View Observes Model**: View subscribes to model events

## How to Run

```bash
cd Hangman.Console.App
dotnet run
```

## Game Commands

- `START` - Begin a new game
- `RESTART` - Start a new game (if current game ended)
- `GUESS` - Enter guess mode, then type a letter
- `[letter]` - Direct letter input (shortcut)
- `EXIT` - Quit the game

## Refactoring to MVP

This MVC implementation is designed to be easily refactored to MVP by:

1. **Adding a Presenter** that mediates between Model and View
2. **Making View passive** - removing direct model event subscriptions
3. **Moving view logic** to the presenter
4. **Adding ViewModel** for data binding

The current structure makes this refactoring straightforward while maintaining clean separation of concerns.
