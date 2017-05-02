using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using PegaSmokeTests.Util.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DotCom.Specs.StepDefinitions
{

    /// <summary>
    /// The step definitions to set up the browser for testing.
    /// </summary>
    [Binding]
    public class BrowserSetupSteps : BaseSteps
    {

        [Given(@"the environment host is '(.*)'")]
        public void TheEnvironmentHostIs(string environmentHost)
        {
            SetInContext(new Host(environmentHost));
        }

        [Given(@"the browser is Internet Explorer")]
        public void TheBrowserIsInternetExplorer()
        {
            SetInContext<IWebDriver>(new InternetExplorerDriver());
        }

        [Given(@"the browser is Firefox")]
        public void TheBrowserIsFirefox()
        {
            SetInContext<IWebDriver>(new FirefoxDriver());
        }

        [Given(@"the page timeout is (.*) seconds")]
        public void ThePageTimeoutIsSeconds(int browserTimeoutSeconds)
        {
            ScenarioContext.Add(BaseSteps.KeyBrowserTimeoutMilliseconds, browserTimeoutSeconds * 1000);
        }
        
    }
}
