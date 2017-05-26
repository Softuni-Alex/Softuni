namespace RPGGame.Interfaces
{
    public interface ICharacter : IAtack, IDestroyable
    {

        string Name { get; }

        Position Position { get; }

    }
}
