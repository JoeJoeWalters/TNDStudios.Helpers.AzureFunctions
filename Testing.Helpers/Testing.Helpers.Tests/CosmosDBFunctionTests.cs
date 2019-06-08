using Functions;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
            List<Document> documents = new List<Document>() { new Document() };
            TestAsyncCollector<Document> output = TestCollectorFactory.CreateAsyncCollector<Document>();

            // Act
            CosmosDBFunction.Run(documents, output, logger);

            // Assert
            Assert.Equal(1, output.WrittenItems.Count);
        }
    }
}
