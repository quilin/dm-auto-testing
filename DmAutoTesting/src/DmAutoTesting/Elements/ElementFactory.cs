using DmAutoTesting.Browsers;
using DmAutoTesting.Elements.BasicComponents;
using DmAutoTesting.Elements.BasicComponents.CheckBox;

namespace DmAutoTesting.Elements
{
    public class ElementFactory : IElementFactory
    {
        private readonly string idSelector;
        public IElementAdapter ElementAdapter { get; }
        public IBrowser Browser { get; }

        public ElementFactory(
            IElementAdapter elementAdapter,
            IBrowser browser,
            string idSelector)
        {
            this.idSelector = idSelector;
            ElementAdapter = elementAdapter;
            Browser = browser;
        }

        public IElement AsPageElement()
        {
            return new Element(ElementAdapter, Browser, idSelector);
        }

        public ICheckboxElement AsCheckBox()
        {
            return new CheckboxElement(ElementAdapter, Browser);
        }
    }
}