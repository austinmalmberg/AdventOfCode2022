using System;
using System.Linq;

namespace Day2
{
    public enum Shape
    {
        Rock,
        Paper,
        Scissors,
    }

    public static class ShapeExtensions
    {
        public static Shape SuperiorShape(this Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return Shape.Paper;
                case Shape.Paper:
                    return Shape.Scissors;
                case Shape.Scissors:
                    return Shape.Rock;
                default:
                    throw new NotImplementedException();
            }
        }

        public static Shape InferiorShape(this Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return Shape.Scissors;
                case Shape.Paper:
                    return Shape.Rock;
                case Shape.Scissors:
                    return Shape.Paper;
                default:
                    throw new NotImplementedException();
            }
        }

        public static string AsOpponentString(this Shape shape)
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

        public static string AsSelfString(this Shape shape)
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
                if (raw == shape.AsOpponentString() ||
                    raw == shape.AsSelfString())
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
                if (raw == shape.AsSelfString()) return shape;
            }

            throw new ArgumentException(string.Format("{0} is not a valid Shape string", raw));
        }

        /// <exception cref="ArguementException">Thrown if <paramref name="raw"/> is not a valid Shape string.</exception>
        public static Shape ParseOpponent(string raw)
        {
            foreach (Shape shape in Enum.GetValues(typeof(Shape)).Cast<Shape>())
            {
                if (raw == shape.AsOpponentString()) return shape;
            }

            throw new ArgumentException(string.Format("{0} is not a valid Shape string", raw));
        }
    }
}
