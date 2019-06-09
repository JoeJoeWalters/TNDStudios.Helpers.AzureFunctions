using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TNDStudios.Helpers.AzureFunctions.CosmosDB
{
    public class CosmosDBWriterHelper : IDisposable
    {
        private IAsyncCollector<Document> collector;

        public CosmosDBWriterHelper(IAsyncCollector<Document> collector)
        {
            this.collector = collector;
        }

        public async Task<Boolean> AddAsync(Document document)
        {
            try
            {
                await collector.AddAsync(document);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            // Don't kill collector in this case as it might be needed for when a test
            // async collector is injected to test the function
        }
    }
}
