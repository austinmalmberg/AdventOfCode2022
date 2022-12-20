using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;

namespace Tests
{
    [TestClass]
    public class ShapeAdapterTests
    {
        [TestMethod]
        [DataRow(Shape.Rock, "X")]
        [DataRow(Shape.Paper, "Y")]
        [DataRow(Shape.Scissors, "Z")]
        [DataRow(Shape.Rock, "A")]
        [DataRow(Shape.Paper, "B")]
        [DataRow(Shape.Scissors, "C")]
        public void ParseString_ReturnsTheCorrectShape(Shape shape, string value)
        {
            Assert.AreEqual(shape, ShapeAdapter.ParseString(value));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("R")]
        public void ParseString_ForInvalidString_ThrowsArgumentException(string value)
        {
            Assert.ThrowsException<ArgumentException>(() => ShapeAdapter.ParseString(value));
        }

        [TestMethod]
        [DataRow(Shape.Rock, "X")]
        [DataRow(Shape.Paper, "Y")]
        [DataRow(Shape.Scissors, "Z")]
        public void ParseSelf_ReturnsTheCorrectShape(Shape shape, string value)
        {
            Assert.AreEqual(shape, ShapeAdapter.ParseSelf(value));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("A")]
        [DataRow("R")]
        public void ParseSelf_ForInvalidString_ThrowsArgumentException(string value)
        {
            Assert.ThrowsException<ArgumentException>(() => ShapeAdapter.ParseSelf(value));
        }

        [TestMethod]
        [DataRow(Shape.Rock, "A")]
        [DataRow(Shape.Paper, "B")]
        [DataRow(Shape.Scissors, "C")]
        public void ParseOpponent_ReturnsTheCorrectShape(Shape shape, string value)
        {
            Assert.AreEqual(shape, ShapeAdapter.ParseOpponent(value));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("X")]
        [DataRow("R")]
        public void ParseOpponent_ForInvalidString_ThrowsArgumentException(string value)
        {
            Assert.ThrowsException<ArgumentException>(() => ShapeAdapter.ParseOpponent(value));
        }
    }

    [TestClass]
    public class GameRoundTests
    {
        [TestMethod]
        public void StringConstructor1_ParsesShapesCorrectly()
        {
            string line = string.Format("{0} {1}", Shape.Rock.Opponent(), Shape.Paper.Self());
            GameRound round = new GameRound(line);

            Assert.AreEqual(Shape.Rock, round.Opponent);
            Assert.AreEqual(Shape.Paper, round.Self);
        }

        [TestMethod]
        public void StringConstructor2_ParsesShapesCorrectly()
        {
            GameRound round = new GameRound(Shape.Rock.Opponent(), Shape.Paper.Self());

            Assert.AreEqual(Shape.Rock, round.Opponent);
            Assert.AreEqual(Shape.Paper, round.Self);
        }
        
        [TestMethod]
        [DataRow(Shape.Rock, Shape.Paper)]
        [DataRow(Shape.Paper, Shape.Scissors)]
        [DataRow(Shape.Scissors, Shape.Rock)]
        public void Outcome_SelfWins(Shape opponent, Shape self)
        {
            IGameRound round = new GameRound(opponent, self);

            Assert.AreEqual(Outcome.Win, round.Outcome);
        }
        
        [TestMethod]
        [DataRow(Shape.Rock, Shape.Rock)]
        [DataRow(Shape.Paper, Shape.Paper)]
        [DataRow(Shape.Scissors, Shape.Scissors)]
        public void Outcome_SelfDraws(Shape opponent, Shape self)
        {
            IGameRound round = new GameRound(opponent, self);

            Assert.AreEqual(Outcome.Draw, round.Outcome);
        }
        
        [TestMethod]
        [DataRow(Shape.Rock, Shape.Scissors)]
        [DataRow(Shape.Paper, Shape.Rock)]
        [DataRow(Shape.Scissors, Shape.Paper)]
        public void Outcome_SelfLoses(Shape opponent, Shape self)
        {
            IGameRound round = new GameRound(opponent, self);

            Assert.AreEqual(Outcome.Lose, round.Outcome);
        }


        [TestMethod]
        [DataRow(Shape.Rock, Shape.Paper, 8)]
        [DataRow(Shape.Paper, Shape.Rock, 1)]
        [DataRow(Shape.Scissors, Shape.Scissors, 6)]
        public void Score_Calculatescorrectly(Shape opponent, Shape self, int score)
        {
            IGameRound round = new GameRound(opponent, self);
            Assert.AreEqual(score, round.Score());
        }
    }
}
