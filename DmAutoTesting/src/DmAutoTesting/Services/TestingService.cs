using DmAutoTesting.Browsers;

namespace DmAutoTesting.Services
{
    public abstract class TestingService : ITestingService
    {
        protected TestingService(
            IBrowser browser
            )
        {
            Browser = browser;
        }

        protected IBrowser Browser { get; }

        public virtual void Dispose()
        {
        }
    }
}