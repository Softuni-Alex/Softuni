using RPGGame.Characters;

namespace RPGGame.Interfaces
{
    public interface IPlayer : ICharacter, IMovable, ICollect, IHeal
    {

        PlayerRace Race { get; }

    }
}
