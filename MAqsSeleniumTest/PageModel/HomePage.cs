using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for HomePage
    /// </summary>
    public class HomePage : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() ;

        /// <summary>
        /// Selenium test object
        /// </summary>
        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HomePage(SeleniumTestObject testObject) : base(testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets the Login Link element
        /// </summary>
        private LazyElement LoginLink
        {
            get
            {
                return new LazyElement(this.testObject, By.LinkText("Login"), "Login Link in home page");
            }
        }

        /// <summary>
        /// Gets the myorders Link element
        /// </summary>
        private LazyElement MyOrdersLink
        {
            get
            {
                return new LazyElement(this.testObject, By.LinkText("My orders"), "MyOrders Link disply in home page after loginto user account"); }
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
            return this.LoginLink.Displayed;
            //return this.WebDriver.Url.Equals(PageUrl, System.StringComparison.CurrentCultureIgnoreCase);
        }

        ///<summary>
        ///Navigate to home page
        /// </summary>
        public void NavigateToHomePage()
        {
            this.testObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        ///<summary>
        ///Click on LoginLink to move to login page
        /// </summary>
        public void ClickonLoginLink()
        {
            LoginLink.Click();
        }

        ///<summary>
        ///Navigate to myorders
        /// </summary>
        public void SelectMyOrdersLink()
        {
            this.testObject.WebDriver.Wait().ForClickableElement(By.
            LinkText("My orders"));
            MyOrdersLink.Click();
        }
    }
}
