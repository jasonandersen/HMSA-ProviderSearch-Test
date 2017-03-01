using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace DotCom
{
    [TestFixture]
    public class ProviderSearchTest
    {

        private IWebDriver driver;

        [TearDown]
        public void shutdownBrowser()
        {
            //close browser
            //System.Threading.Thread.Sleep(1000);
            driver.Close();
        }

        [Test]
        public void TestProviderSearch()
        {
            //boot up browser
            driver = new ChromeDriver();
            //load home page
            driver.Navigate().GoToUrl("https://hmsa.com/");
            //find anchor for "Find a Doctor"
            IWebElement searchLink = driver.FindElement(By.LinkText("Find a Doctor"));
            //load "Find a Doctor" page
            searchLink.Click();
            //enter "Nephrology" into search results
            IWebElement queryTextBox = driver.FindElement(By.Id("query"));
            queryTextBox.SendKeys("nephrology");
            //choose plan
            IWebElement plansButton = driver.FindElement(By.CssSelector("button[data-target='#plan-picker-modal']"));
            plansButton.Click();
            IWebElement aaCheckbox = driver.FindElement(By.CssSelector("input[value = 'HMSA Akamai Advantage']"));
            aaCheckbox.Click();
            IWebElement planChooserSaveChanges = driver.FindElement(By.LinkText("Save Changes"));
            planChooserSaveChanges.Click();
            //execute search
            IWebElement searchButton = driver.FindElement(By.Id("search-button"));
            searchButton.Click();
            //pause for search results to display
            System.Threading.Thread.Sleep(1000);
            IWebElement firstResult = driver.FindElement(By.CssSelector(".results .result .h3"));
            Assert.AreEqual("Aaron K Nada MD", firstResult.Text);
        }


    }
}