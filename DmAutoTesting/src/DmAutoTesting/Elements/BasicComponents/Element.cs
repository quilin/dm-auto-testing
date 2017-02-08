using DmAutoTesting.Browsers;

namespace DmAutoTesting.Elements.BasicComponents
{
    public class Element : IElement
    {
        protected readonly IElementAdapter ElementAdapter;
        protected readonly IBrowser Browser;
        protected readonly string IdSelector;

        public Element(
            IElementAdapter elementAdapter,
            IBrowser browser,
            string idSelector
            )
        {
            ElementAdapter = elementAdapter;
            Browser = browser;
            IdSelector = idSelector;
        }

        public Element(
            IElementAdapter elementAdapter,
            IBrowser browser)
        {
            ElementAdapter = elementAdapter;
            Browser = browser;
        }

        public virtual void Click()
        {
            Browser.JavaScriptExecutor.PrepareForAjaxRequests();
            ElementAdapter.Click();
            Browser.JavaScriptExecutor.WaitForPendingAjaxRequests();
        }

        public bool Exists => !ElementAdapter.IsEmpty;

        public void HoverMouse()
        {
            ElementAdapter.HoverMouse();
        }

        public void SendKeys(string text)
        {
            ElementAdapter.SendKeys(text);
        }

        public string GetAttribute(string name)
        {
            return ElementAdapter.GetAttribute(name);
        }

        public bool HasAttribute(string name)
        {
            return !string.IsNullOrEmpty(ElementAdapter.GetAttribute(name));
        }

        public string InnerText => ElementAdapter.InnerText;

        public bool Visible => ElementAdapter.Displayed;

        public bool Enabled => ElementAdapter.Enabled;

        public int Height => ElementAdapter.Height;
        public int Width => ElementAdapter.Width;
    }
}