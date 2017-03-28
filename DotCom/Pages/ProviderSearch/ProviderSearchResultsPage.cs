using System;
using OpenQA.Selenium;
using DotCom.Pages.Util;
using System.Collections.Generic;

namespace DotCom.Pages.ProviderSearch
{
    /// <summary>
    /// Represents the page displaying search results.
    /// </summary>
    public class ProviderSearchResultsPage
    {
        // The browser to interact with
        private IWebDriver driver;

        private WebDriverHelper helper;

        /// <summary>
        /// Constructor to create the class.
        /// </summary>
        /// <param name="driver">The browser to interact with</param>
        public ProviderSearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new WebDriverHelper(driver);
            
            // Because this page loads the results from an AJAX call, we have to pause while the results
            // finish loading. Once they're loaded, we can then access all the search results.
            PauseForSearchResultsToLoad();
        }

        /// <summary>
        /// Fetch all the search results components. Will return an empty list if no results are found.
        /// </summary>
        public IList<ProviderSearchResult> AllSearchResults
        {
            get
            {
                List<ProviderSearchResult> results = new List<ProviderSearchResult>();
                PauseForSearchResultsToLoad();
                if (AreResultsLoaded())
                {
                    ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='results']/div"));
                    foreach (IWebElement element in elements)
                    {
                        results.Add(new ProviderSearchResult(element));
                    }
                }
                return results;
            }
        }

        /// <summary>
        /// Gets a specified search result based on the index.
        /// </summary>
        /// <param name="resultIndex">zero-based index</param>
        /// <returns>the provider search result from the specified index</returns>
        public ProviderSearchResult GetSearchResult(int resultIndex)
        {
            IList<ProviderSearchResult> results = AllSearchResults;
            return results[resultIndex];
        }

        /// <summary>
        /// Retrieves the first search result found.
        /// </summary>
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

        /// <summary>
        /// The query text used to generate the search results.
        /// </summary>
        public string QueryText
        {
            get
            {
                return helper.GetElementValue(By.Id("query"));
            }
        }

        /// <summary>
        /// The query text used to generate the search results.
        /// </summary>
        public string HealthPlan
        {
            get
            {
                return helper.GetElementText(By.Id("plans"));
            }
        }


        /// <summary>
        ///  The search results page initially loads with a spinner while the results are loaded
        ///  asynchronously. This method will pause until the results have been loaded.
        /// </summary>
        private void PauseForSearchResultsToLoad()
        {
            while (!AreResultsLoaded())
            {
                wait(100);
            }
        }

        /// <summary>
        /// Determines if the search results have been loaded.
        /// </summary>
        /// <returns>true if the results are finished loading</returns>
        private bool AreResultsLoaded()
        {
            return helper.ElementExists(By.XPath("//div[@class='results']/div[1]/div[1]/div[1]/div[@class='h3']"));
        }

        /// <summary>
        /// Returns true if the results come back empty.
        /// </summary>
        /// <returns></returns>
        public bool AreResultsEmpty()
        {
            return helper.ElementExists(By.CssSelector("div.pager p.results-count"));
        }

        /// <summary>
        /// Causes the executing thread to pause for the specified amount of milliseconds.
        /// </summary>
        /// <param name="milliseconds"></param>
        private void wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }

        
    }
}