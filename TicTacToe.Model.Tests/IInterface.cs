namespace Examples.TicTacToe.Model.Tests;

public interface IInterface
{
    static abstract void DoThing();
}

public class Interface : IInterface
{
    public static void DoThing()
    {
        throw new NotImplementedException();
    }
}