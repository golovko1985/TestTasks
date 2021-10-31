using System;
using System.IO;
using System.Diagnostics;

namespace DateStamp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool result = false;
            string dirName = @"..\..\DateStampTestFiles";
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                DateTime nextWorkDay = (Calendar.GetNextWorkingDay(DateTime.Today));
                result = DateStamp.AddToFiles(files, "$$18", nextWorkDay.ToString("dd.MM.yyyy"));
            }
            else
            {
                Console.WriteLine($"Dir: {dirName} not found.");
                return;
            }
            stopWatch.Stop();
            string elapsedTime = stopWatch.ElapsedMilliseconds.ToString();
            string msg = result ? $"Done. Elapsed time: {elapsedTime} ms." :
                $"Error. AddDateStamps() returned {result}";
            Console.WriteLine(msg);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
