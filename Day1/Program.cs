using System;
using System.Linq;

namespace Day1
{
    public class Program
    {
        public static void Main()
        {
            string file = Properties.Resources.calorie_list;
            string[] lines = file.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            CalorieCounter counter = new CalorieCounter(lines);

            Console.WriteLine("----- Day 1 -----");
            Console.WriteLine("Part 1: " + counter.Max());
            Console.WriteLine("Part 2: " + counter.Top(3).Sum());

            Console.ReadKey();
        }
    }
}
