using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace building_palindromes
{
    public class BuildingPalindromes
    {
        private string first;
        private PalindromeSearch firstPalindromes;

        private string second;
        private PalindromeSearch secondPalindromes;

        private List<string> allPalindromes;

        public BuildingPalindromes(string first, string second)
        {
            allPalindromes = new List<string>();
            this.first = first;
            firstPalindromes = new PalindromeSearch(first);
            this.second = second;
            secondPalindromes = new PalindromeSearch(second);
        }
        public string GetLongestPalindrome()
        {
            SetUpData();
            FindAllPalindromes();
            return FindLongestPalindrome();
        }
        private void SetUpData()
        {
            firstPalindromes.SetAllPalindromes();
            secondPalindromes.SetAllPalindromes();

            //palindromes only from one string
            //allPalindromes.AddRange(firstPalindromes.PalindromesAfter);
            //allPalindromes.AddRange(secondPalindromes.PalindromesAfter);
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
        private string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
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
        private string FindLongestPalindrome()
        {
            string longestPalindrome = null;

            allPalindromes = allPalindromes.OrderByDescending(t => t.Length).ThenBy(t => t).ToList();

            if (allPalindromes.Count > 0)
            {
                longestPalindrome = allPalindromes.First();
            }
            return longestPalindrome;
        }

    }
}
