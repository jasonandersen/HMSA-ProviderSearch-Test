using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DotCom.Pages.Util
{
    /// <summary>
    /// Utility class to house convenience methods specifically around IWebDriver objects.
    /// </summary>
    public class WebDriverHelper : SearchContextWrapper
    {

        // This subclass of SearchContextWrapper deals specifically with convenience methods that require
        // an IWebDriver instead of an ISearchContext.
        private IWebDriver driver;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="searchContext"></param>
        public WebDriverHelper(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
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
