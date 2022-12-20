using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public GameRound(string line)
        {
            string[] values = line.Split(' ');

            if (values.Length != 2) throw new ArgumentException();

            Opponent = ShapeAdapter.ParseOpponent(values[0]);
            Self = ShapeAdapter.ParseSelf(values[1]);
        }

        public GameRound(string opponent, string self)
            : this(ShapeAdapter.ParseOpponent(opponent), ShapeAdapter.ParseSelf(self))
        {
        }

        public GameRound(Shape opponent, Shape self)
        {
            Opponent = opponent;
            Self = self;
        }

        public int Score()
        {
            return (int)Self + (int)Outcome;
        }

        public static Outcome GetOutcome(Shape opponent, Shape self)
        {
            switch (self)
            {
                case Shape.Rock:
                    switch (opponent)
                    {
                        case Shape.Paper:
                            return Outcome.Lose;
                        case Shape.Scissors:
                            return Outcome.Win;
                        case Shape.Rock:
                        default:
                            return Outcome.Draw;
                    }
                case Shape.Paper:
                    switch (opponent)
                    {
                        case Shape.Rock:
                            return Outcome.Win;
                        case Shape.Scissors:
                            return Outcome.Lose;
                        case Shape.Paper:
                        default:
                            return Outcome.Draw;
                    }
                case Shape.Scissors:
                    switch (opponent)
                    {
                        case Shape.Rock:
                            return Outcome.Lose;
                        case Shape.Paper:
                            return Outcome.Win;
                        case Shape.Scissors:
                        default:
                            return Outcome.Draw;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
