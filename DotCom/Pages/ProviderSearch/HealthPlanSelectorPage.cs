using DotCom.Pages.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace DotCom.Pages.ProviderSearch
{
    /// <summary>
    /// Wraps the health plan selector component to allow a user to choose health plans as a search criteria.
    /// </summary>
    public class HealthPlanSelectorPage
    {
        //The browser to interact with
        private IWebDriver driver;
        
        private PageHelper helper;
        
        /// <summary>
        /// Constructor. The health plan selector modal must already be displayed prior to calling
        /// this constructor. Will not load any page. 
        /// </summary>
        /// <param name="driver">The browser to interact with</param>
        public HealthPlanSelectorPage(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new PageHelper(driver);
        }

        /// <summary>
        /// The selected health plan to search against.
        /// </summary>
        public string HealthPlan
        {
            set
            {
                ICollection<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox'"));
                foreach (IWebElement checkbox in checkboxes)
                {
                    string checkBoxValue = checkbox.GetAttribute("value");
                    if (checkBoxValue == value)
                    {
                        helper.ToggleCheckBox(checkbox, true);
                    }
                    else
                    {
                        helper.ToggleCheckBox(checkbox, false);
                    }
                }
            }
        }

        /// <summary>
        /// Send a click to the save changes button.
        /// </summary>
        public void ClickSaveChanges()
        {
            helper.ClickElement(By.LinkText("Save Changes"));
        }


    }
}