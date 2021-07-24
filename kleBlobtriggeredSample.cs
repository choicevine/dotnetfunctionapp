using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace kleSampleFunctionApp
{
    public static class kleBlobtriggeredSample
    {
        [FunctionName("kleBlobtriggeredSample")]
        public static void Run(
            [BlobTrigger("samples-workitems/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            [Blob("output/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")]Stream outputBlob, 
            string name, 
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            var len = myBlob.Length;
            myBlob.CopyTo(outputBlob);
        }
    }
}
