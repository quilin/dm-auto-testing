using DmAutoTesting.Elements.Searchers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DmAutoTesting.Elements.Adapters
{
    public class SeleniumElementAdapter : IElementAdapter
    {
        private readonly IWebElement element;
        private readonly IWebDriver webDriver;

        public SeleniumElementAdapter(
            IWebElement element,
            IWebDriver webDriver
            )
        {
            this.element = element;
            this.webDriver = webDriver;
        }

        public IElementLocator ElementLocator => new SeleniumElementLocator(element, webDriver);

        public bool IsEmpty => false;
        public bool Displayed => element.Displayed;
        public bool Enabled => element.Enabled;
        public string TagName => element.TagName;
        public int Height => element.Size.Height;
        public int Width => element.Size.Width;
        public string Text => element.Text;
        public void Click()
        {
            element.Click();
        }

        public void HoverMouse()
        {
            var actions = new Actions(webDriver);
            actions.MoveToElement(element).Perform();
        }

        public void Clear()
        {
            element.Clear();
        }

        public void SendKeys(string text)
        {
            element.Click();
            element.SendKeys(text);
        }

        public string GetAttribute(string name)
        {
            return element.GetAttribute(name);
        }
    }
}