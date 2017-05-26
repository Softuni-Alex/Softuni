namespace RPGGame.Interfaces
{
    public interface IExperienceGainable
    {

        int Experience { get; }

        void LevelUp();
    }
}
