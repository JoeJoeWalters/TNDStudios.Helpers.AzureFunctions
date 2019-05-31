using System;
using System.IO;
using System.Reflection;
using System.Text;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public enum TestStreamType
    {
        Content,
        EmbeddedResource
    }

    public static class TestStreamFactory
    {
        public static TestStream CreateStream(TestStreamType type) => CreateStream(type, Encoding.UTF8, String.Empty);
        public static TestStream CreateStream(TestStreamType type, Encoding encoding) => CreateStream(type, encoding, String.Empty);
        public static TestStream CreateStream(TestStreamType type, Encoding encoding, String loadFrom)
        {
            String value = String.Empty;

            switch (type)
            {
                case TestStreamType.EmbeddedResource:

                    using (Stream resourceStream = Assembly
                            .GetCallingAssembly()
                            .GetManifestResourceStream(loadFrom))
                    {
                        using (StreamReader sr = new StreamReader(resourceStream, encoding))
                        {
                            value = sr.ReadToEnd();
                        }
                    }

                    break;

                default:

                    value = loadFrom;

                    break;
            }

            TestStream result = new TestStream(encoding, value);
            
            return result;
        }
    }
}
