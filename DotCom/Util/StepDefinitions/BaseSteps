using OpenQA.Selenium;
using PegaSmokeTests.Util.Credentials;
using PegaSmokeTests.Util.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PegaSmokeTests.Specs.StepDefinitions
{
    /// <summary>
    /// Base class that step definition classes should inherit from. This class provides all
    /// interactions with the ScenarioContext so the step definition classes don't have to 
    /// deal with it. This allows objects to be freely exchanged between step definition classes.
    /// </summary>
    public abstract class BaseSteps : Steps
    {
        /// <summary>
        /// Key used to store and retrieve browser timeout in milliseconds from the scenario context
        /// </summary>
        public const string KeyBrowserTimeoutMilliseconds = "key.browser.timeout.milliseconds";
        
        /// <summary>
        /// The instance of the browser the tests interact with.
        /// </summary>
        protected Browser Browser
        {
            get
            {
                // It's possible that the browser hasn't been created yet and stored into the ScenarioContext.
                // In case it hasn't been created, we will lazy construct the browser from the specified web
                // driver and specified host already in the ScenarioContext.
                try
                {
                    return GetFromContext<Browser>();
                }
                catch (KeyNotFoundException)
                {
                    // lazy load the browser the first time if not available
                    Host host = GetFromContext<Host>();
                    IWebDriver driver = GetFromContext<IWebDriver>();
                    int defaultTimeout;
                    ScenarioContext.TryGetValue(KeyBrowserTimeoutMilliseconds, out defaultTimeout);
                    Browser browser = new Browser(driver, host, defaultTimeout);
                    Browser = browser;
                    return browser;
                }
            }
            set
            {
                SetInContext<Browser>(value);
            }
        }

        /// <summary>
        /// Credentials store to retrieve user authentication credentials from.
        /// </summary>
        protected ICredentialsStore CredentialsStore
        {
            get
            {
                return GetFromContext<ICredentialsStore>();
            }
            set
            {
                SetInContext<ICredentialsStore>(value);
            }
        }
        
        /// <summary>
        /// Adds an object to the scenario context. This object can then be accessed by any scenario steps.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        protected void SetInContext<T>(T obj)
        {
            ScenarioContext.Set<T>(obj);
        }

        /// <summary>
        /// Retrieve an object from the scenario context based on type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetFromContext<T>()
        {
            return ScenarioContext.Get<T>();
        }
    }
}
