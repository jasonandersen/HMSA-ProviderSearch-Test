using System;
using OpenQA.Selenium;

namespace DotCom.Pages
{
    public class HomePage
    {
        private const string url = "http://hmsa.com";
        private IWebDriver driver;
        
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
        }
        
        public ProviderSearchPage ClickFindADoctor()
        {
            IWebElement searchLink = driver.FindElement(By.LinkText("Find a Doctor"));
            searchLink.Click();
            return new ProviderSearchPage(driver);
        }
    }
}
