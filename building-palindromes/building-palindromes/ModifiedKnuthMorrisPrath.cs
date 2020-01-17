using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace building_palindromes
{
    static class ModifiedKnuthMorrisPrath
    {
        public static List<string> GetAllMatches(string input, PalindromeSearch inputPalindromes, string pattern)
        {
            var palindromes = new List<string>();
            int[] prefixArray = ComputePrefixFunction(pattern);
            int q = 0;
            for (int i = 0; i < input.Length; i++)
            {
                while (q > 0 && pattern[q] != input[i])
                    q = prefixArray[q - 1];
                if (pattern[q] == input[i])
                    ++q;
                if (q == pattern.Length)
                {
                    palindromes.Add(BuildString(pattern, inputPalindromes.PalindromesAfter[i + 1], ReverseString(pattern)));     //add palindrome form next position
                    palindromes.Add(BuildString(ReverseString(pattern), inputPalindromes.PalindromesBefore[i - pattern.Length + 1], pattern)); //add palindrome form previous position

                    q = prefixArray[q - 1];
                }
            }
            return palindromes;
        }
        private static int[] ComputePrefixFunction(string pattern)
        {
            int[] prefixArray = new int[pattern.Length];
            prefixArray[0] = 0;
            int k = 0;
            for (int i = 1; i < pattern.Length; i++)
            {
                while (k > 0 && pattern[k] != pattern[i])
                    k = prefixArray[k - 1];

                if (pattern[k] == pattern[i])
                    ++k;

                prefixArray[i] = k;
            }
            return prefixArray;
        }
        private static string BuildString(string s1, string s2, string s3)
        {
            StringBuilder sb = new StringBuilder(s1);
            sb.Append(s2);
            sb.Append(s3);
            return sb.ToString();
        }

        private static string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}
