using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    /// <summary>
    /// Definition of how a test document client should behave
    /// </summary>
    public class DocumentClientTestPolicy
    {
        /// <summary>
        /// Exceptions to raise when actions happen
        /// </summary>
        public Exception ReadException { get; set; }
        public Exception WriteException { get; set; }
    }

    public static class TestCosmosDBFactory
    {
        /// <summary>
        /// Convert a list of document from a list of objects, if the 
        /// objects given have an id property then it will be used for the
        /// document id
        /// </summary>
        /// <param name="objects">The objects to initialise the documents</param>
        /// <returns>An initialised list of objects</returns>
        public static List<Document> CreateDocumentList(String resourceString)
        {
            JObject deserialised = JObject.Parse(resourceString);

            return CreateDocumentList(new List<object>());
        }

        public static List<Document> CreateDocumentList(List<object> objects)
        {
            return new List<Document>();
        }

        /// <summary>
        /// Get test Document Client for Cosmos DB
        /// </summary>
        /// <returns></returns>
        public static IDocumentClient CreateDocumentClient(List<Document> initialisingDocuments, DocumentClientTestPolicy policy)
        {
            IDocumentClient client = Substitute.For<IDocumentClient>();

            client
                .CreateDocumentAsync(
                    Arg.Any<string>(), 
                    Arg.Any<object>()
                    )
                .Returns(callInfo => 
                    {
                        // If an exception should be raised when trying to write
                        // a document to Cosmos
                        if (policy.WriteException != null)
                            throw policy.WriteException;

                        Document resource = new Document();
                        //resource.LoadFrom(); callInfo.ArgAt<object>[0]
                        initialisingDocuments.Add(resource);
                        return new ResourceResponse<Document>(resource);
                    });

            client
                .ReadDocumentAsync(
                    Arg.Any<string>(), 
                    Arg.Any<RequestOptions>(), 
                    Arg.Any<CancellationToken>()
                    )
                .Returns(callInfo => 
                    {
                        // If an exception should be raised when trying to read
                        // a document from Cosmos
                        if (policy.ReadException != null)
                            throw policy.ReadException;

                        return new ResourceResponse<Document>();
                    });

            return client;
        }
    }
}
