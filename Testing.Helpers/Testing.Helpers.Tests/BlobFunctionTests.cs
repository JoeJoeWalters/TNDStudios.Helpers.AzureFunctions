using Functions;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using TNDStudios.Helpers.AzureFunctions.Testing.Factories;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;
using Xunit;

namespace Tests
{
    public class BlobFunctionTests
    {
        [Fact]
        public void Green_Path()
        {
            // Arrange
            ILogger logger = TestLoggerFactory.CreateLogger();
            String name = "name of the blob";
            TestStream triggerBlob = TestStreamFactory.CreateStream(TestStreamType.EmbeddedResource,
                                                                    Encoding.UTF8,
                                                                    "Tests.Data.Files.TestFile.xml");
            TestStream outputBlob1 = TestStreamFactory.CreateStream(TestStreamType.Content);
            TestStream outputBlob2 = TestStreamFactory.CreateStream(TestStreamType.Content);

            // Act
            BlobFunction.Run(triggerBlob, name, outputBlob1, outputBlob2, logger);

            // Assert
            Assert.Equal(triggerBlob.Content, outputBlob1.Content);
            Assert.Equal(triggerBlob.Content, outputBlob2.Content);
        }
    }
}
