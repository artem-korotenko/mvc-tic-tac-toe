using System;
using NUnit.Framework;

namespace Examples.TicTacToe.Model.Tests
{
    using System.Collections.Generic;
    using Examples.TicTacToe;
    using NUnit.Framework.Internal.Execution;

    [TestFixture]
    public class TicTacToeTests
    {
        private TicTacToe game;

        private Player playerA;

        private Player playerB;

        [SetUp]
        public void SetUp()
        {
            playerA = new Player("Player A");
            playerB = new Player("Player B");
            
            game = new TicTacToe(playerA, playerB);
            game.StartGame();
        }
        
        [Test]
        public void AfterGameIsCreated_ItsFirstPlayersMove()
        {
            Assert.That(game.CurrentPlayer, Is.EqualTo(playerA));
        }

        [Test]
        public void AfterGameIsCreated_FieldIsEmptyAnd3x3()
        {
            var field = game.GetField();
            Assert.That(field.GetLength(0), Is.EqualTo(3));
            Assert.That(field.GetLength(1), Is.EqualTo(3));

            foreach (var cell in field)
            {
                Assert.That(cell.IsEmpty);
            }   
        }

        [Test]
        public void AfterMove_CellIsMarked()
        {
            game.MakeMove(1,1);
            Assert.That(game.GetCellValue(1,1), Is.EqualTo(playerA));
        }
        
        [Test]
        public void AfterMove_PlayersAreSwitched()
        {
            game.MakeMove(1,1);
            Assert.That(game.CurrentPlayer, Is.EqualTo(playerB));
        }
        
        [Test]
        public void AfterWin_ShouldChooseWinner()
        {
            game.MakeMove(0,0);
            game.MakeMove(0,1);
            
            game.MakeMove(1,0);
            game.MakeMove(1,1);
            
            Assert.That(game.IsEnded, Is.False);
            
            game.MakeMove(2,0);
            Assert.That(game.Winner, Is.EqualTo(playerA));
            Assert.That(game.IsEnded, Is.True);
        }
        
        [Test]
        public void AfterAllMoves_ShouldDeclareDraw()
        {
            foreach (var x in new List<int> {0,2,1})
            {
                for (var y = 0; y < 3; y++)
                {
                    game.MakeMove(x,y);
                }
            }
            
            Assert.That(game.IsEnded, Is.True);
            Assert.That(game.Winner, Is.Null);
        }
    }
}