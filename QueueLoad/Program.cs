using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace QueueLoad
{
    class Program
    {
        private static CloudQueue queue = null;
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                Console.WriteLine("Job Starting");
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["Iterations"]);
                int timeInterval = Convert.ToInt32(ConfigurationManager.AppSettings["TimeIntervalMS"]);

                for (int i = 0; i < length; i++)
                {
                    if (queue == null)
                    {
                        // Retrieve storage account information from connection string.
                        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

                        CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

                        queue = queueClient.GetQueueReference("queue");

                        try
                        {
                            await queue.CreateIfNotExistsAsync();
                        }
                        catch
                        {
                            Console.WriteLine("If you are running with the default configuration please make sure you have started the storage emulator.  ess the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                            Console.ReadLine();
                            throw;
                        }
                    }

                    
                    await queue.AddMessageAsync(new CloudQueueMessage($"Message number: {i}"));
                    Console.WriteLine($"Message number {i} added to queue.");

                    Thread.Sleep(timeInterval);
                }
            }).Wait();
            Console.WriteLine("Job Finished");
        }
    }
}
