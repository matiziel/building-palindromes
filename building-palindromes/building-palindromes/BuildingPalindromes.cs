using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace building_palindromes
{
    class BuildingPalindromes
    {
        private string first;
        private string second;

        public BuildingPalindromes(string first, string second)
        {
            if (first.Length >= second.Length)
            {
                this.first = first;
                this.second = second;
            }
            else
            {
                this.first = second;
                this.second = first;
            }
        }
        public string GetLongestPalindrome()
        {
            second = ReversedShorterString();
            throw new NotImplementedException();
        }
        private string ReversedShorterString()
        {
            return new string(second.Reverse().ToArray());
        }
        private List<string> GetAllSubstringsFromShorterString()
        {
            var allSubstrings = new List<string>();
            for (int i = 0; i < second.Length; i++)
            {
                for (int k = i; k < second.Length; k++)
                {
                    allSubstrings.Add(second.Substring(i, k - i + 1));
                }
            }
            return allSubstrings;
        }
    }
}
