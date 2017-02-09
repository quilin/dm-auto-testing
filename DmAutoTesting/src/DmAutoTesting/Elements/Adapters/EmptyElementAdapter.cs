using DmAutoTesting.Elements.Searchers;
using OpenQA.Selenium;

namespace DmAutoTesting.Elements.Adapters
{
    public class EmptyElementAdapter : IElementAdapter
    {
        private readonly ElementNotFoundException elementNotFoundException;

        public EmptyElementAdapter(By searchCriteria)
        {
            elementNotFoundException = new ElementNotFoundException(searchCriteria);
        }

        public IElementLocator ElementLocator
        {
            get { throw elementNotFoundException.Append("tried to get inner element"); }
        }

        public bool IsEmpty => true;

        public bool Displayed
        {
            get { throw elementNotFoundException.Append("tried to know if it is displayed"); }
        }

        public bool Enabled
        {
            get { throw elementNotFoundException.Append("tried to know if it is enabled"); }
        }
        public string TagName
        {
            get { throw elementNotFoundException.Append("tried to get its tag name"); }
        }
        public int Height
        {
            get { throw elementNotFoundException.Append("tried to get its height"); }
        }
        public int Width
        {
            get { throw elementNotFoundException.Append("tried to get its width"); }
        }
        public string Text
        {
            get { throw elementNotFoundException.Append("tried to get its text"); }
        }
        public void Click()
        {
            throw elementNotFoundException.Append("tried to click it");
        }

        public void HoverMouse()
        {
            throw elementNotFoundException.Append("tried to hover mouse over it");
        }

        public void Clear()
        {
            throw elementNotFoundException.Append("tried to clear it");
        }

        public void SendKeys(string text)
        {
            throw elementNotFoundException.Append($"tried to send keys {text}");
        }

        public string GetAttribute(string name)
        {
            throw elementNotFoundException.Append($"tried to get attribute {name}");
        }
    }
}