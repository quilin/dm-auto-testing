using DmAutoTesting.Elements.Adapters;

namespace DmAutoTesting.Elements
{
    public class Element : BaseElement, IElement
    {
        public Element(IElementAdapter element) : base(element)
        {
        }
    }
}