using DmAutoTesting.Browsers.Adapters;

namespace DmAutoTesting.Browsers
{
    public class CookieBrowser : BaseBrowser, ICookieBrowser
    {
        public CookieBrowser(IBrowserAdapter browserAdapter) : base(browserAdapter)
        {
        }

        public void ClearCookies()
        {
            BrowserAdapter.ClearCookies();
        }

        public void SetCookie(string name, string value)
        {
            BrowserAdapter.SetCookie(name, value);
        }
    }
}