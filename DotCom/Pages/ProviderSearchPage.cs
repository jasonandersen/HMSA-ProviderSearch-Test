using OpenQA.Selenium;
using System.Collections.Generic;
using System;

namespace DotCom.Pages
{
    /// <summary>
    /// Represents the Find a Doctor page.
    /// </summary>
    public class ProviderSearchPage
    {
        private const string url = "https://hmsa.com/search/providers/";

        private IWebDriver driver;
        private PageHelper helper;

        /// <summary>
        /// Constructor. Will load the provider search page only if the page isn't already loading.
        /// </summary>
        /// <param name="driver"></param>
        public ProviderSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            if (driver == null)
            {
                throw new NullReferenceException();
            }
            this.helper = new PageHelper(driver);
            if (!driver.Url.StartsWith(url))
            {
                driver.Navigate().GoToUrl(url);
            }
        }

        /// <summary>
        /// The chosen health plan to search for providers.
        /// </summary>
        public string HealthPlan
        {
            set
            {
                HealthPlanSelectorPage healthPlanSelectorPage = ClickSelectHealthPlan();
                healthPlanSelectorPage.HealthPlan = value;
                healthPlanSelectorPage.ClickSaveChanges();
            }
        }

        private HealthPlanSelectorPage ClickSelectHealthPlan()
        {
            helper.ClickElement(By.CssSelector("button[data-target='#plan-picker-modal']"));
            return new HealthPlanSelectorPage(driver);
        }

        public ProviderSearchResultsPage ClickSubmitSearch()
        {
            helper.ClickElement(By.Id("search-button"));
            return new ProviderSearchResultsPage(driver);
        }

        public string SearchText {
            set
            {
                helper.SetElementValue(By.Id("query"), value);
            }
        }

        public ProviderSearchResultsPage ExecuteSearch(string queryText, string healthPlan = null)
        {
            this.SearchText = queryText;
            if (healthPlan != null)
            {
                this.HealthPlan = healthPlan;
            }
            return ClickSubmitSearch();
        }
    }
}
