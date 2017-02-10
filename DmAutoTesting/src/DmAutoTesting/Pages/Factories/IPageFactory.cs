namespace DmAutoTesting.Pages.Factories
{
    public interface IPageFactory
    {
        TPage Create<TPage>() where TPage : IPage, new();
    }
}