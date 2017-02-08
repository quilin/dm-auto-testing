namespace DmAutoTesting.Browsers.Factories
{
    public interface IBrowserFactory
    {
        IBrowser Create(string siteUrl);
    }
}