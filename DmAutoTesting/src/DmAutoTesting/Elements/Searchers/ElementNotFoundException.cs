using System;
using OpenQA.Selenium;

namespace DmAutoTesting.Elements.Searchers
{
    internal class ElementNotFoundException : Exception
    {
        private readonly By searchCriteria;

        public ElementNotFoundException(By searchCriteria) : base($"Could not find element by criteria {searchCriteria}")
        {
            this.searchCriteria = searchCriteria;
        }

        public ElementNotFoundException(By searchCriteria, string additionalMessage) : base($"Could not find element by criteria {searchCriteria}, but {additionalMessage}")
        {
        }

        public ElementNotFoundException Append(string value)
        {
            return new ElementNotFoundException(searchCriteria, value);
        }
    }
}