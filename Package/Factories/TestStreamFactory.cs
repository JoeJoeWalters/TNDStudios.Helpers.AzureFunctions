using System;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestStreamFactory
    {
        public static TestStream CreateStream() => CreateStream(String.Empty);
        public static TestStream CreateStream(String content)
            => new TestStream(content);
    }
}
