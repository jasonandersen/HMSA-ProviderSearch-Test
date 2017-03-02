using OpenQA.Selenium;
using System.Collections.Generic;

namespace DotCom.Pages
{
    public class HealthPlanSelectorPage
    {
        private IWebDriver driver;
        private PageHelper helper;

        public HealthPlanSelectorPage(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new PageHelper(driver);
        }

        public string HealthPlan
        {
            set
            {
                IWebElement planTypesDiv = driver.FindElement(By.Id("plan-types"));
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

        public void ClickSaveChanges()
        {
            helper.ClickElement(By.LinkText("Save Changes"));
        }


    }
}