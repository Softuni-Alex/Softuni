namespace TirePresuring
{
    public class Alarm : IAlarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor sensor = new Sensor();

       // public Alarm(Sensor sensor)
      //  {
       //     this.sensor = sensor;
      //  }

        bool alarmOn = false;

        public void Check()
        {
            double psiPressureValue = this.sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return this.alarmOn; }
        }
    }
}