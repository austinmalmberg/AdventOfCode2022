using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public interface IRucksack
    {
        string AllItems { get; }

        string Compartment1 { get; }

        string Compartment2 { get; }

        IEnumerable<char> GetItemsSharedBetweenCompartments();
    }

    public class Rucksack : IRucksack
    {
        public string AllItems { get; private set; }

        public string Compartment1
        {
            get
            {
                return AllItems.Substring(0, AllItems.Length / 2);
            }
        }

        public string Compartment2
        {
            get
            {
                return AllItems.Substring(AllItems.Length / 2);
            }
        }

        public Rucksack(string line)
        {
            AllItems = line;
        }

        public Rucksack(string compartment1, string compartment2)
        {
            AllItems = string.Join("", new string[] { compartment1, compartment2 });
        }

        public IEnumerable<char> GetItemsSharedBetweenCompartments()
        {
            return Compartment1.Intersect(Compartment2);
        }
    }

    public interface IRucksackGroup
    {
        IEnumerable<char> SharedItems();
    }

    public class RucksackGroup : List<IRucksack>, IRucksackGroup
    {
        public RucksackGroup() : base() { }
        public RucksackGroup(int capacity) : base(capacity) { }
        public RucksackGroup(IEnumerable<IRucksack> collection) : base(collection) { }

        public IEnumerable<char> SharedItems()
        {
            IEnumerable<char> sharedItems = null;

            foreach (Rucksack rucksack in this)
            {
                IEnumerable<char> items = rucksack.AllItems.ToCharArray();

                if (sharedItems == null)
                {
                    sharedItems = new List<char>(items);
                }
                else
                {
                    sharedItems = sharedItems.Intersect(items);
                }
            }

            return sharedItems;
        }
    }
}
