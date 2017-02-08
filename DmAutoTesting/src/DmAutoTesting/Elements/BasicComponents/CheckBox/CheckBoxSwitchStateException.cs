using System;

namespace DmAutoTesting.Elements.BasicComponents.CheckBox
{
    public class CheckBoxSwitchStateException : Exception
    {
        public CheckBoxSwitchStateException()
            : base("Unable to switch state of check box element")
        {
        }
    }
}