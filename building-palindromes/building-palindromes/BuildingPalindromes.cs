using System;
using System.Collections.Generic;
using System.Linq;

namespace building_palindromes
{
    public abstract class BuildingPalindromes
    {
        protected string first;
        protected PalindromeSearch firstPalindromes;

        protected string second;
        protected PalindromeSearch secondPalindromes;

        protected List<string> allPalindromes;

        public BuildingPalindromes(string first, string second)
        {
            allPalindromes = new List<string>();
            this.first = first;
            firstPalindromes = new PalindromeSearch(first);
            this.second = second;
            secondPalindromes = new PalindromeSearch(second);
        }
        public abstract string GetLongestPalindrome();

        protected void SetUpData()
        {
            firstPalindromes.SetAllPalindromes();
            secondPalindromes.SetAllPalindromes();
        }

        protected string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }

        protected string FindLongestPalindrome()
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
