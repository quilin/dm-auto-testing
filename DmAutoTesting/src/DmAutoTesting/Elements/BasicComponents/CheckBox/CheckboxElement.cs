using DmAutoTesting.Browsers;

namespace DmAutoTesting.Elements.BasicComponents.CheckBox
{
    public class CheckboxElement : Element, ICheckboxElement
    {
        public CheckboxElement(IElementAdapter elementAdapter, IBrowser browser) : base(elementAdapter, browser)
        {
        }
        
        public bool Checked
        {
            get { return IsChecked(); }
            set
            {
                if (IsChecked() ^ value)
                {
                    Click();
                }
                if (IsChecked() != value)
                {
                    throw new CheckBoxSwitchStateException();
                }
            }
        }

        private bool IsChecked()
        {
            return GetAttribute("checked") == "true";
        }
    }
}