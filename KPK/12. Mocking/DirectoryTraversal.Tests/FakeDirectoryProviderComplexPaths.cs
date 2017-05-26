namespace DirectoryTraversal.Tests
{
    public class FakeDirectoryProviderComplexPaths : IDirectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return new string[]
            {
                @"D:\Alex\nonempty",
                @"C:\asdasdas\bin",
            };
        }
    }
}
