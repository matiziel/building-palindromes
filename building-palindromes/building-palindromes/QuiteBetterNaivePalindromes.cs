using System;
using System.Collections.Generic;
using System.Text;

namespace building_palindromes
{
    public class QuiteBetterNaivePalindromes : BuildingPalindromes
    {
        public QuiteBetterNaivePalindromes(string first, string second) : base(first, second) { }

        public override string GetLongestPalindrome()
        {
            SwapIfSecondIsLonger();
            SetUpData();
            FindAllPalindromes();
            return FindLongestPalindrome();
        }
        private void SwapIfSecondIsLonger()
        {
            if (first.Length < second.Length)
            {
                Swap<string>(ref first, ref second);
                Swap<PalindromeSearch>(ref firstPalindromes, ref secondPalindromes);
            }
        }
        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private void FindAllPalindromes()
        {
            var reversedSecond = ReverseString(second);
            for (int i = 0; i < first.Length; i++)
            {
                int longestMatch = 0;
                for (int k = 0; k <= reversedSecond.Length && (k + i) <= first.Length; k++)
                {
                    if ((k < reversedSecond.Length && (k + i) < first.Length) && first[k + i] == reversedSecond[k])
                        ++longestMatch;
                    else if (longestMatch > 0)
                    {
                        string pattern = first.Substring(i + k - longestMatch, longestMatch);
                        AddPalindromesToList(i, k, longestMatch, pattern);
                        longestMatch = 0;
                    }
                    if (longestMatch == second.Length)
                    {
                        AddPalindromesToList(i, k, longestMatch);
                        break;
                    }
                }
            }
        }
        private void AddPalindromesToList(int beginIndex, int endIndex, int longestMatch, string pattern)
        {
            allPalindromes.Add(BuildString( pattern, firstPalindromes.PalindromesAfter[beginIndex + endIndex],  ReverseString(pattern)));
            allPalindromes.Add(BuildString( ReverseString(pattern), firstPalindromes.PalindromesBefore[beginIndex + endIndex - longestMatch - 1],  pattern));

            allPalindromes.Add(BuildString( pattern, secondPalindromes.PalindromesAfter[endIndex], ReverseString(pattern)));
            allPalindromes.Add(BuildString( ReverseString(pattern), secondPalindromes.PalindromesBefore[endIndex - longestMatch], pattern));
        }
        private void AddPalindromesToList(int beginIndex, int endIndex, int longestMatch)
        {
            allPalindromes.Add(BuildString(ReverseString(second), firstPalindromes.PalindromesAfter[beginIndex + endIndex + 1], second));
            allPalindromes.Add(BuildString(second, firstPalindromes.PalindromesBefore[beginIndex + endIndex - longestMatch + 1], ReverseString(second)));
        }
        private static string BuildString(string s1, string s2, string s3)
        {
            StringBuilder sb = new StringBuilder(s1);
            sb.Append(s2);
            sb.Append(s3);
            return sb.ToString();
        }


    }
}
