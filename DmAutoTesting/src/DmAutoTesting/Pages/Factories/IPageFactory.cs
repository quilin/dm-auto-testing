using DmAutoTesting.Pages.Adapters;

namespace DmAutoTesting.Pages.Factories
{
    public interface IPageFactory
    {
        TPage Create<TPage>(IPageAdapter pageAdapter) where TPage : IPage, new();
    }
}