using DotCom.Pages.Util;
using OpenQA.Selenium;
using System;

namespace DotCom.Pages.ProviderSearch
{
    /// <summary>
    /// A single provider search result pane representing a single provider/location.
    /// </summary>
    public class ProviderSearchResult
    {
        private IWebElement element;
        private PageHelper helper;

        public ProviderSearchResult(IWebElement element)
        {
            this.element = element;
            if (element == null)
            {
                throw new NullReferenceException();
            }
            this.helper = new PageHelper(element);
        }

        /// <summary>
        /// Address line 1
        /// </summary>
        public string Line1
        {
            get
            {
                // Address will comes across as a big blob of text. We have to parse it manually since
                // it's not broken down by its elements.
                return GetAddressLines()[1];
            }

        }

        /// <summary>
        /// Name of the provider
        /// </summary>
        public string ProviderName
        {
            get
            {
                return helper.GetElementText(By.XPath("//div[@class='h3']"));
            }
                
        }

        /// <summary>
        /// Name of the provider's specialty
        /// </summary>
        public string Specialty
        {
            get
            {
                return helper.GetElementText(By.CssSelector("div.result-label.reset"));
            }
        }

        /// <summary>
        /// Clicks the map link for the provider location
        /// </summary>
        public void ClickMap()
        {
            helper.ClickElement(By.CssSelector("div.result-address a"));
        }

        private string[] GetAddressLines()
        {
            string addressText = helper.GetElementText(By.CssSelector("div.result-address"));
            return addressText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        
    }
}