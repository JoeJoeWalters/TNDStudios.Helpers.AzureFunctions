using Microsoft.Azure.Documents;
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
        public static IDocumentClient CreateDocumentClient()
        {
            IDocumentClient client = Substitute.For<IDocumentClient>();
            client.CreateDocumentAsync("", null)
                .WhenForAnyArgs(call => 
                {

                });

            return client;
        }
    }
}
