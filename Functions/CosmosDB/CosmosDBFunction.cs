using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public static class CosmosDBFunction
    {
        [FunctionName("CosmosDBFunction")]
        public static async void Run([CosmosDBTrigger(
            databaseName: "databaseName",
            collectionName: "collectionName",
            ConnectionStringSetting = "CosmosDBConnection",
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input,
            [CosmosDB]IAsyncCollector<Document> output,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
                await output.AddAsync(input[0]);
            }
        }
    }
}
