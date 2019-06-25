using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Functions
{
    public static class CosmosDBFunction
    {
        private const String inputDatabaseName = "DatabaseName";
        private const String inputCollectionName = "CollectionName";
        private const String inputConnectionStringSetting = "CosmosDBConnection";
        private const String inputLeasesName = "leases";

        private const String outputDatabaseName = "DatabaseName";
        private const String outputCollectionName = "CollectionName";
        private const String outputConnectionStringSetting = "CosmosDBConnection";

        [FunctionName("CosmosDBFunction")]
        public static async void Run(
            [CosmosDBTrigger(
                databaseName: inputDatabaseName,
                collectionName: inputCollectionName,
                ConnectionStringSetting = inputConnectionStringSetting,
                LeaseCollectionName = inputLeasesName)]IReadOnlyList<Document> input,
            [CosmosDB(
                databaseName: outputDatabaseName,
                collectionName: outputCollectionName,
                ConnectionStringSetting = outputConnectionStringSetting,
                CreateIfNotExists = true)]IAsyncCollector<Document> output,
            [CosmosDB(databaseName: outputDatabaseName,
                collectionName: outputCollectionName,
                ConnectionStringSetting = outputConnectionStringSetting
                )] IDocumentClient documentClient,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                try
                {
                    await output.AddAsync(input[0]);
                }
                catch(Exception ex)
                {
                    log.LogError(ex, $"Could not save document to Cosmos - '{ex.Message}'");
                }
            }
        }
    }
}
