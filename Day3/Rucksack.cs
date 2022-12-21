using System.Linq;

namespace Day3
{
    public interface IRucksack
    {
        string Compartment1 { get; }

        string Compartment2 { get; }

        string SharedItems();
    }

    public class Rucksack : IRucksack
    {
        public string Compartment1 { get; private set; }

        public string Compartment2 { get; private set; }

        public Rucksack(string line)
        {
            int half = line.Length / 2;
            Compartment1 = line.Substring(0, half);
            Compartment2 = line.Substring(half);
        }

        public Rucksack(string compartment1, string compartment2)
        {
            Compartment1 = compartment1;
            Compartment2 = compartment2;
        }

        public string SharedItems()
        {
            return string.Join("", Compartment1.Intersect(Compartment2));
        }
    }
}
