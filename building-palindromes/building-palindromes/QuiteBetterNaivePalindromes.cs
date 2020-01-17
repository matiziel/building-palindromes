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
            if(first.Length < second.Length)
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
                        allPalindromes.Add(pattern + firstPalindromes.PalindromesAfter[i + k] + ReverseString(pattern));
                        allPalindromes.Add(ReverseString(pattern) + firstPalindromes.PalindromesBefore[i + k - longestMatch - 1] + pattern);

                        allPalindromes.Add(pattern + secondPalindromes.PalindromesAfter[k] + ReverseString(pattern));
                        allPalindromes.Add(ReverseString(pattern) + secondPalindromes.PalindromesBefore[k - longestMatch] + pattern);

                        longestMatch = 0;
                    }
                    if (longestMatch == second.Length)
                    {
                        allPalindromes.Add(BuildString(reversedSecond, firstPalindromes.PalindromesAfter[i + k + 1], second));
                        allPalindromes.Add(BuildString(second, firstPalindromes.PalindromesBefore[i + k - longestMatch + 1], reversedSecond));
                        break;
                    }
                    //if (k == second.Length - 1 && longestMatch > 0)
                    //{
                    //    string pattern = first.Substring(i + k - longestMatch, longestMatch);
                    //    allPalindromes.Add(BuildString(reversedSecond, firstPalindromes.PalindromesAfter[i + k + 1], second));
                    //    allPalindromes.Add(BuildString(second, firstPalindromes.PalindromesBefore[i + k - longestMatch + 1], reversedSecond));
                    //    break;
                    //}

                }
            }
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
