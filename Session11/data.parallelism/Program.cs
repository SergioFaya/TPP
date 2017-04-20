using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace task.parallelism
{
    class Program
    {
        public static void sequential_image_processing()
        {
            DateTime before = DateTime.Now;
            string[] files = Directory.GetFiles(@"..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\pics\rotated_sequential";
            Directory.CreateDirectory(newDirectory);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file))
                {
                    Console.WriteLine("Processing the file \"{0}\" with the thread {1}.", fileName, Thread.CurrentThread.ManagedThreadId);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            }

            DateTime after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);


            Console.WriteLine();
            Console.WriteLine();
        }

        public static void parallel_image_processing()
        {
            // Try to implement a parallel version of sequential_image_processing using TPL
            // https://msdn.microsoft.com/da-dk/library/dd537608.aspx

            DateTime before = DateTime.Now;
            string[] fileNames = Directory.GetFiles(@"..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\pics\rotated_parallel";
            Directory.CreateDirectory(newDirectory);
            
            
            // ...
            

            DateTime after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }


        static void Main(string[] args)
        {
            sequential_image_processing();

            parallel_image_processing();
            
            Console.ReadLine();
        }
    }

}


