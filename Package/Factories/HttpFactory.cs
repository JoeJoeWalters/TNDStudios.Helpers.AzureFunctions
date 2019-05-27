using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class HttpFactory
    {
        public static DefaultHttpRequest CreateHttpRequest()
            => CreateHttpRequest(String.Empty, String.Empty, String.Empty, new HeaderDictionary());

        public static DefaultHttpRequest CreateHttpRequest(
            String queryStringKey,
            String queryStringValue)
            => CreateHttpRequest(queryStringKey, queryStringValue, String.Empty, new HeaderDictionary());

        public static DefaultHttpRequest CreateHttpRequest(
            String queryStringKey,
            String queryStringValue,
            String body)
            => CreateHttpRequest(queryStringKey, queryStringValue, body, new HeaderDictionary());

        public static DefaultHttpRequest CreateHttpRequest(
            String queryStringKey, 
            String queryStringValue,
            String body,
            IHeaderDictionary headers)
        {
            // Do we need to implement a query collection to hold querystring
            // elements to process?
            QueryCollection query = new QueryCollection();
            if ((queryStringKey ?? String.Empty) != String.Empty &&
                (queryStringValue ?? String.Empty) != String.Empty)
            {
                query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue));
            }

            // Generate the request based on the parameters calculated
            DefaultHttpRequest request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Query = query,
                Body = new MemoryStream(Encoding.UTF8.GetBytes(body ?? String.Empty))
            };

            // Calculate the headers
            headers = headers ?? new HeaderDictionary();
            foreach(var header in headers)
                request.Headers.Add(header);

            // Send the request back
            return request;
        }

        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        /// <summary>
        /// Convert the action result of an azure http function to a http status code
        /// </summary>
        /// <param name="functionResult">The Task based outout from a http azure function</param>
        /// <returns>The http status code</returns>
        public static HttpStatusCode GetHttpStatusCode(Task<IActionResult> functionResult)
            => GetHttpStatusCode(functionResult.Result);
        public static HttpStatusCode GetHttpStatusCode(IActionResult functionResult)
        {
            try
            {
                return (HttpStatusCode)functionResult
                    .GetType()
                    .GetProperty("StatusCode")
                    .GetValue(functionResult, null);
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        } 
    }
}
