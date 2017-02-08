using DmAutoTesting.Browsers;
using DmAutoTesting.Elements.BasicComponents;
using DmAutoTesting.Elements.BasicComponents.CheckBox;

namespace DmAutoTesting.Elements
{
    public interface IElementFactory
    {
        IElementAdapter ElementAdapter { get; }
        IBrowser Browser { get; }
        IElement AsPageElement();
        ICheckboxElement AsCheckBox();
    }
}