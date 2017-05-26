namespace AirConditioner.Interfaces
{
    public interface IConditioner
    {
        int EnergyRating { get; set; }

        string Manufacturer { get; set; }

        int VolumeCovered { get; set; }

        int ElectricityUsed { get; set; }

        string Model { get; set; }

        int Test();
    }
}