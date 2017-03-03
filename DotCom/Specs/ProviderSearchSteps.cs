using DotCom.Pages;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace DotCom.Specs
{
    [Binding]
    public class ProviderSearchSteps
    {
        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            HomePage homePage = new HomePage(new ChromeDriver());
        }
    }
}
