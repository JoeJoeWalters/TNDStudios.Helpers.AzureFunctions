using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Mocks
{
    public class TestAsyncCollector<T> : IAsyncCollector<T>
    {
        /// <summary>
        /// List of pre-defined objects in the collector or a new array
        /// to show what was collected
        /// </summary>
        private IList<T> writtenItems;
        public IList<T> WrittenItems { get => writtenItems; }

        /// <summary>
        /// Matching logic to define whether we should apply merge logic
        /// to writes to the collector
        /// </summary>
        private Func<T, T, Boolean> matchLogic;
        private Boolean DefaultMatchLogic(T input, T compareTo) => false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="initialisingList">The initialising list of items</param>
        /// <param name="matchLogic">Logic to tell if the collector should merge</param>
        public TestAsyncCollector(List<T> initialisingList, Func<T, T, Boolean> matchLogic)
        {
            // Assign the logic for item matching (if we should do merges on writing)
            this.matchLogic = (matchLogic == null) ? 
                DefaultMatchLogic : (Func<T, T, Boolean>)matchLogic;

            // Assign the initialised list to the incoming list (so we can share the object reference)
            this.writtenItems = initialisingList ?? new List<T>();
        }

        public Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            // Check the match logic first to see if we need to apply merges etc.
            T foundItem = default(T);
            Boolean found = false;

            foreach (T compareTo in writtenItems)
            {
                if (matchLogic(item, compareTo))
                {
                    foundItem = compareTo;
                    found = true;
                }
            }

            if (found)
                foundItem = item;
            else
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
