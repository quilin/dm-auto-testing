using DmAutoTesting.Browsers;

namespace DmAutoTesting.Elements.BasicComponents.TextInput
{
    public interface ITextInputElement : IElement
    {
        bool HasValidationErrors { get; }
        bool IsReadOnly { get; }
        string Value { get; set; }
        string ValidationErrorMessage { get; }
    }

    public class TextInputElement : Element, ITextInputElement
    {
        public TextInputElement(IElementAdapter elementAdapter, IBrowser browser)
            : base(elementAdapter, browser)
        {
        }

        public bool HasValidationErrors => ElementAdapter.GetAttribute("class").Contains("input-validation-error");

        public bool IsReadOnly => !string.IsNullOrEmpty(ElementAdapter.GetAttribute("readOnly"));

        public string Value
        {
            get
            {
                return ElementAdapter.GetAttribute("value");
            }
            set
            {
                Browser.JavaScriptExecutor.PrepareForAjaxRequests();
                ElementAdapter.Clear();
                ElementAdapter.SendKeys(value);
                Browser.JavaScriptExecutor.WaitForPendingAjaxRequests();
            }
        }

        public string ValidationErrorMessage
        {
            get
            {
                if (!HasValidationErrors)
                {
                    return string.Empty;
                }

                var id = ElementAdapter.GetAttribute("id");
                var searchString = $"span[for='{id}']";
                var elementAdapter = ElementAdapter.Page.ElementLocator.GetByCss(searchString);
                return elementAdapter.InnerText;
            }
        }
    }
}