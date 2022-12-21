using Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.Day3
{
    [TestClass]
    public class RucksackTests
    {
        [TestMethod]
        public void LineConstructor_SeparatesCompartmentsCorrectly()
        {
            IRucksack rucksack = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");

            Assert.AreEqual("vJrwpWtwJgWr", rucksack.Compartment1);
            Assert.AreEqual("hcsFMMfFFhFp", rucksack.Compartment2);
        }

        [TestMethod]
        [DataRow("vJrwpWtwJgWrhcsFMMfFFhFp", "p")]
        [DataRow("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "L")]
        [DataRow("PmmdzqPrVvPwwTWBwg", "P")]
        [DataRow("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "v")]
        [DataRow("ttgJtRGJQctTZtZT", "t")]
        [DataRow("CrZsJsPPZsGzwwsLwLmpwMDw", "s")]
        public void SharedItems_ReturnsTheCorrectOutput(string input, string expected)
        {
            IRucksack rucksack = new Rucksack(input);

            Assert.AreEqual(expected, rucksack.SharedItems());
        }
    }

    [TestClass]
    public class ItemPriorityTests
    {
        [TestMethod]
        [DataRow('p', 16)]
        [DataRow('L', 38)]
        [DataRow('P', 42)]
        [DataRow('v', 22)]
        [DataRow('t', 20)]
        [DataRow('s', 19)]
        public void GetItemPriority_ReturnsTheCorrectPriority(char ch, int expected)
        {
            Assert.AreEqual(char.ToString(ch).GetItemPriority(), expected);
        }

        [TestMethod]
        public void GetItemPriority_Sum_ReturnsTheCorrectTotal()
        {
            int result = new string[]
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            }
                .Select(str => new Rucksack(str))
                .Select(rucksack => rucksack.SharedItems())
                .Select(sharedItems => sharedItems.GetItemPriority())
                .Sum();

            Assert.AreEqual(157, result);
        }
    }
}
