namespace TirePresuring
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();

        double ReadPressureSample();
    }
}
