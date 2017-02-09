namespace DmAutoTesting.Elements
{
    public interface IElement
    {
        bool Exists { get; }
        bool Visible { get; }
        bool Enabled { get; }

        int Width { get; }
        int Height { get; }
        string Text { get; }

        void Click();
        void HoverMouse();
        void SendKeys(string text);
        string GetAttribute(string name);
        bool HasAttribute(string name);
    }
}