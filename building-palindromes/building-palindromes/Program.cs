using System;
using System.Diagnostics;
using System.Threading;

namespace building_palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new BuildingPalindromes("fds", "jdfh");
            Console.WriteLine(test.GetLongestPalindrome());
            Console.WriteLine(MeasureAlgorithTime(test.GetLongestPalindrome));
        }

        static TimeSpan MeasureAlgorithTime(Func<string> algorithm)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            algorithm();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            return stopWatch.Elapsed;
        }
    }
}
