
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IGameRound> rounds = new List<IGameRound>();
            string file = Properties.Resources.strategy_guide;

            foreach (string line in file.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                IGameRound round = new GameRound(line);
                rounds.Add(round);
            }

            int totalScore = rounds
                .Select(round => round.Score())
                .Sum();

            Console.WriteLine("Part 1: " + totalScore);

            Console.ReadKey();
        }
    }
}
