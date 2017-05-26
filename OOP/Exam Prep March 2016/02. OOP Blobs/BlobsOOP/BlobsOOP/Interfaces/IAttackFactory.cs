namespace BlobsOOP.Interfaces
{
    public interface IAttackFactory
    {
        IAttack Create(string attackName);
    }
}
