namespace TestAirConditioner
{
    using AirConditioner.Controller;
    using AirConditioner.Files;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AirConditionerTests
    {
        private Engine engine;
        private Controller registerAirConditioner;
        [TestInitialize]
        public void TestInitialize()
        {
            this.engine = new Engine(null, null);
            this.registerAirConditioner = new Controller(this.engine);
        }
    }
}