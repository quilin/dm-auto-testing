using DmAutoTesting.Elements;
using DmAutoTesting.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutoTesting.Elements
{
    public class SeleniumPageElement : IElementAdapter
    {
        private readonly IWebElement element;
        private readonly IWebDriver webDriver;

        public SeleniumPageElement(
            IWebElement element,
            IWebDriver webDriver
            )
        {
            this.element = element;
            this.webDriver = webDriver;
        }

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

        public IElementLocator ElementLocator => new SeleniumElementLocator(element, webDriver);

        public IPageAdapter Page => new SeleniumPage(webDriver);

        public bool Displayed => element.Displayed;
        public bool Enabled => element.Enabled;
        public int Height => element.Size.Height;
        public int Width => element.Size.Width;
        public string TagName => element.TagName;
        public string InnerText => element.Text;
        public bool IsEmpty => false;
    }
}