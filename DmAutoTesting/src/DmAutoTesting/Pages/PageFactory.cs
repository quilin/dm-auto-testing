using DmAutoTesting.Browsers;

namespace DmAutoTesting.Pages
{
    public class PageFactory : IPageFactory
    {
        public T Create<T>(IPageAdapter pageAdapter, IBrowser browser) where T : Page, new()
        {
            var page = new T();
            page.Initialize(pageAdapter, browser);
            return page;
        }
    }
}