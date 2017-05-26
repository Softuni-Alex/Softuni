namespace TestAirConditioner
{
    using AirConditioner.Controller;
    using AirConditioner.Files;
    using AirConditioner.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

    [TestClass]
    public class MockAirConditioner
    {
        private Engine engine;
        private IConditioner conditioner;

        [TestInitialize]
        public void SetUp()
        {
            this.engine = new Engine(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Mock_TestAirConditionerShouldThrow()
        {
            //Arrange

            var mock = new Mock<Controller>();
            mock.Setup(c => c.TestAirConditioner(null, null))
                .Returns(new AirConditioner().ToString);

            //Act

            var conditioner = new Conditioner(null, null, 0, null);
            conditioner.EnergyRating = 10;

            var result = conditioner;
            //Assert

            Assert.AreEqual(10, result.EnergyRating);
        }
    }
}