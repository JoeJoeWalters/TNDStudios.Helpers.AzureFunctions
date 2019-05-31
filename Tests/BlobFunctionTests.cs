using Functions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
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
            TestStream triggerBlob = TestStreamFactory.CreateStream(Encoding.UTF8, "Test Data");
            TestStream outputBlob1 = TestStreamFactory.CreateStream();
            TestStream outputBlob2 = TestStreamFactory.CreateStream();

            // Act
            BlobFunction.Run(triggerBlob, name, outputBlob1, outputBlob2, logger);

            // Assert
            Assert.Equal(triggerBlob.Content, outputBlob1.Content);
            Assert.Equal(triggerBlob.Content, outputBlob2.Content);
        }
    }
}
