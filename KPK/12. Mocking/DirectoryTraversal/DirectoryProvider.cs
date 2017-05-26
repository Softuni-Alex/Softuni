using System.IO;

namespace DirectoryTraversal
{
    public class DirectoryProvider : IDirectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
    }
}
