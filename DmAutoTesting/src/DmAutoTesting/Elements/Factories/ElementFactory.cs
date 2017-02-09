using DmAutoTesting.Elements.Adapters;

namespace DmAutoTesting.Elements.Factories
{
    public class ElementFactory : IElementFactory
    {
        private readonly IElementAdapter element;

        public ElementFactory(
            IElementAdapter element
        )
        {
            this.element = element;
        }

        public IElement AsElement()
        {
            return new Element(element);
        }
    }
}