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
        /// Phone number
        /// </summary>
        public string Phone
        {
            get
            {
                string phoneText = helper.GetElementText(By.CssSelector("div.result-phone"));
                string[] lines = phoneText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                return lines[1];
            }

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
        /// Location city
        /// </summary>
        public string City
        {
            get
            {
                //on the second line of the address, the city state and zip are all smashed together so we 
                //split the line apart based on where the commas are
                string line2 = GetAddressLines()[2];
                string[] tokens = line2.Split(new char[] { ',' });
                return tokens[0];
            }

        }

        /// <summary>
        /// Location state
        /// </summary>
        public string State
        {
            get
            {
                //on the second line of the address, the city state and zip are all smashed together so we 
                //split the line apart based on where the commas and whitespace are
                string line2 = GetAddressLines()[2];
                string[] tokens = line2.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                return tokens[1];
            }

        }

        /// <summary>
        /// Location zip
        /// </summary>
        public string Zip
        {
            get
            {
                //on the second line of the address, the city state and zip are all smashed together so we 
                //split the line apart based on where the commas and whitespace are
                string line2 = GetAddressLines()[2];
                string[] tokens = line2.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return tokens[2];
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
        public LocationMapPage ClickMap()
        {
            helper.ClickElement(By.CssSelector("div.result-address a"));
            return new LocationMapPage();
        }

        private string[] GetAddressLines()
        {
            string addressText = helper.GetElementText(By.CssSelector("div.result-address"));
            return addressText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        
    }
}