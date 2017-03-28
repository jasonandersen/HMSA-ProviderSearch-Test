using DotCom.Pages.Util;
using OpenQA.Selenium;

namespace DotCom.Pages.ProviderSearch
{
    public class LocationMapPage
    {
        private IWebDriver driver;

        private WebDriverHelper helper;

        public LocationMapPage(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new WebDriverHelper(driver);
            helper.WaitForElement(By.CssSelector("div.section-hero-header-description div.section-hero-header-title h1"));
        }

        public string Address
        {
            get
            {
                return helper.GetElementValue(By.CssSelector("div.section-hero-header-description div.section-hero-header-title h1"));
            }
        }
    }
}