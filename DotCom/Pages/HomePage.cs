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
        private const string url = "http://hmsa.com";

        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Find a Doctor")]
        private IWebElement searchLink;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            if (driver == null)
            {
                throw new ArgumentNullException();
            }
            string currentUrl = driver.Url;
            if (currentUrl != url)
            {
                driver.Navigate().GoToUrl(url);
            }
            PageFactory.InitElements(driver, this);
        }
        
        public ProviderSearchPage ClickFindADoctor()
        {
            searchLink.Click();
            return new ProviderSearchPage(driver);
        }
    }
}
