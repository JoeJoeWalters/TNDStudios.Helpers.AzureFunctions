using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNDStudios.Helpers.AzureFunctions.CosmosDB
{
    public static class CosmosDBHelperFactory
    {
        public static CosmosDBWriterHelper GetWriter(IAsyncCollector<Document> collector)
            => new CosmosDBWriterHelper(collector);
    }
}
