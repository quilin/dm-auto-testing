namespace DmAutoTesting.Browsers.Factories
{
    public interface IBrowserAdapterFactory
    {
        IBrowserAdapter Create(string logPath);
    }
}