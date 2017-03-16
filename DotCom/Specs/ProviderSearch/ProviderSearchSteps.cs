using DotCom.Pages;
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
    [Binding]
    public class ProviderSearchSteps
    {

        private IWebDriver driver;
        private HomePage homePage;
        private ProviderSearchPage providerSearchPage;
        private ProviderSearchResultsPage searchResultsPage;

        [Before]
        public void SetupBrowser()
        {
            this.driver = new ChromeDriver();
        }

        [After]
        public void TearDownBrowser()
        {
            if (driver != null)
            {
                driver.Close();
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
            IEnumerable<ProviderSearchBasicResult> expected = table.CreateSet<ProviderSearchBasicResult>();
            IList<ProviderSearchResult> actual = new List<ProviderSearchResult>();
            actual.Add(searchResultsPage.FirstSearchResult);
            AssertMatches(expected, actual);
        }

        [When(@"I search for '(.*)' with this health plan: '(.*)'")]
        [Given(@"I search for '(.*)' with this health plan: '(.*)'")]
        public void ISearchForProviderWithThisHealthPlan(string queryText, string healthPlan)
        {
            if (providerSearchPage == null)
            {
                providerSearchPage = new ProviderSearchPage(driver);
            }
            searchResultsPage = providerSearchPage.ExecuteSearch(queryText, healthPlan);
        }

        [Then(@"I see these results:")]
        public void ISeeTheseResults(Table table)
        {
            IEnumerable<ProviderSearchBasicResult> expectedResults = table.CreateSet<ProviderSearchBasicResult>();
            IList<ProviderSearchResult> actualResults = searchResultsPage.AllSearchResults;
            AssertMatches(expectedResults, actualResults);
        }
        
        [When(@"I select Map on the first result")]
        public void WhenISelectMapOnTheFirstResult()
        {
            ProviderSearchResult firstResult = searchResultsPage.FirstSearchResult;
            firstResult.ClickMap();
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

        private void AssertMatches(IEnumerable<ProviderSearchBasicResult> expectedResults, IList<ProviderSearchResult> actualResults)
        {
            int resultIndex = 0;
            foreach (ProviderSearchBasicResult expectedResult in expectedResults)
            {
                ProviderSearchResult actualResult = actualResults[resultIndex];
                Assert.AreEqual(expectedResult.Name, actualResult.ProviderName);
                Assert.AreEqual(expectedResult.Specialty, actualResult.Specialty);
                Assert.AreEqual(expectedResult.Line1, actualResult.Line1);
                resultIndex++;
            }
        }


    }
}
