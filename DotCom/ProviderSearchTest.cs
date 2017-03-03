using DotCom.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DotCom
{
    [TestFixture]
    class ProviderSearchTest
    {

        private IWebDriver driver;

        [SetUp]
        public void SetupBrowser()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDownBrowser()
        {
            driver.Close();
        }











        [Test]
        public void TestProviderSearchFromHomePage()
        {
            HomePage homePage = new HomePage(driver);
            ProviderSearchPage searchPage = homePage.ClickFindADoctor();
            ProviderSearchResultsPage resultsPage = searchPage.ExecuteSearch("nephrology", "HMSA Akamai Advantage");
            ProviderSearchResult firstResult = resultsPage.FirstSearchResult;
            Assert.AreEqual("Aaron K Nada MD", firstResult.ProviderName);
        }
        

































        [Test]
        [Ignore("not implemented yet!")]
        public void TestQueryTextDisplaysOnResultsPage()
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("not implemented yet!")]
        public void TestHealthPlanTextDisplaysOnResultsPage()
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("not implemented yet!")]
        public void TestPartialWordSpecialtyReturnsResults()
        {
            //test that 'nephrolo' returns Nephrology specialists
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("not implemented yet!")]
        public void TestNoHealthPlanMessageDisplayed()
        {
            throw new NotImplementedException();
        }

    }
}
