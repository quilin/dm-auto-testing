using DmAutoTesting.Pages;

namespace DmAutoTesting.Elements
{
    public class EmptyElement : IElementAdapter
    {
        private readonly ElementNotFoundException searchException;

        public EmptyElement(string searchCriterion, string searchValue)
        {
            searchException =
                new ElementNotFoundException(
                    $"Element not found on a page. Search criteria: {searchCriterion}, search value: {searchValue}");
        }

        public EmptyElement(string message)
        {
            searchException = new ElementNotFoundException(message);
        }

        public void Click()
        {
            throw searchException;
        }

        public void HoverMouse()
        {
            throw searchException;
        }

        public void Clear()
        {
            throw searchException;
        }

        public void SendKeys(string text)
        {
            throw searchException;
        }

        public string GetAttribute(string name)
        {
            throw searchException;
        }

        public IElementLocator ElementLocator
        {
            get { throw searchException; }
        }

        public IPageAdapter Page
        {
            get { throw searchException; }
        }

        public bool Displayed
        {
            get { throw searchException; }
        }

        public bool Enabled
        {
            get { throw searchException; }
        }

        public int Height
        {
            get { throw searchException; }
        }

        public int Width
        {
            get { throw searchException; }
        }

        public string TagName
        {
            get { throw searchException; }
        }

        public string InnerText
        {
            get { throw searchException; }
        }

        public bool IsEmpty => true;
    }
}