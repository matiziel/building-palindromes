using System;
using System.Collections.Generic;
using System.Text;

namespace building_palindromes
{
    public class KMPPalindromes : BuildingPalindromes
    {
        public KMPPalindromes(string first, string second) : base(first, second) { }
        public override string GetLongestPalindrome()
        {
            SetUpData();
            FindAllPalindromes();
            return FindLongestPalindrome();
        }

        private void FindAllPalindromes()
        {
            var patternsFromFirst = GetAllSubstrings(ReverseString(first));
            var patternsFromSecond = GetAllSubstrings(ReverseString(second));
            foreach (var pattern in patternsFromFirst)
            {
                allPalindromes.AddRange(GetPalindromes(second, secondPalindromes, pattern));
            }
            foreach (var pattern in patternsFromSecond)
            {
                allPalindromes.AddRange(GetPalindromes(first, firstPalindromes, pattern));
            }
        }
        private List<string> GetAllSubstrings(string input)
        {
            var allSubstrings = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int k = i; k < input.Length; k++)
                {
                    allSubstrings.Add(input.Substring(i, k - i + 1));
                }
            }
            return allSubstrings;
        }

        private List<string> GetPalindromes(string input, PalindromeSearch inputPalindromes, string pattern)
        {
            var palindromes = new List<string>();
            var matches = ModifiedKnuthMorrisPrath.GetAllMatches(input, inputPalindromes, pattern);
            palindromes.AddRange(matches);
            return palindromes;
        }
    }
}
