using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace building_palindromes
{
    class Program
    {
        private static Random random = new Random();
        protected static string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }

        static void Main(string[] args)
        {

            try
            {
                for (int k = 0; k < 10; k++)
                {
                    var resultsKmp = new Dictionary<int, double>();
                    var resultsBetterNaive = new Dictionary<int, double>();
                    for (int i = 1; i <= 10; i++)
                    {
                        string s1 = RandomString(i * 100);
                        string s2 = RandomString(i * 100);
                        var testKmp = new KMPPalindromes(s1, s2);
                        var testBetterNaive = new QuiteBetterNaivePalindromes(s1, s2);
                        resultsKmp[s1.Length] = MeasureAlgorithTime(testKmp.GetLongestPalindrome);
                        resultsBetterNaive[s1.Length] = MeasureAlgorithTime(testBetterNaive.GetLongestPalindrome);
                        //Console.WriteLine()
                    }
                    using (StreamWriter outputFile = new StreamWriter($@"../../..//results/ResultsKmp{k}.txt"))
                    {
                        foreach (var line in resultsKmp)
                        {
                            outputFile.WriteLine(line.Key);
                            outputFile.WriteLine(line.Value);
                        }
                    }
                    using (StreamWriter outputFile = new StreamWriter($@"../../../results/ResultsBetterNaive{k}.txt"))
                    {
                        foreach (var line in resultsBetterNaive)
                        {
                            outputFile.WriteLine(line.Key);
                            outputFile.WriteLine(line.Value);
                        }
                    }
                    Console.WriteLine(k);

                }

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }


        static double MeasureAlgorithTime(Func<string> algorithm)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var s1 = algorithm();
            stopWatch.Stop();
            //Console.WriteLine(s1);
            // Get the elapsed time as a TimeSpan value.
            return stopWatch.Elapsed.TotalMilliseconds;
        }

        
        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
