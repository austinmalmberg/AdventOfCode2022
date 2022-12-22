using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Program
    {
        public static void Main()
        {
            string file = Properties.Resources.rucksacks;
            string[] lines = file.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            IEnumerable<IRucksack> rucksacks = lines
                .Select(line => new Rucksack(line));

            Console.WriteLine("Part 1: " + Part1Solution(rucksacks));
            Console.WriteLine("Part 2: " + Part2Solution(rucksacks.ToList()));

            Console.ReadKey();
        }

        public static int Part1Solution(IEnumerable<IRucksack> rucksacks)
        {
            return rucksacks
                .Select(rucksack => rucksack
                    .GetItemsSharedBetweenCompartments()
                    .Select(item => item.GetPriority())
                    .Sum())
                .Sum();
        }

        public static int Part2Solution(List<IRucksack> rucksacks)
        {
            List<IRucksackGroup> groups = new List<IRucksackGroup>();

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                IRucksackGroup group = new RucksackGroup(rucksacks.GetRange(i, 3));
                groups.Add(group);
            }

            return groups
                .Select(group => group.SharedItems()
                    .Select(item => item.GetPriority())
                    .Sum())
                .Sum();
        }
    }
}
