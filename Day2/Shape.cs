using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    public static class ShapeExtensions
    {
        public static string Opponent(this Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return "A";
                case Shape.Paper:
                    return "B";
                case Shape.Scissors:
                    return "C";
                default:
                    throw new NotImplementedException();
            }
        }

        public static string Self(this Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return "X";
                case Shape.Paper:
                    return "Y";
                case Shape.Scissors:
                    return "Z";
                default:
                    throw new NotImplementedException();
            }
        }

        public static int PointValue(this Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return 1;
                case Shape.Paper:
                    return 2;
                case Shape.Scissors:
                    return 3;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public static class ShapeAdapter
    {
        /// <exception cref="ArguementException">Thrown if <paramref name="raw"/> is not a valid Shape string.</exception>
        public static Shape ParseString(string raw)
        {
            foreach (Shape shape in Enum.GetValues(typeof(Shape)).Cast<Shape>())
            {
                if (raw == shape.Opponent() ||
                    raw == shape.Self())
                {
                    return shape;
                }
            }

            throw new ArgumentException(string.Format("{0} is not a valid Shape string", raw));
        }

        /// <exception cref="ArguementException">Thrown if <paramref name="raw"/> is not a valid Shape string.</exception>
        public static Shape ParseSelf(string raw)
        {
            foreach (Shape shape in Enum.GetValues(typeof(Shape)).Cast<Shape>())
            {
                if (raw == shape.Self()) return shape;
            }

            throw new ArgumentException(string.Format("{0} is not a valid Shape string", raw));
        }

        /// <exception cref="ArguementException">Thrown if <paramref name="raw"/> is not a valid Shape string.</exception>
        public static Shape ParseOpponent(string raw)
        {
            foreach (Shape shape in Enum.GetValues(typeof(Shape)).Cast<Shape>())
            {
                if (raw == shape.Opponent()) return shape;
            }

            throw new ArgumentException(string.Format("{0} is not a valid Shape string", raw));
        }
    }
}
