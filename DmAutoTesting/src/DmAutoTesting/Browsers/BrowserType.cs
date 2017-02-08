using System.ComponentModel;

namespace DmAutoTesting.Browsers
{
    public enum BrowserType
    {
        [Description("Chrome, Chromium, Safari, Opera")]
        Webkit,
        [Description("Firefox")]
        Gecko,
        [Description("Internet Explorer")]
        Trident
    }
}