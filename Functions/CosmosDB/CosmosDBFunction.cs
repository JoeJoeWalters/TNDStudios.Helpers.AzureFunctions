using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TNDStudios.Helpers.AzureFunctions.CosmosDB;

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
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                using (CosmosDBWriterHelper writer = CosmosDBHelperFactory.GetWriter(output))
                {
                    Boolean writeResult = await writer.AddAsync(input[0]);
                }
            }
        }
    }
}
