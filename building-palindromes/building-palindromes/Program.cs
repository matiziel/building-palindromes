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
            var results = new Dictionary<int, double>();
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
                        var test = new BuildingPalindromes(s1, s2);
                        results[s1.Length] = MeasureAlgorithTime(test.GetLongestPalindrome);
                    }
                }
                using (StreamWriter outputFile = new StreamWriter(@"../../../Results.txt"))
                {
                    foreach (var line in results)
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
