using System;
using System.Collections.Generic;
using System.Text;
using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestCollectorFactory
    {
        /// <summary>
        /// Return a mocked Async collector for a given type which will collect
        /// the output for a given function of whatever type it may be
        /// </summary>
        /// <returns>A Mocked Binder</returns>
        public static TestAsyncCollector<T> CreateAsyncCollector<T>()
            => new TestAsyncCollector<T>();
    }
}
