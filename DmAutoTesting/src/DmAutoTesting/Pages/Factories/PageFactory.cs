using DmAutoTesting.Pages.Adapters;

namespace DmAutoTesting.Pages.Factories
{
    public class PageFactory : IPageFactory
    {
        public TPage Create<TPage>(IPageAdapter pageAdapter) where TPage : IPage, new()
        {
            var page = new TPage();
            page.Initialize(pageAdapter);
            return page;
        }
    }
}