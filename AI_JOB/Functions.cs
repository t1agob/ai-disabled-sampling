using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_JOB.Models;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AI_JOB
{
    public class Functions
    {
        private static TelemetryClient telemetry = new TelemetryClient();

        // This function will get triggered/executed when a new message is written to the Message Queue.
        // It's not doing any real work here, but it could do some work like making a request to a service
        // like Microsoft Graph API, or doing sentiment analysis and outputting table storage.
        // To learn more about Queues, go to https://azure.microsoft.com/en-us/documentation/articles/websites-dotnet-webjobs-sdk-storage-queues-how-to/
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TraceWriter log)
        {
            
            log.Verbose("Message Received:");
            log.Verbose(message);

            telemetry.TrackEvent($"Message Received: {message}");
        }
    }
}
