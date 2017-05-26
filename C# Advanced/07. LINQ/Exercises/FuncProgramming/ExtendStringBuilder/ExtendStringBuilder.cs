using System.Text;

namespace ExtendStringBuilder
{
    public static class ExtendStringBuilder
    {
        static StringBuilder Substring(this StringBuilder sb, int startIndex, int count)
        {
            StringBuilder newBuilder = new StringBuilder();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                newBuilder.Append(sb[i]);
            }
            return newBuilder;
        }

        static void Main(string[] args)
        {
            StringBuilder alphabet = new StringBuilder();

            for (int i = 'a'; i <= 'z'; i++)
            {
                alphabet.Append((char)i);
            }

            var firstTenLetters = alphabet.Substring(0, 10);

            System.Console.WriteLine(firstTenLetters);
        }
    }
}
