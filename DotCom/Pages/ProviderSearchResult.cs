using OpenQA.Selenium;
using System;

namespace DotCom.Pages
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

        public string ProviderName
        {
            get
            {
                return helper.GetElementText(By.XPath("//div[@class='h3']"));
            }
                
        }
    }
}