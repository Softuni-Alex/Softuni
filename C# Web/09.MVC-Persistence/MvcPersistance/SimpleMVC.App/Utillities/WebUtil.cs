namespace SimpleMVC.App.Utillities
{
    using System.IO;

    public static class WebUtil
    {
        public static string RetrieveFileContent(string path)
        {
            string content = File.ReadAllText(path);

            return content;
        }
    }
}
