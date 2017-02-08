namespace DmAutoTesting.Elements.BasicComponents
{
    public interface IElement
    {
        bool Exists { get; }
        string InnerText { get; }
        bool Visible { get; }
        bool Enabled { get; }
        int Height { get; }
        int Width { get; }

        void Click();
        void HoverMouse();
        void SendKeys(string text);
        string GetAttribute(string name);
        bool HasAttribute(string name);
    }
}