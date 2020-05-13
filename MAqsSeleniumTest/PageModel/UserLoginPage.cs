using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for UserLoginPage
    /// </summary>
    public class UserLoginPage : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "Account/SignIn";

        /// <summary>
        /// Selenium test object
        /// </summary>
        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginPage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public UserLoginPage(SeleniumTestObject testObject) : base(testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets the email field element
        /// </summary>>
        private LazyElement EmailField
        {
            get
            {
                return new LazyElement(this.testObject,
          By.CssSelector("#Email"), "User email fileld");
            }
        }

        /// <summary>
        /// Gets the password field element
        /// </summary>
        private LazyElement PassowrdField
        {
            get
            {
                return new LazyElement(this.testObject,
          By.CssSelector("#Password"), "User password fileld");
            }
        }

        /// <summary>
        /// Gets the Login field element
        /// </summary>
        private LazyElement LoginButton
        {
            get
            {
                return new LazyElement(this.testObject, By.CssSelector
          (".btn.btn-default.btn-brand.btn-brand-big"), "Lonin button");
            }
        }

        /// <summary>
        /// Sample lazy element
        /// </summary>
        private LazyElement Sample
        {
            get { return this.GetLazyElement(By.CssSelector("#CSS_ID"), "Sample message"); }
        }

        /// <summary>
        /// Open the page
        /// </summary>
        public void OpenPage()
        {
            // sample open login page
            this.TestObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Check if the login page is loaded
        /// </summary>
        public override bool IsPageLoaded()
        {
            return this.EmailField.Displayed;
          //  return this.WebDriver.Url.Equals(PageUrl, System.StringComparison.CurrentCultureIgnoreCase);
        }

        //<summary>
        ///SignIn
        /// </summary>
        public void LogInToUserAccount()
        {
            EmailField.SendKeys("demouser@microsoft.com");
            PassowrdField.SendKeys("Pass@word1");
            LoginButton.Click();
        }
    }
}
