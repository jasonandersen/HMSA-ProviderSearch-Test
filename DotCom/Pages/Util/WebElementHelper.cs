using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DotCom.Pages.Util
{
    /// <summary>
    /// Utility class to house convenience methods specifically around IWebElement objects.
    /// </summary>
    public class WebElementHelper : SearchContextWrapper
    {
        
        // This subclass of PageHelper deals specifically with convenience methods that require
        // an IWebElement instead of an ISearchContext.
        private IWebElement element;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="element"></param>
        public WebElementHelper(IWebElement element) : base(element)
        {
            this.element = element;
        }

        /// <summary>
        /// Retrieves the original driver from the WebElement.
        /// </summary>
        public IWebDriver Driver {
            get
            {
                RemoteWebElement re = (RemoteWebElement)element;
                return re.WrappedDriver;
            }
        }
    }
}
