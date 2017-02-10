namespace DmAutoTesting.Pages.Factories
{
    public class PageFactory : IPageFactory
    {
        public TPage Create<TPage>() where TPage : IPage, new()
        {
            return new TPage();
        }
    }
}