using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Mocks
{
    /// <summary>
    /// Mocked up writer type to collect what was created by the function
    /// </summary>
    public class TestTextWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8; // Hardcode the encoding type (needed by the base)

        // Items that are written to by the mocked process and can be checked later
        // not done with NSubstitute for now as want to add more complex state based checks
        private List<String> writtenItems = new List<String>();
        public IReadOnlyList<String> WrittenItems { get => writtenItems; }

        // Override the collection of the writing of the text data
        public override void Write(String value) => writtenItems.Add(value);
    }
}
