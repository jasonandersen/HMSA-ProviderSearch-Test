using System;
using OpenQA.Selenium;

namespace DotCom.Pages
{
    public class ProviderSearchResultsPage
    {
        private IWebDriver driver;
        private PageHelper helper;

        public ProviderSearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new PageHelper(driver);
            pauseForSearchResults();
        }

        public ProviderSearchResult FirstSearchResult
        {
            get
            {
                if (AreResultsLoaded())
                {
                    IWebElement element = driver.FindElement(By.XPath("//div[@class='results']/div[1]"));
                    return new ProviderSearchResult(element);
                }
                return null;
            }
        }

        public string QueryText
        {
            get
            {
                return helper.GetElementValue(By.Id("query"));
            }
        }

        // The search results page initially loads with a spinner while the results are loaded
        // asynchronously. This method will pause until the results have been loaded.
        private void pauseForSearchResults()
        {
            while (!AreResultsLoaded())
            {
                wait(100);
            }
        }

        private bool AreResultsLoaded()
        {
            return helper.ElementExists(By.XPath("//div[@class='results']/div[1]/div[1]/div[1]/div[@class='h3']"));
        }

        public bool AreResultsEmpty()
        {
            return helper.ElementExists(By.CssSelector("div.pager p.results-count"));
        }

        private void wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}