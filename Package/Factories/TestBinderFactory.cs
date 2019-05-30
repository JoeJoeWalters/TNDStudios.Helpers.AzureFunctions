using Microsoft.Azure.WebJobs;
using System;
using System.IO;
using System.Threading;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestBinderFactory
    {
        /// <summary>
        /// Create a basic mock for the actual class and not the interface
        /// due to Binder extending IBinder and not implementing it's own interface
        /// </summary>
        /// <returns>A Mocked Binder</returns>
        public static Binder CreateBinder()
        {
            return new Binder();
        }
    }
}
