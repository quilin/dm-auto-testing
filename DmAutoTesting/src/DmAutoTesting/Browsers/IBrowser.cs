using System;
using DmAutoTesting.Pages;

namespace DmAutoTesting.Browsers
{
    public interface IBrowser : IDisposable
    {
        IPage CurrentPage { get; }

        IPage WaitForPage(string url);
        T WaitFor<T>() where T : IPage, new();

        IPage SwitchToTab(IPage page);
        T SwitchToTab<T>(T page) where T : IPage, new();

        IPage OpenNewTab(string uri);
        T OpenNewTab<T>() where T : IPage, new();

        IPage CloseCurrentTab();
    }
}