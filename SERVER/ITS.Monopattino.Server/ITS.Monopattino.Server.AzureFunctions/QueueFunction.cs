using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ITS.Monopattino.Server.AzureFunctions
{
    public static class QueueFunction
    {
        [FunctionName("QueueFunction")]
        public static void Run([QueueTrigger("detection", Connection = "")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
