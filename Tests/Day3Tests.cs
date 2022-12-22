using Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

            string result = string.Join("", rucksack.GetItemsSharedBetweenCompartments());
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class PriorityTests
    {
        [TestMethod]
        [DataRow('p', 16)]
        [DataRow('L', 38)]
        [DataRow('P', 42)]
        [DataRow('v', 22)]
        [DataRow('t', 20)]
        [DataRow('s', 19)]
        public void GetPriority_ReturnsTheCorrectPriority(char ch, int expected)
        {
            Assert.AreEqual(ch.GetPriority(), expected);
        }

        [TestMethod]
        public void GetPrioritySum_ReturnsTheCorrectTotal()
        {
            string[] rucksackStrings = new string[]
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            };

            IEnumerable<Rucksack> rucksacks = rucksackStrings
                .Select(str => new Rucksack(str));

            int result = rucksacks
                .Select(rucksack => rucksack.GetItemsSharedBetweenCompartments())
                .Select(sharedItems => sharedItems
                    .Select(item => item.GetPriority())
                    .Sum())
                .Sum();

            Assert.AreEqual(157, result);
        }
    }

    [TestClass]
    public class RucksackGroupTests
    {
        [TestMethod]
        [DataRow(new string[] { "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg" }, "r")]
        [DataRow(new string[] { "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw" }, "Z")]
        public void SharedItems_ReturnsTheCorrectResult(string[] rucksackStrings, string expected)
        {
            IEnumerable<IRucksack> rucksacks = rucksackStrings.Select(str => new Rucksack(str));
            IRucksackGroup group = new RucksackGroup(rucksacks);

            Assert.AreEqual(expected, string.Join("", group.SharedItems()));
        }
    }
}
