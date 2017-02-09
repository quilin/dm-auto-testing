using DmAutoTesting.Elements.Adapters;

namespace DmAutoTesting.Elements
{
    public abstract class BaseElement
    {
        protected readonly IElementAdapter Element;

        protected BaseElement(
            IElementAdapter element
            )
        {
            Element = element;
        }

        public bool Exists => Element.IsEmpty;
        public bool Visible => Element.Displayed;
        public bool Enabled => Element.Enabled;
        public int Width => Element.Width;
        public int Height => Element.Height;
        public string Text => Element.Text;
        public void Click()
        {
            Element.Click();
        }

        public void HoverMouse()
        {
            Element.HoverMouse();
        }

        public void SendKeys(string text)
        {
            Element.SendKeys(text);
        }

        public string GetAttribute(string name)
        {
            return Element.GetAttribute(name);
        }

        public bool HasAttribute(string name)
        {
            return !string.IsNullOrEmpty(GetAttribute(name));
        }
    }
}