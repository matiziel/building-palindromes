using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace building_palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultsKmp = new Dictionary<int, double>();
            var resultsBetterNaive = new Dictionary<int, double>();
            try
            { 
                using (StreamReader sr = new StreamReader(@"../../../DataFile.txt"))
                {
                    while (true)
                    {
                        string s1 = sr.ReadLine();
                        if (s1 == null)
                            break;
                        string s2 = sr.ReadLine();
                        if (s2 == null)
                            break;
                        var testKmp = new KMPPalindromes(s1, s2);
                        var testBetterNaive = new QuiteBetterNaivePalindromes(s1, s2);
                        resultsKmp[s1.Length] = MeasureAlgorithTime(testKmp.GetLongestPalindrome);
                        resultsKmp[s1.Length] = MeasureAlgorithTime(testBetterNaive.GetLongestPalindrome);
                    }
                }
                using (StreamWriter outputFile = new StreamWriter(@"../../../ResultsKmp.txt"))
                {
                    foreach (var line in resultsKmp)
                    {
                        outputFile.WriteLine(line.Key);
                        outputFile.WriteLine(line.Value);
                    }
                }
                using (StreamWriter outputFile = new StreamWriter(@"../../../ResultsBetterNaive.txt"))
                {
                    foreach (var line in resultsBetterNaive)
                    {
                        outputFile.WriteLine(line.Key);
                        outputFile.WriteLine(line.Value);
                    }
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
            Console.WriteLine(s1);
            // Get the elapsed time as a TimeSpan value.
            return stopWatch.Elapsed.TotalMilliseconds;
        }
    }
}
