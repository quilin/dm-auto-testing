using DmAutoTesting.Browsers.Adapters;

namespace DmAutoTesting.Browsers.Factories
{
    public interface IBrowserAdapterFactory
    {
        IBrowserAdapter Create(BrowserType browserType, string logPath);
    }
}