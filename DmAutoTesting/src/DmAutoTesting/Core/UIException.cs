using System;
using DmAutoTesting.Pages;

namespace DmAutoTesting.Core
{
    public class UiException<T> : Exception
        where T : Page
    {
        public UiException() : base($"Error while loading page {typeof(T).Name}.")
        {
        }
    }
}