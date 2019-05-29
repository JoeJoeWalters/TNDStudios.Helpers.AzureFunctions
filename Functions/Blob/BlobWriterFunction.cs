using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public static class BlobWriterFunction
    {
        [FunctionName("BlobWriterFunction")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "BlobConnection")]Stream myBlob, 
            string name, 
            IBinder binder, 
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
