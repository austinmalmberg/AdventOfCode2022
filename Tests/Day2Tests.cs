using Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Day2
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
        public void LineParsingConstructor_WithOpponentSelfOption_ParsesShapesCorrectly()
        {
            string line = string.Format("{0} {1}", Shape.Rock.AsOpponentString(), Shape.Paper.AsSelfString());
            GameRound round = new GameRound(line, GameRoundParseOptions.OpponentSelf);

            Assert.AreEqual(Shape.Rock, round.Opponent);
            Assert.AreEqual(Shape.Paper, round.Self);
        }

        [TestMethod]
        [DataRow(Shape.Rock, Outcome.Win, Shape.Paper)]
        [DataRow(Shape.Rock, Outcome.Draw, Shape.Rock)]
        [DataRow(Shape.Rock, Outcome.Lose, Shape.Scissors)]
        [DataRow(Shape.Paper, Outcome.Win, Shape.Scissors)]
        [DataRow(Shape.Paper, Outcome.Draw, Shape.Paper)]
        [DataRow(Shape.Paper, Outcome.Lose, Shape.Rock)]
        [DataRow(Shape.Scissors, Outcome.Win, Shape.Rock)]
        [DataRow(Shape.Scissors, Outcome.Draw, Shape.Scissors)]
        [DataRow(Shape.Scissors, Outcome.Lose, Shape.Paper)]
        public void LineParsingConstructor_WithOpponentOutcomeOption_ParsesShapesCorrectly(Shape opponent, Outcome outcome, Shape expected)
        {
            string line = string.Format("{0} {1}", opponent.AsOpponentString(), outcome.AsString());
            GameRound round = new GameRound(line, GameRoundParseOptions.OpponentOutcome);

            Assert.AreEqual(expected, round.Self);
        }

        [TestMethod]
        [DataRow(Shape.Rock, Shape.Paper, Outcome.Win)]
        [DataRow(Shape.Rock, Shape.Rock, Outcome.Draw)]
        [DataRow(Shape.Rock, Shape.Scissors, Outcome.Lose)]
        [DataRow(Shape.Paper, Shape.Scissors, Outcome.Win)]
        [DataRow(Shape.Paper, Shape.Paper, Outcome.Draw)]
        [DataRow(Shape.Paper, Shape.Rock, Outcome.Lose)]
        [DataRow(Shape.Scissors, Shape.Rock, Outcome.Win)]
        [DataRow(Shape.Scissors, Shape.Scissors, Outcome.Draw)]
        [DataRow(Shape.Scissors, Shape.Paper, Outcome.Lose)]
        public void StringParsingConstructor_WithOpponentSelfOption_ParsesShapesCorrectly(Shape opponent, Shape self, Outcome expected)
        {
            GameRound round = new GameRound(opponent.AsOpponentString(), self.AsSelfString(), GameRoundParseOptions.OpponentSelf);

            Assert.AreEqual(expected, round.Outcome);
        }

        [TestMethod]
        [DataRow(Shape.Rock, Outcome.Win, Shape.Paper)]
        [DataRow(Shape.Rock, Outcome.Draw, Shape.Rock)]
        [DataRow(Shape.Rock, Outcome.Lose, Shape.Scissors)]
        [DataRow(Shape.Paper, Outcome.Win, Shape.Scissors)]
        [DataRow(Shape.Paper, Outcome.Draw, Shape.Paper)]
        [DataRow(Shape.Paper, Outcome.Lose, Shape.Rock)]
        [DataRow(Shape.Scissors, Outcome.Win, Shape.Rock)]
        [DataRow(Shape.Scissors, Outcome.Draw, Shape.Scissors)]
        [DataRow(Shape.Scissors, Outcome.Lose, Shape.Paper)]
        public void StringParsingConstructor_WithOpponentOutcomeOption_ParsesShapesCorrectly(Shape opponent, Outcome outcome, Shape expected)
        {
            GameRound round = new GameRound(opponent.AsOpponentString(), outcome.AsString(), GameRoundParseOptions.OpponentOutcome);

            Assert.AreEqual(expected, round.Self);
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
