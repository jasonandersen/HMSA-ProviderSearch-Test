using DotCom.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        public void TestProviderSearchQueryDisplaysOnResultsPage()
        {
            ProviderSearchPage searchPage = new ProviderSearchPage(driver);
            ProviderSearchResultsPage results = searchPage.ExecuteSearch("nephrology", "HMSA Akamai Advantage");
            Assert.AreEqual("nephrology", results.QueryText);
        }

        [Test]
        [Ignore("test is not finished")]
        public void TestProviderSearchPartialWordSpecialtyReturnsResults()
        {
            ProviderSearchPage searchPage = new ProviderSearchPage(driver);
            ProviderSearchResultsPage results = searchPage.ExecuteSearch("nephrolo");
            //Assert.That(results.AreNotEmpty());
        }
        
        //tests:
        // - test that message shows up when no plan is selected
        // - test that health plan shows up correctly
        
    }
}
