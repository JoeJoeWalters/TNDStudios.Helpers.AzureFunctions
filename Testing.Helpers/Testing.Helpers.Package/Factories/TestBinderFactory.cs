using TNDStudios.Helpers.AzureFunctions.Testing.Mocks;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Factories
{
    public static class TestBinderFactory
    {
        /// <summary>
        /// Create a basic mock for the actual class and not the interface
        /// due to Binder extending IBinder and not implementing it's own interface
        /// </summary>
        /// <returns>A overloaded Binder implementation</returns>
        public static TestBinder CreateBinder()
            => new TestBinder();
    }
}
