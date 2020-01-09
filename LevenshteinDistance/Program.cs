using System;
using System.Collections.Generic;
using System.IO;

namespace LevenshteinDistance
{
    /// <summary>
    /// Contains approximate string matching
    /// </summary>
    static class LevenshteinDistance
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }

    class Program
    {
        static void Main()
        {
            string[] words = File.ReadAllLines(@"C:\dev\repos\SearchAlgorithms\LevenshteinDistance\words.txt");
            //    new List<string[]>
            //{
            //    new string[]{"ant", "aunt"},
            //    new string[]{"Sam", "Samantha"},
            //    new string[]{"clozapine", "olanzapine"},
            //    new string[]{"flomax", "volmax"},
            //    new string[]{"toradol", "tramadol"},
            //    new string[]{"kitten", "sitting"}
            //};
            string testWord = "test";

            DateTime startTime = DateTime.Now;
            Console.WriteLine("Computing...");

            List<string> likeWords = new List<string>();

            foreach (string word in words)
            {
                
                int distance = LevenshteinDistance.Compute(testWord, word);

                Console.WriteLine("{0} -> {1} = {2}",
                    testWord,
                    word,
                    distance);

                if (distance < 2)
                {
                    likeWords.Add(word);
                }
            }

            DateTime endTime = DateTime.Now;
            TimeSpan totalTime = endTime.Subtract(startTime);
            Console.WriteLine("Total time taken: " + totalTime);

            Console.WriteLine("Did you mean: ");
            foreach (string word in likeWords) 
            {
                Console.WriteLine(word);
            } 
        }
    }
}