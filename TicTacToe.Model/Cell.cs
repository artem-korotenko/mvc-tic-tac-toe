namespace Examples.TicTacToe
{
    using System;

    public class Cell
    {
        public Player MarkedByPlayer { get; private set; }

        public bool IsEmpty => MarkedByPlayer == null;

        internal void MarkBy(Player player)
        {
            if (!IsEmpty)
            {
                throw new Exception("Can not mark cell second time");
            }

            MarkedByPlayer = player;
        }
    }
}