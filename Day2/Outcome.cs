using System;

namespace Day2
{
    public enum Outcome
    {
        Lose,
        Draw,
        Win,
    }

    public static class OutcomeExtensions
    {
        public static int PointValue(this Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.Win:
                    return 6;
                case Outcome.Draw:
                    return 3;
                case Outcome.Lose:
                    return 0;
                default:
                    throw new NotImplementedException();
            }
        }

        public static string AsString(this Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.Win:
                    return "Z";
                case Outcome.Draw:
                    return "Y";
                case Outcome.Lose:
                    return "X";
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public static class OutcomeAdapter
    {
        public static Outcome ParseString(string outcome)
        {
            switch (outcome)
            {
                case "X":
                    return Outcome.Lose;
                case "Y":
                    return Outcome.Draw;
                case "Z":
                    return Outcome.Win;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
