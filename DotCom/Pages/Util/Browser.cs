
using System;
using OpenQA.Selenium;

namespace PegaSmokeTests.Util.Selenium
{
    /// <summary>
    /// Utility class to house convenience methods specifically around IWebDriver objects.
    /// </summary>
    public class Browser : SearchContextWrapper
    {
        // This subclass of SearchContextWrapper deals specifically with convenience methods that require
        // an IWebDriver instead of an ISearchContext.
        private IWebDriver driver;

        // The host helps construct host-specific URLs.
        private Host host;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="searchContext"></param>
        /// <param name="host"></param>
        public Browser(IWebDriver driver, Host host) : base(driver)
        {
            this.driver = driver;
            this.host = host;
        }

        /// <summary>
        /// Navigates to a URL on the specified host based on the path provided. The hostname will be specified
        /// by the host, the path will be specified by the path argument.
        /// </summary>
        /// <param name="path"></param>
        public void NavigateToPath(string path)
        {
            string url = host.ConstructUrl(path);
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Shuts all browser windows opened during the session.
        /// </summary>
        public void Shutdown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Will switch to the most recent page opened.
        /// </summary>
        public void SwitchToMostRecentPage()
        {
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        
    }
}
