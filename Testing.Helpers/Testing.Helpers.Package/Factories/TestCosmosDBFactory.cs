using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestCosmosDBFactory
    {
        /// <summary>
        /// Get test Document Client for Cosmos DB
        /// </summary>
        /// <returns></returns>
        public static IDocumentClient CreateDocumentClient() => CreateDocumentClient(new List<Document>() { });
        public static IDocumentClient CreateDocumentClient(List<Document> initialisingDocuments)
        {
            IDocumentClient client = Substitute.For<IDocumentClient>();
            client
                .CreateDocumentAsync(Arg.Any<string>(), Arg.Any<object>())
                .Returns(callInfo => 
                    {
                        Document resource = new Document();
                        initialisingDocuments.Add(resource);
                        return new ResourceResponse<Document>(resource);
                    });

            return client;
        }
    }
}
