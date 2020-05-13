using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using Magenic.Maqs.Utilities.Helper;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the HomePageModel page
    /// </summary>
    public class HomePageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "Static/Training3/HomePage.html";
        private static readonly string PageUrl_ = SeleniumConfig.GetWebSiteBase();

        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HomePageModel(SeleniumTestObject testObject) : base(testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement WelcomeMessage
        {
            get { return this.GetLazyElement(By.CssSelector("#WelcomeMessage"), "Welcome message"); }
        }

        private LazyElement LoginLink
        {
            get
            {
                return new LazyElement(this.testObject,
                By.LinkText("Login"), "Login Link in home page");
            }
        }

        /// <summary>
        /// Gets the myorders Link element
        /// </summary>
        private LazyElement MyOrdersLink
        {
            get
            {
                return new LazyElement(this.testObject, By.LinkText
          ("My orders"), "MyOrders Link disply in home page after login to user account"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.WelcomeMessage.Displayed;
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
            this.testObject.WebDriver.Wait().ForClickableElement(By.LinkText("My orders"));
            MyOrdersLink.Click();
        }
    }
}

