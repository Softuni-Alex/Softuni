namespace MockDateTimes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MockDateTime;
    using Moq;
    using System;

    [TestClass]
    public class DateTimeMock
    {
        [TestMethod]
        public void TestDateTimeNow()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 7, 31));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expectedDate = new DateTime(2015, 8, 1);

            Assert.AreEqual(expectedDate, date);

            //   var month = mock.Object.DateTimeNow.AddYears(4);
            //   var expectedMonth = new DateTime(2019, 8, 1);
            //
            //   Assert.AreEqual(expectedMonth, month);
        }
    }
}