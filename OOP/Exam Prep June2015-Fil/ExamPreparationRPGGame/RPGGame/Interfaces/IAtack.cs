namespace RPGGame.Interfaces
{
    public interface IAtack
    {

        int Damage { get; set; }

        void Atack(ICharacter enemy);

    }
}
