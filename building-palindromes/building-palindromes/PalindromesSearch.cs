using System;
using System.Linq;

namespace building_palindromes
{
    public class PalindromeSearch
    {
        public string[] PalindromesAfter { get; private set; }
        public string[] PalindromesBefore { get; private set; }

        private readonly string input;

        public PalindromeSearch(string input)
        {
            this.input = input;
            PalindromesAfter = new string[input.Length + 1];
            PalindromesBefore = new string[input.Length + 1];

        }
        public void SetAllPalindromes()
        {
            for (int i = 0; i <= input.Length; i++)
            {
                string palindrome = GetLongestPalindromeFromPosition(input, i);
                PalindromesAfter[i] = palindrome;
            }
            string reversedInput = new string(input.Reverse().ToArray());
            for (int i = 0; i <= input.Length; i++)
            {
                string palindrome = GetLongestPalindromeFromPosition(reversedInput, i);
                PalindromesBefore[reversedInput.Length - i] = palindrome;
            }

        }
        private string GetLongestPalindromeFromPosition(string input, int position)
        {
            int lastPalindromeIndex = input.Length;
            int begin = position, end = lastPalindromeIndex;

            while (end > begin)
            {
                do
                    --lastPalindromeIndex;
                while (input[position] != input[lastPalindromeIndex]);

                begin = position;
                end = lastPalindromeIndex;

                while (input[begin] == input[end])
                {
                    if (end == begin || end == begin + 1)
                        return input.Substring(position, lastPalindromeIndex + 1 - position);
                    ++begin;
                    --end;
                }
            }
            return "";
        }
    }
}
