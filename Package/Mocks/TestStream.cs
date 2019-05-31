using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Mocks
{
    public class TestStream : MemoryStream
    {
        public String Content { get => Encoding.UTF8.GetString(base.ToArray()); }

        public TestStream() : base() => Initialise(String.Empty);
        public TestStream(String content) : base() => Initialise(content);
        public void Initialise(String content)
        {
            byte[] contentBytes = Encoding.UTF8.GetBytes(content);
            base.Write(contentBytes, 0, contentBytes.Length);
        }
    }
}
