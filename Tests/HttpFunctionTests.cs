using Functions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using TNDStudios.Helpers.AzureFunctions.Testing.Factories;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;
using Xunit;

namespace Tests
{
    public class HttpFunctionTests
    {
        [Fact]
        public void Bad_Request_If_No_Name_Given()
        {
            // Arrange
            ILogger logger = TestLoggerFactory.CreateLogger();
            IBinder binder = TestBinderFactory.CreateBinder();
            DefaultHttpRequest httpRequest = TestHttpFactory.CreateHttpRequest();

            // Act
            HttpResult result = TestHttpFactory.GetHttpResult(
                HttpFunction.Run(httpRequest, binder, logger).Result
                );

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("Please pass a name on the query string or in the request body", result.Value);
        }

        [Fact]
        public void Green_Path()
        {
            // Arrange
            ILogger logger = TestLoggerFactory.CreateLogger();
            IBinder binder = TestBinderFactory.CreateBinder();
            DefaultHttpRequest httpRequest = TestHttpFactory.CreateHttpRequest("name", "Joe");

            // Act
            HttpResult result = TestHttpFactory.GetHttpResult(
                HttpFunction.Run(httpRequest, binder, logger).Result
                );

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
