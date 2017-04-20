using System;
using System.Threading;

namespace colors
{
    /// <summary>
    /// Shows the error of concurrently accessing a shared resource without synchronization
    /// </summary>
    public class ColorsProgram
    {
        public static readonly ConsoleColor[] colors = 
        { 
            ConsoleColor.DarkBlue,  ConsoleColor.DarkGreen,  ConsoleColor.DarkCyan, 
            ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,  ConsoleColor.DarkYellow,  ConsoleColor.Gray, 
            ConsoleColor.DarkGray,  ConsoleColor.Blue,  ConsoleColor.Green,  ConsoleColor.Cyan,  ConsoleColor.Red, 
            ConsoleColor.Magenta,  ConsoleColor.Yellow, ConsoleColor.White
        };

        static void Main()
        {
            // First, we print colors non synchronized
            Thread[] threads = new Thread[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                Color color = new Color(colors[i]);
                threads[i] = new Thread(color.Show);
            }
            foreach (Thread thread in threads)
                thread.Start();

            Console.ReadLine();


            // Now, we print colors synchronized
            threads = new Thread[ColorsProgram.colors.Length];
            for (int i = 0; i < threads.Length; i++)
            {
                SynchronizedColor color = new SynchronizedColor(ColorsProgram.colors[i]);
                threads[i] = new Thread(color.Show);
            }
            foreach (Thread thread in threads)
                thread.Start();

            Console.ReadLine();
        }
    }
}
