
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Program
    {
        public static void Main()
        {
            string file = Properties.Resources.strategy_guide;
            string[] lines = file.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            Console.WriteLine("Part 1: " + TotalScore(lines, GameRoundParseOptions.OpponentSelf));
            Console.WriteLine("Part 2: " + TotalScore(lines, GameRoundParseOptions.OpponentOutcome));

            Console.ReadKey();
        }

        public static int TotalScore(string[] lines, GameRoundParseOptions options)
        {
            List<IGameRound> rounds = new List<IGameRound>();

            foreach (string line in lines)
            {
                IGameRound round = new GameRound(line, options);
                rounds.Add(round);
            }

            return rounds
                .Select(round => round.Score())
                .Sum();
        }
    }
}
