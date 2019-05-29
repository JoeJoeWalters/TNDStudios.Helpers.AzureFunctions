using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Mocks
{
    public class TestBinder : IBinder
    {
        public Task<T> BindAsync<T>(Attribute attribute, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
