using Examples.Hangman;
using Examples.Hangman.Console;

// Create the MVC components
var game = new Hangman();
var output = new ConsoleOutput();
var input = new ConsoleInput();

// Connect the view to the model (MVC pattern)
output.ListenTo(game);

// Start the input processing (which acts as the controller)
input.StartProcessing(game);
