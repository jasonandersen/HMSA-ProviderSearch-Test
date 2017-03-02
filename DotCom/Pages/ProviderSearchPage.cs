using OpenQA.Selenium;
using System.Collections.Generic;
using System;

namespace DotCom.Pages
{
    public class ProviderSearchPage
    {
        private const string url = "https://hmsa.com/search/providers/";

        private IWebDriver driver;
        private PageHelper helper;

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

        internal ProviderSearchResultsPage ClickSubmitSearch()
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
