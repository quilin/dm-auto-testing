using System;

namespace DmAutoTesting.Pages
{
    public class PageLoadException<T> : Exception
        where T : Page
    {
        public PageLoadException(string pageTitle, string url)
            : base($"Unable to load page {typeof(T).Name}. Page with title {pageTitle} is loaded instead. Url: {url}")
        {
        }
    }
}