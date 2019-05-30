using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Mocks
{
    public class TestBinder : Binder
    {
        private IList<TestTextWriter> textWriters;
        public IList<TestTextWriter> TextWriters { get => textWriters; }

        public TestBinder()
        {
            textWriters = new List<TestTextWriter>();
        }

        public override Task<TValue> BindAsync<TValue>(Attribute[] attributes, CancellationToken cancellationToken = default)
        {
            Object result = default(TValue);
            String typeString = typeof(TValue).Name.ToLower().Replace("system.", String.Empty);

            switch (typeString)
            {
                case "textwriter":
                    TestTextWriter textWriter = new TestTextWriter();
                    textWriters.Add(textWriter);
                    result = textWriter;
                    break;
            }

            return Task.FromResult((TValue)result);
        }
    }

}
