﻿using DotCom.Pages;
using DotCom.Pages.ProviderSearch;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DotCom.Specs.ProviderSearch
{
    /// <summary>
    /// This class houses the glue code for the steps in the BDD scenarios for provider searching.
    /// </summary>
    [Binding]
    public class ProviderSearchSteps
    {

        // The browser to interact with
        private IWebDriver driver;

        // The home page loaded in the browser
        private HomePage homePage;

        // The provider search page
        private ProviderSearchPage providerSearchPage;

        // The provider search results page that returned from a search execution
        private ProviderSearchResultsPage searchResultsPage;

        // The Google Maps location page returned from a map link
        private LocationMapPage locationMapPage;

        /// <summary>
        /// This method will execute before every test scenario that SpecFlow runs.
        /// </summary>
        [Before]
        public void SetupBrowser()
        {
            // Default the browser to a new instance of Chrome.
            this.driver = new ChromeDriver();
        }

        /// <summary>
        /// This method will run after the completion of each test scenario. It will ensure any 
        /// open browsers will be shut down.
        /// </summary>
        [After]
        public void TearDownBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }


        [Given(@"I have this provider:")]
        public void IHaveThisProvider(Table table)
        {
            // precondition: normally we would ensure we insert this data into our test environment
        }

        [Given(@"the provider '(.*)' accepts '(.*)'")]
        public void TheProviderAcceptsPlan(string p0, string p1)
        {
            // precondition: normally we would ensure we insert this data into our test environment
        }

        [Given(@"the provider '(.*)' has the following locations:")]
        public void TheProviderHasTheFollowingLocations(string providerName, Table table)
        {
            // precondition: normally we would ensure we insert this data into our test environment
        }
        
        [Given(@"I navigate to the home page")]
        [When(@"I navigate to the home page")]
        public void INavigateToTheHomePage()
        {
            homePage = new HomePage(driver);
        }

        [Given(@"I select Find a Doctor")]
        public void ISelectFindADoctor()
        {
            providerSearchPage = homePage.ClickFindADoctor();
        }

        [Given(@"the first result is:")]
        public void GivenTheFirstResultIs(Table table)
        {
            // Grab the expected results from the table within the scenario
            IEnumerable<ProviderSearchBasicResult> expected = table.CreateSet<ProviderSearchBasicResult>();

            // Grab the actual results from the provider search results page
            IList<ProviderSearchResult> actual = new List<ProviderSearchResult>();
            actual.Add(searchResultsPage.FirstSearchResult);
            
            AssertMatches(expected, actual);
        }

        [When(@"I search for '(.*)' with this health plan: '(.*)'")]
        [Given(@"I search for '(.*)' with this health plan: '(.*)'")]
        public void ISearchForProviderWithThisHealthPlan(string queryText, string healthPlan)
        {
            // Make sure the provider search page is loaded in the browser
            if (providerSearchPage == null)
            {
                providerSearchPage = new ProviderSearchPage(driver);
            }
            searchResultsPage = providerSearchPage.ExecuteSearch(queryText, healthPlan);
        }

        [Then(@"I see these results:")]
        public void ISeeTheseResults(Table table)
        {
            // Grab the expected results from the table within the scenario
            IEnumerable<ProviderSearchBasicResult> expectedResults = table.CreateSet<ProviderSearchBasicResult>();

            // Grab the actual results from the provider search results page
            IList<ProviderSearchResult> actualResults = searchResultsPage.AllSearchResults;

            AssertMatches(expectedResults, actualResults);
        }
        
        [When(@"I select Map on the first result")]
        public void WhenISelectMapOnTheFirstResult()
        {
            ProviderSearchResult firstResult = searchResultsPage.FirstSearchResult;
            locationMapPage = firstResult.ClickMap();
        }

        [Then(@"I see a Google Maps page in a separate window for this address:")]
        public void ThenISeeAGoogleMapsPageInASeparateWindowForThisAddress(Table table)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I see my search query is '(.*)'")]
        public void ISeeMyQueryIs(string searchQuery)
        {
            Assert.AreEqual(searchQuery, searchResultsPage.QueryText);
        }

        [Then(@"I see my plan is '(.*)'")]
        public void ISeeMyPlanIs(string searchPlan)
        {
            Assert.AreEqual(searchPlan, searchResultsPage.HealthPlan);
        }

        /// <summary>
        /// Compares a list of expected provider search results to a list of actual provider search results. If no match
        /// is found, than an assertion exception will be thrown.
        /// </summary>
        /// <param name="expectedResults"></param>
        /// <param name="actualResults"></param>
        private void AssertMatches(IEnumerable<ProviderSearchBasicResult> expectedResults, IList<ProviderSearchResult> actualResults)
        {
            // Iterate through the expected results and ensure that each actual result at the same index matches
            // the expected results
            int resultIndex = 0;
            foreach (ProviderSearchBasicResult expectedResult in expectedResults)
            {
                ProviderSearchResult actualResult = actualResults[resultIndex];
                Assert.AreEqual(expectedResult.Name, actualResult.ProviderName);
                Assert.AreEqual(expectedResult.Specialty, actualResult.Specialty);
                Assert.AreEqual(expectedResult.Line1, actualResult.Line1);
                Assert.AreEqual(expectedResult.City, actualResult.City);
                Assert.AreEqual(expectedResult.State, actualResult.State);
                Assert.AreEqual(expectedResult.Zip, actualResult.Zip);
                Assert.AreEqual(expectedResult.Phone, actualResult.Phone);
                resultIndex++;
            }
        }


    }
}
