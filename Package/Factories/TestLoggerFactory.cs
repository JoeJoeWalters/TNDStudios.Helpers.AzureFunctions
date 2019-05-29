using Microsoft.Extensions.Logging;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestLoggerFactory
    {
        public static ILogger CreateLogger()
            => new TestLogger();
    }
}
