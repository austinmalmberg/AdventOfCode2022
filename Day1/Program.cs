using System;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string file = Properties.Resources.calorie_list;
            string[] lines = file.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            CalorieCounter counter = new CalorieCounter(lines);

            Console.WriteLine("----- Day 1 -----");
            Console.WriteLine(string.Format("Part 1: {0}", counter.Max()));
            Console.WriteLine(string.Format("Part 2: {0}", counter.Top(3)));

            Console.ReadKey();
        }
    }
}
