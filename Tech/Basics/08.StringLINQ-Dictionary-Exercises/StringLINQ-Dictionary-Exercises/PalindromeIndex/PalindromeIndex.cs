using System;

namespace PalindromeIndex
{
    class PalindromeIndex
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(indexPalindrome(input));

        }

        // 1 <  len < 100005
        public static int indexPalindrome(string s)
        {
            int len = s.Length;

            if (isPalindrome(s, -1))
                return -1;
            for (int i = 0; i < len; i++)
            {
                if (isPalindrome(s, i))
                    return i;
            }
            return -1;
        }

        private static bool isPalindrome(string s, int index)
        {
            int len = s.Length;
            int start = 0;
            int end = len - 1;

            while (start <= end)
            {
                if (start == index)
                    start++;
                else if (end == index)
                    end--;
                else if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }
    }
}