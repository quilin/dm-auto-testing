using DmAutoTesting.Elements;
using DmAutoTesting.Elements.BasicComponents;

namespace DmAutoTesting.Components
{
    public class Component
    {
        private IElement blockElement;
        public IElementGetter Get { get; set; }
        public IElementFinder FindAll { get; set; }

        public bool Visible => blockElement.Visible;

        public virtual void Initialize(IElementFactory elementFactory)
        {
            blockElement = elementFactory.AsPageElement();

            var pageElementAdapter = elementFactory.ElementAdapter;
            var elementSearcher = new ElementSearcher(pageElementAdapter.ElementLocator, elementFactory.Browser);
            Get = elementSearcher;
            FindAll = elementSearcher;
        }
    }
}