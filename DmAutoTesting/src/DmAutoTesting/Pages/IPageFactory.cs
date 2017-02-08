using DmAutoTesting.Browsers;

namespace DmAutoTesting.Pages
{
    public interface IPageFactory
    {
        T Create<T>(IPageAdapter pageAdapter, IBrowser browser) where T : Page, new();
    }
}