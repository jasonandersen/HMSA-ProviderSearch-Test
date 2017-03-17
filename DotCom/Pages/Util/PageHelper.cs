
using OpenQA.Selenium;
using System;

namespace DotCom.Pages.Util
{
    /// <summary>
    /// Utility class to house common methods around interacting with IWebElement objects.
    /// </summary>
    class PageHelper
    {
        // Search context to find page elements. Can be either an IWebDriver (the browser) or
        // an IWebElement (an HTML element on the page). If this is an IWebElement, then it will 
        // only search for child elements of the specified element.
        private ISearchContext searchContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="searchContext">WebDriver or WebElement to search for elements</param>
        public PageHelper(ISearchContext searchContext)
        {
            this.searchContext = searchContext;
            if (searchContext == null)
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Determines if an element exists in the current search context.
        /// </summary>
        /// <param name="by">search criteria</param>
        /// <returns>true if the element exists, false if cannot be found - will not throw an exception</returns>
        public bool ElementExists(By by)
        {
            try
            {
                IWebElement element = searchContext.FindElement(by);
                return element != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieve the text of the element.
        /// </summary>
        /// <param name="by">search criteria</param>
        /// <returns>Text of the element.</returns>
        /// <exception cref="NoSuchElementException">when element not found</exception>
        public string GetElementText(By by)
        {
            IWebElement element = searchContext.FindElement(by);
            return element.Text;
        }

        /// <summary>
        /// Ensures selected value of a checkbox matches the selected param.
        /// </summary>
        /// <param name="checkbox">checkbox to operate against</param>
        /// <param name="selected">If true, ensure checkbox is selected. If false, ensure checkbox is not selected.</param>
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

        /// <summary>
        /// Clicks the first element found.
        /// </summary>
        /// <param name="by">search criteria</param>
        /// <exception cref="NoSuchElementException">when element not found</exception>
        public void ClickElement(By by)
        {
            IWebElement element = searchContext.FindElement(by);
            element.Click();
        }

        /// <summary>
        /// Retrieves the value of the first element found.
        /// </summary>
        /// <param name="by">search criteria</param>
        /// <returns>the value of the first element found.</returns>
        /// <exception cref="NoSuchElementException">when element not found</exception>
        public string GetElementValue(By by)
        {
            IWebElement element = searchContext.FindElement(by);
            return element.GetAttribute("value");
        }
        
        /// <summary>
        /// Sets the value of the first element found.
        /// </summary>
        /// <param name="by">search criteria</param>
        /// <param name="newValue">value of the element to set</param>
        /// <exception cref="NoSuchElementException">when element not found</exception>
        public void SetElementValue(By by, string newValue)
        {
            IWebElement element = searchContext.FindElement(by);
            element.SendKeys(newValue);
        }

        /// <summary>
        /// Will switch
        /// </summary>
        /// <exception cref="InvalidOperationException">thrown when this page helper wraps an element, not a driver</exception>
        public void SwitchToMostRecentPage()
        {
            IWebDriver driver;
            if (searchContext is IWebDriver)
            {
                driver = (IWebDriver)searchContext;
            } else 
            {
                // This doesn't make sense to switch when the root search context is an 
                // element, not a web driver.
                throw new InvalidOperationException();
            }
            throw new NotImplementedException();
        }
    }
}
