
using OpenQA.Selenium;
using System;

namespace DotCom.Pages
{
    class PageHelper
    {
        private ISearchContext searchContext;

        public PageHelper(ISearchContext searchContext)
        {
            this.searchContext = searchContext;
            if (searchContext == null)
            {
                throw new NullReferenceException();
            }
        }

        public bool ElementExists(By by)
        {
            try
            {
                IWebElement element = searchContext.FindElement(by);
                return element != null;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public string GetElementText(By by)
        {
            IWebElement element = searchContext.FindElement(by);
            return element.Text;
        }

        public void ToggleCheckBox(IWebElement checkbox, bool selected)
        {
            if (checkbox.Selected && !selected)
            {
                checkbox.Click();
            }
            else if (!checkbox.Selected && selected)
            {
                checkbox.Click();
            }
        }

        public void ClickElement(By by)
        {
            IWebElement element = searchContext.FindElement(by);
            element.Click();
        }

        public string GetElementValue(By by)
        {
            IWebElement element = searchContext.FindElement(by);
            return element.GetAttribute("value");
        }
        
        public void SetElementValue(By by, string newValue)
        {
            IWebElement element = searchContext.FindElement(by);
            element.SendKeys(newValue);
        }
    }
}
