using Functions;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TNDStudios.Helpers.AzureFunctions.Testing.Factories;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;
using Xunit;

namespace Tests
{
    public class CosmosDBFunctionTests
    {
        [Fact]
        public void Green_Path()
        {
            // Arrange
            ILogger logger = TestLoggerFactory.CreateLogger();

            List<Document> documents = TestCosmosDBFactory
                .CreateDocumentList(
                    TestStreamFactory.CreateStream(
                        TestStreamType.EmbeddedResource,
                        Encoding.UTF8, "*.Data.Files.documentloader.json"));

            TestAsyncCollector<Document> output = TestCollectorFactory
                .CreateAsyncCollector<Document>(documents);

            IDocumentClient documentClient = TestCosmosDBFactory
                .CreateDocumentClient(documents,
                    new DocumentClientTestPolicy()
                    {
                        ReadException = new Exception() { },
                        WriteException = new Exception() { }
                    });

            // Act
            CosmosDBFunction.Run(documents, output, documentClient, logger);

            // Assert
            Assert.Equal(2, output.WrittenItems.Count);
        }
    }
}
