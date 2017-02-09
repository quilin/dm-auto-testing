using DmAutoTesting.Elements.Searchers;

namespace DmAutoTesting.Elements.Adapters
{
    public interface IElementAdapter
    {
        IElementLocator ElementLocator { get; }

        bool IsEmpty { get; }
        bool Displayed { get; }
        bool Enabled { get; }

        string TagName { get; }

        int Height { get; }
        int Width { get; }
        string Text { get; }

        void Click();
        void HoverMouse();
        void Clear();
        void SendKeys(string text);

        string GetAttribute(string name);
    }
}