using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;

namespace Tests
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

            Assert.AreEqual(45000, counter.Top(3));
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

            Assert.AreEqual(3500, counter.Top(1));
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

            Assert.AreEqual(55000, counter.Top(20));
        }
    }
}
