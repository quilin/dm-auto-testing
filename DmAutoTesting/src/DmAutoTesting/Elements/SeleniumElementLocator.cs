using System.Linq;
using DmAutoTesting.Elements;
using OpenQA.Selenium;

namespace AutoTesting.Elements
{
    public class SeleniumElementLocator : IElementLocator
    {
        private readonly ISearchContext searchContext;
        private readonly IWebDriver webDriver;

        public SeleniumElementLocator(
            ISearchContext searchContext,
            IWebDriver webDriver
            )
        {
            this.searchContext = searchContext;
            this.webDriver = webDriver;
        }

        public IElementAdapter FindById(string id)
        {
            return FindElement(By.Id(id));
        }

        public IElementAdapter[] FindAllByName(string name)
        {
            return FindElements(By.Name(name));
        }

        public IElementAdapter[] FindAllByCss(string css)
        {
            return FindElements(By.CssSelector(css));
        }

        public IElementAdapter[] FindAllByXPath(string xpath)
        {
            return FindElements(By.XPath(xpath));
        }

        public IElementAdapter FindByName(string name)
        {
            return FindElement(By.Name(name));
        }

        public IElementAdapter FindByCss(string css)
        {
            return FindElement(By.CssSelector(css));
        }

        public IElementAdapter FindByXPath(string xpath)
        {
            return FindElement(By.XPath(xpath));
        }

        public IElementAdapter GetById(string id)
        {
            return GetElement(By.Id(id));
        }

        public IElementAdapter GetByName(string name)
        {
            return GetElement(By.Name(name));
        }

        public IElementAdapter GetByCss(string css)
        {
            return GetElement(By.CssSelector(css));
        }

        public IElementAdapter GetByXPath(string xpath)
        {
            return GetElement(By.XPath(xpath));
        }

        private IElementAdapter FindElement(By searchCriteria)
        {
            var element = searchContext.FindElements(searchCriteria).FirstOrDefault();
            return element == null ? null : new SeleniumPageElement(element, webDriver);
        }

        private IElementAdapter[] FindElements(By searchCriteria)
        {
            var elements = searchContext.FindElements(searchCriteria);
            return elements.Select(e => new SeleniumPageElement(e, webDriver)).ToArray<IElementAdapter>();
        }

        private IElementAdapter GetElement(By searchCriteria)
        {
            var element = FindElement(searchCriteria);
            if (element == null)
            {
                throw new ElementNotFoundException($"Could not find an element by criteria \"{searchCriteria}\"");
            }
            return element;
        }
    }
}