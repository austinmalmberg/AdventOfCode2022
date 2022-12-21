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

            int totalSharedItemPriorities = rucksacks
                .Select(rucksack => rucksack
                    .SharedItems()
                    .GetItemPriority())
                .Sum();

            Console.WriteLine("Part 1: " + totalSharedItemPriorities);

            Console.ReadKey();
        }
    }
}
