using System;
using System.Text;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestStreamFactory
    {
        public static TestStream CreateStream() => CreateStream(Encoding.UTF8);
        public static TestStream CreateStream(Encoding encoding) => CreateStream(encoding, String.Empty);
        public static TestStream CreateStream(Encoding encoding, String content)
            => new TestStream(encoding, content);
    }
}
