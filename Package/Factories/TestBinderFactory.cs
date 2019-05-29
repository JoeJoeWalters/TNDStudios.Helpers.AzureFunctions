using Microsoft.Azure.WebJobs;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestBinderFactory
    {
        public static IBinder CreateBinder()
            => new TestBinder();
    }
}
