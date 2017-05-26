namespace DirectoryTraversal
{
    using System.Collections.Generic;

    public class DirectoryTraverser
    {
        public DirectoryTraverser(string directory, IDirectoryProvider directoryProvider)
        {
            this.CurrentDirectory = directory;
            this.DirectoryProvider = directoryProvider;
        }

        public string CurrentDirectory { get; set; }

        public IDirectoryProvider DirectoryProvider { get; set; }


        public IEnumerable<string> GetChildDirectories()
        {
            var directories = DirectoryProvider.GetDirectories(this.CurrentDirectory);

            var directoryNames = new List<string>(directories.Length);
            foreach (var directory in directories)
            {
                int lastBackSlash = directory.LastIndexOf("\\");
                string directoryName = directory.Substring(lastBackSlash + 1);

                directoryNames.Add(directoryName);
            }

            directoryNames.Sort();

            return directoryNames;
        }
    }

    public interface IDirectoryProvider
    {
        string[] GetDirectories(string path);
    }
}
