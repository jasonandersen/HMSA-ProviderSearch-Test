using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DotCom.Pages.ProviderSearch;

namespace DotCom.Pages
{
    /// <summary>
    /// Represents the home page for HMSA.com.
    /// </summary>
    public class HomePage
    {
        // URL to navigate to for the home page
        private const string url = "http://hmsa.com";

        // Browser to interact with
        private IWebDriver driver;

        // The 'Find a Doctor' provider search link
        [FindsBy(How = How.LinkText, Using = "Find a Doctor")]
        private IWebElement searchLink;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The browser to interact with</param>
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            if (driver == null)
            {
                throw new ArgumentNullException();
            }
            // If the home page isn't currently loaded into the browser, navigate to it
            string currentUrl = driver.Url;
            if (currentUrl != url)
            {
                driver.Navigate().GoToUrl(url);
            }

            PageFactory.InitElements(driver, this);
        }
        
        /// <summary>
        /// Click the link to go to the Provider Search Page
        /// </summary>
        /// <returns></returns>
        public ProviderSearchPage ClickFindADoctor()
        {
            searchLink.Click();
            return new ProviderSearchPage(driver);
        }
    }
}
