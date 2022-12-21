using Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Day1
{
    [TestClass]
    public class CalorieCounterTests
    {
        [TestMethod]
        public void Total_OfEmptyInput_ReturnsTheCorrectValue()
        {
            string[] input = new string[] { };
            ICalorieCounter counter = new CalorieCounter(input);

            Assert.AreEqual(0, counter.Total());
        }

        [TestMethod]
        public void Total_OfOneCalorieList_ReturnsTheCorrectValue()
        {
            string[] input = new string[]
            {
                "2000",
                "1000",
                "500",
            };
            ICalorieCounter counter = new CalorieCounter(input);

            Assert.AreEqual(3500, counter.Total());
        }

        [TestMethod]
        public void Max_OfEmptyInput_ReturnsTheCorrectValue()
        {
            string[] input = new string[] { };
            ICalorieCounter counter = new CalorieCounter(input);

            Assert.AreEqual(0, counter.Max());
        }

        [TestMethod]
        public void Max_OfOneCalorieList_ReturnsTheCorrectValue()
        {
            string[] input = new string[]
            {
                "2000",
                "1000",
                "500",
            };
            ICalorieCounter counter = new CalorieCounter(input);

            Assert.AreEqual(3500, counter.Max());
        }

        [TestMethod]
        public void Top_ReturnsTheCorrectValue()
        {
            string[] input = new string[]
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000",
            };
            ICalorieCounter counter = new CalorieCounter(input);

            IEnumerable<int> topCalories = counter.Top(3);

            Assert.AreEqual(3, topCalories.Count());
            Assert.AreEqual(24000, topCalories.ElementAt(0));
            Assert.AreEqual(11000, topCalories.ElementAt(1));
            Assert.AreEqual(10000, topCalories.ElementAt(2));
            Assert.AreEqual(45000, topCalories.Sum());
        }

        [TestMethod]
        public void Top_OfOneCalorieList_ReturnsTheCorrectValue()
        {
            string[] input = new string[]
            {
                "2000",
                "1000",
                "500",
            };
            ICalorieCounter counter = new CalorieCounter(input);

            IEnumerable<int> topCalories = counter.Top(1);

            Assert.AreEqual(1, topCalories.Count());
            Assert.AreEqual(3500, topCalories.ElementAt(0));
            Assert.AreEqual(3500, topCalories.Sum());
        }

        [TestMethod]
        public void Top_WhenCountExceedsListCount_ReturnsTheCorrectValue()
        {
            string[] input = new string[]
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000",
            };
            ICalorieCounter counter = new CalorieCounter(input);

            IEnumerable<int> topCalories = counter.Top(20);

            Assert.AreEqual(5, topCalories.Count());
            Assert.AreEqual(55000, counter.Top(20).Sum());
        }
    }
}
