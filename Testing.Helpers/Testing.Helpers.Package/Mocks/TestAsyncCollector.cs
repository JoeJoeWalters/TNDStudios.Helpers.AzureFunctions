using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Mocks
{
    public class TestAsyncCollector<T> : IAsyncCollector<T>
    {
        private IList<T> writtenItems;
        public IList<T> WrittenItems { get => writtenItems; }

        public TestAsyncCollector(List<T> initialisingList)
            => writtenItems = initialisingList ?? new List<T>();

        public Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            writtenItems.Add(item);
            return Task.FromResult<Boolean>(true);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            writtenItems.Clear();
            return Task.FromResult<Boolean>(true);

        }
    }
}
