namespace DmAutoTesting.Browsers
{
    public interface ICookieBrowser : IBrowser
    {
        void ClearCookies();
        void SetCookie(string name, string value);
    }
}