using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main()
        {
            string[] words = File.ReadAllLines(@"C:\dev\repos\SearchAlgorithms\LevenshteinDistance\words.txt");

            string testWord = "test";

            string[] distancesParallel = new string[words.Length];
            string[] distances = new string[words.Length];




            DateTime startTimeLP = DateTime.Now;
            Console.WriteLine("Computing Levenshtein Parallel...");

            Parallel.For(0, words.Length,
                index =>
                {
                    int distance = LevenshteinDistance.Compute(testWord, words[index]);
                    distancesParallel[index] = distance.ToString();
                });

            File.WriteAllLines(@"c:/temp/distancesParallel.txt", distancesParallel);

            DateTime endTimeLP = DateTime.Now;
            TimeSpan totalTimeLP = endTimeLP.Subtract(startTimeLP);
            Console.WriteLine("Total time taken: " + totalTimeLP);





            DateTime startTimeL = DateTime.Now;
            Console.WriteLine("Computing Levenshtein...");

            for (int i=0; i<words.Length; i++)
            {
                int distance = LevenshteinDistance.Compute(testWord, words[i]);

                distances[i] = distance.ToString();
            }

            File.WriteAllLines(@"c:/temp/distances.txt", distances);

            DateTime endTimeL = DateTime.Now;
            TimeSpan totalTimeL = endTimeL.Subtract(startTimeL);
            Console.WriteLine("Total time taken: " + totalTimeL);






            var winkler = new JaroWinkler();

            string[] similaritiesParallel = new string[words.Length + 1];
            string[] similarities = new string[words.Length + 1];




            DateTime startTimeWP = DateTime.Now;
            Console.WriteLine("Computing Winkler Parallel...");

            Parallel.For(0, words.Length,
                index =>
                {
                    double similarity = winkler.Similarity(testWord, words[index]);
                    similaritiesParallel[index] = similarity.ToString();
                });

            File.WriteAllLines(@"c:/temp/similaritiesParallel.txt", similaritiesParallel);

            DateTime endTimeWP = DateTime.Now;
            TimeSpan totalTimeWP = endTimeWP.Subtract(startTimeWP);
            Console.WriteLine("Total time taken: " + totalTimeWP);





            DateTime startTimeW = DateTime.Now;
            Console.WriteLine("Computing Winkler...");

            for (int i = 0; i < words.Length; i++)
            {
                double similarity = winkler.Similarity(testWord, words[i]);
                similarities[i] = similarity.ToString();
            }

            
            File.WriteAllLines(@"c:/temp/similarities.txt", similarities);

            DateTime endTimeW = DateTime.Now;
            TimeSpan totalTimeW = endTimeW.Subtract(startTimeW);
            Console.WriteLine("Total time taken: " + totalTimeW);





            Console.ReadLine();
        }
    }
}