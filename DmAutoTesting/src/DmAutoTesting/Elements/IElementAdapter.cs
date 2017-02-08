using DmAutoTesting.Pages;

namespace DmAutoTesting.Elements
{
    public interface IElementAdapter
    {
        IElementLocator ElementLocator { get; }
        IPageAdapter Page { get; }
        bool Displayed { get; }
        bool Enabled { get; }
        int Height { get; }
        int Width { get; }
        string TagName { get; }
        string InnerText { get; }
        bool IsEmpty { get; }
        void Click();
        void HoverMouse();
        void Clear();
        void SendKeys(string text);
        string GetAttribute(string name);
    }
}