using System;

namespace DmAutoTesting.Pages
{
    public class PageLoadException<TPage> : Exception
        where TPage : IPage
    {
        public PageLoadException(string url) : base($"Unable to load page {typeof(TPage).Name} by url {url}")
        {
        }
    }
}