using System;

namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TirePresuring;

    [TestClass]
    public class TestTirePressuring
    {
        [TestMethod]
        public void TestIfAlarmIsOn()
        {
            IAlarm isAlarmOn = new Alarm();
            bool isOn = isAlarmOn.AlarmOn;

            Assert.IsFalse(isOn);
        }

        [TestMethod]
        public void Test_PopNextPressureValue()
        {
            ISensor sensor = new Sensor();
            var nextPressure = sensor.PopNextPressurePsiValue();
            var readPressure = sensor.ReadPressureSample();

            var pressureValue = readPressure;

            Assert.AreEqual(readPressure, pressureValue);
        }

        [TestMethod]
        public void TestMockRandom()
        {
            var mock = new Mock<Random>();
            mock.Setup(r => r.Next()).Returns(0);

            for (int i = 0; i < 1000; i++)
            {
                var num = mock.Object.Next(0);

                Assert.AreEqual(0, num);
            }
        }
    }
}