using System;

namespace Day2
{
    public interface IGameRound
    {
        Shape Opponent { get; }
        Shape Self { get; }

        Outcome Outcome { get; }

        int Score();
    }

    public class GameRound : IGameRound
    {
        public Shape Opponent { get; private set; }
        public Shape Self { get; private set; }

        public Outcome Outcome
        {
            get { return GetOutcome(Opponent, Self); }
        }

        /// <exception cref="ArgumentException"></exception>
        public GameRound(string line, GameRoundParseOptions options)
        {
            string[] values = line.Split(' ');
            if (values.Length != 2) throw new ArgumentException();

            Opponent = ShapeAdapter.ParseOpponent(values[0]);

            switch (options)
            {
                case GameRoundParseOptions.OpponentSelf:
                    Self = ShapeAdapter.ParseSelf(values[1]);
                    break;
                case GameRoundParseOptions.OpponentOutcome:
                    Outcome outcome = OutcomeAdapter.ParseString(values[1]);
                    Self = GetShapeForOutcome(outcome, Opponent);
                    break;
                default:
                    throw new ArgumentException(string.Format("'{0}' is not a valid Shape or Outcome.", values[1]));
            }
        }

        public GameRound(string opponent, string arg2, GameRoundParseOptions options)
        {
            Opponent = ShapeAdapter.ParseOpponent(opponent);

            switch (options)
            {
                case GameRoundParseOptions.OpponentSelf:
                    Self = ShapeAdapter.ParseSelf(arg2);
                    break;
                case GameRoundParseOptions.OpponentOutcome:
                    Outcome outcome = OutcomeAdapter.ParseString(arg2);
                    Self = GetShapeForOutcome(outcome, Opponent);
                    break;
                default:
                    throw new ArgumentException(string.Format("'{0}' is not a valid Shape or Outcome.", arg2));
            }
        }

        public GameRound(Shape opponent, Shape self)
        {
            Opponent = opponent;
            Self = self;
        }

        public GameRound(Shape opponent, Outcome outcome)
        {
            Opponent = opponent;
            Self = GetShapeForOutcome(outcome, opponent);
        }

        public int Score()
        {
            return Self.PointValue() + Outcome.PointValue();
        }

        public static Outcome GetOutcome(Shape opponent, Shape self)
        {
            if (opponent == self)
            {
                return Outcome.Draw;
            }
            else if (opponent.SuperiorShape() == self)
            {
                return Outcome.Win;
            }
            else
            {
                return Outcome.Lose;
            }
        }

        public static Shape GetShapeForOutcome(Outcome outcome, Shape opponent)
        {
            switch (outcome)
            {
                case Outcome.Win:
                    return opponent.SuperiorShape();
                case Outcome.Draw:
                    return opponent;
                case Outcome.Lose:
                    return opponent.InferiorShape();
                default:
                    throw new NotImplementedException();
            };
        }
    }

    public enum GameRoundParseOptions
    {
        OpponentSelf,
        OpponentOutcome,
    }
}
