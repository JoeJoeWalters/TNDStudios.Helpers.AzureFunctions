using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Functions
{
    public static class BlobFunction
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("samples-workitems/{name}", Connection = "BlobConnectionString")]Stream triggerBlob,
            string name,
            [Blob("sample-images-sm/{name}", FileAccess.Write)] Stream outputStream1,
            [Blob("sample-images-md/{name}", FileAccess.Write)] Stream outputStream2,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {triggerBlob.Length} Bytes");

            triggerBlob.Position = 0;
            triggerBlob.CopyTo(outputStream1);

            triggerBlob.Position = 0;
            triggerBlob.CopyTo(outputStream2);
        }
    }
}
