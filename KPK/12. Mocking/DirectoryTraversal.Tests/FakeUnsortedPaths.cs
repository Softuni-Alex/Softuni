namespace DirectoryTraversal.Tests
{
    public class FakeUnsortedPaths : IDirectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return new string[]
            {
                "obj",
                "bin",
                "assets",
                "Assets",
            };
        }
    }
}