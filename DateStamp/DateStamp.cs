using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace DateStamp
{
    public class DateStamp
    {
        public static bool AddToFiles(string[] filePaths, string mask, string nextWorkDay)
        {
            // Thread-safe collection
            var docs = new BlockingCollection<Document>();
            // Build the pipeline
            var stageRead = Task.Run(() =>
            {
                try
                {
                    foreach (var filePath in filePaths)
                    {
                        using (var reader = new StreamReader(filePath))
                        {
                            Console.WriteLine($"Read file {filePath}");
                            Document doc = new Document(filePath, reader.ReadToEnd());
                            docs.Add(doc);
                        }
                    }
                }
                finally
                {
                    docs.CompleteAdding();
                }
            });
            var stageWrite = Task.Run(() =>
            {
                foreach (Document doc in docs.GetConsumingEnumerable())
                {
                    Console.WriteLine($"Write to file {doc.filePath}");
                    using (StreamWriter writer = File.CreateText(doc.filePath))
                    {
                        writer.Write(doc.content.Replace(mask,
                            $"\r\nдата ввода изменений – {nextWorkDay}\r\n" + mask));
                    }
                }
            });
            Task.WaitAll(stageRead, stageWrite);
            return stageRead.Status == TaskStatus.RanToCompletion &&
                   stageWrite.Status == TaskStatus.RanToCompletion;
        }
    }
}
