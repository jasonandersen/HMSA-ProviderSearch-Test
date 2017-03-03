using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace DotCom
{
    [TestFixture]
    public class ProviderSearchProceduralTest
    {

        private IWebDriver driver;

        [SetUp]
        public void SetUpBrowser()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void shutdownBrowser()
        {
            driver.Close();
        }

        [Test]
        public void TestPS()
        {
            driver.Navigate().GoToUrl("https://hmsa.com/");
            IWebElement searchLink = driver.FindElement(By.LinkText("Find a Doctor"));
            searchLink.Click();
            IWebElement queryTextBox = driver.FindElement(By.Id("query"));
            queryTextBox.SendKeys("nephrology");
            IWebElement plansButton = driver.FindElement(By.CssSelector("button[data-target='#plan-picker-modal']"));
            plansButton.Click();
            IWebElement aaCheckbox = driver.FindElement(By.CssSelector("input[value = 'HMSA Akamai Advantage']"));
            aaCheckbox.Click();
            IWebElement planChooserSaveChanges = driver.FindElement(By.LinkText("Save Changes"));
            planChooserSaveChanges.Click();
            IWebElement searchButton = driver.FindElement(By.Id("search-button"));
            searchButton.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement firstResult = driver.FindElement(By.XPath("//div[@class='results']/div[1]/div[1]/div[1]/div[@class='h3']"));
            Assert.AreEqual("Aaron K Nada MD", firstResult.Text);
        }
        
    }
}