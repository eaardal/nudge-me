using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NudgeMe.WinForms;

namespace NudgeMe.UnitTests
{
    [TestClass]
    public class TimeConverterTests
    {
        [TestMethod]
        public void FromSecondsToMilliseconds_ShouldConvert1SecondTo1000Ms()
        {
            const int time = 1;

            var actual = TimeConverters.FromSecondsToMilliseconds(time);

            Assert.AreEqual(1000, actual);
        }

        [TestMethod]
        public void FromSecondsToMilliseconds_ShouldConvertFiveSecondsTo5000Ms()
        {
            const int time = 5;

            var actual = TimeConverters.FromSecondsToMilliseconds(time);

            Assert.AreEqual(5000, actual);
        }

        [TestMethod]
        public void FromSecondsToMilliseconds_ShouldConvert7500SecondsTo7500000Ms()
        {
            const int time = 7500;

            var actual = TimeConverters.FromSecondsToMilliseconds(time);

            Assert.AreEqual(7500000, actual);
        }

        [TestMethod]
        public void FromMinutesToMilliseconds_ShouldConvert1MinTo60000Ms()
        {
            const int time = 1;

            var actual = TimeConverters.FromMinutesToMilliseconds(time);

            Assert.AreEqual(60000, actual);
        }

        [TestMethod]
        public void FromMinutesToMilliseconds_ShouldConvert5MinsTo300000Ms()
        {
            const int time = 5;

            var actual = TimeConverters.FromMinutesToMilliseconds(time);

            Assert.AreEqual(300000, actual);
        }

        [TestMethod]
        public void FromMinutesToMilliseconds_ShouldConvert5300MinsTo318000000Ms()
        {
            const int time = 5300;

            var actual = TimeConverters.FromMinutesToMilliseconds(time);

            Assert.AreEqual(318000000, actual);
        }

        [TestMethod]
        public void FromHoursToMilliseconds_ShouldConvert1HourTo3600000Ms()
        {
            const int time = 1;

            var actual = TimeConverters.FromHoursToMilliseconds(time);

            Assert.AreEqual(3600000, actual);
        }

        [TestMethod]
        public void FromHoursToMilliseconds_ShouldConvert7HoursTo25200000Ms()
        {
            const int time = 7;

            var actual = TimeConverters.FromHoursToMilliseconds(time);

            Assert.AreEqual(25200000, actual);
        }

        [TestMethod]
        public void FromHoursToMilliseconds_ShouldConvert15HoursTo54000000Ms()
        {
            const int time = 15;

            var actual = TimeConverters.FromHoursToMilliseconds(time);

            Assert.AreEqual(54000000, actual);
        }

        [TestMethod]
        public void FromDaysToMilliseconds_ShouldConvert1DayTo86400000Ms()
        {
            const int time = 1;

            var actual = TimeConverters.FromDaysToMilliseconds(time);

            Assert.AreEqual(86400000, actual);
        }

        [TestMethod]
        public void FromDaysToMilliseconds_ShouldConvert3DaysTo259200000Ms()
        {
            const int time = 3;

            var actual = TimeConverters.FromDaysToMilliseconds(time);

            Assert.AreEqual(259200000, actual);
        }

        [TestMethod]
        public void FromDaysToMilliseconds_ShouldConvert7DaysTo604800000Ms()
        {
            const int time = 7;

            var actual = TimeConverters.FromDaysToMilliseconds(time);

            Assert.AreEqual(604800000, actual);
        }
    }
}
