namespace Empires.Interface
{
    /// <summary>
    /// Using a polymorphism for accessing Unit
    /// </summary>
    public interface IUnit
    {
        int Health { get; }
        int AtackDamage { get; }
    }
}
