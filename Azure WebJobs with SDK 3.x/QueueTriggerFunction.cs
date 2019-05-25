using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace Azure_WebJobs_with_SDK_3.x
{
    public class QueueTriggerFunction
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.

        //This is a Queue Trigger Function, which listens to the queue named "testqueue"
        public void ProcessWorkItem([QueueTrigger("testqueue")] string message, ILogger logger)
        {
            Console.WriteLine(message);
        }
    }
}
