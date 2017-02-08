using System.Linq;
using DmAutoTesting.Components;
using DmAutoTesting.Elements;
using DmAutoTesting.Elements.BasicComponents;
using DmAutoTesting.Elements.BasicComponents.TextInput;

namespace DmAutoTesting.Extensions
{
    public static class ElementFactoryExtensions
    {
        public static ITextInputElement AsTextInput(this IElementFactory elementFactory)
        {
            return new TextInputElement(elementFactory.ElementAdapter, elementFactory.Browser);
        }

        public static IElement[] AsPageElements(this IElementFactory[] elementFactories)
        {
            return elementFactories.Select(x => x.AsPageElement()).ToArray();
        }

        public static T AsComponent<T>(this IElementFactory elementFactory)
            where T : Component, new()
        {
            var block = new T();
            block.Initialize(elementFactory);
            return block;
        }
    }
}