namespace BlobsOOP.Interfaces
{
    public interface IBehaviorFactory
    {
        IBehavior Create(string behaviorName);
    }
}
