using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace task.parallelism
{
    class Program
    {
        public static void sequential_task_processing()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;
            int punctuationMarks = TextProcessing.NumberOfPunctuationMarks(text);
            var longestWords = TextProcessing.LongestWords(words);
            var shortestWords = TextProcessing.ShortestWords(words);
            int greatestOccurrence, lowestOccurrence;
            var wordsAppearMoreTimes = TextProcessing.WordsAppearMoreTimes(words, out greatestOccurrence);
            var wordsAppearFewerTimes = TextProcessing.WordsAppearFewerTimes(words, out lowestOccurrence);
            DateTime after = DateTime.Now;

            TextProcessing.ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
        }


        public static void parallel_task_processing()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;
            string[] longestWords = null, shortestWords = null, wordsAppearMoreTimes = null, wordsAppearFewerTimes = null;
            int greatestOccurrence = 0, lowestOccurrence = 0, punctuationMarks = 0;
            Parallel.Invoke(
                () => punctuationMarks = TextProcessing.NumberOfPunctuationMarks(text),
                () => longestWords = TextProcessing.LongestWords(words),
                () => shortestWords = TextProcessing.ShortestWords(words),
                () => wordsAppearMoreTimes = TextProcessing.WordsAppearMoreTimes(words, out greatestOccurrence),
                () => wordsAppearFewerTimes = TextProcessing.WordsAppearFewerTimes(words, out lowestOccurrence)
                 );
            DateTime after = DateTime.Now;

            TextProcessing.ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
        }
        

        static void Main(string[] args)
        {
            sequential_task_processing();

            parallel_task_processing();

            Console.ReadLine();
        }
    }

}
