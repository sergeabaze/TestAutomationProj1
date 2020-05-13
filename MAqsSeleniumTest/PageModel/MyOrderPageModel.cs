using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for MyOrderPageModel
    /// </summary>
    public class MyOrderPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "/Order/Index";

        /// <summary>
        /// Selenium test object
        /// </summary>
        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyOrderPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public MyOrderPageModel(SeleniumTestObject testObject) : base(testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets the sample element
        /// </summary>
        private LazyElement Sample
        {
            get
            {
                return new LazyElement(this.testObject, By.CssSelector("#CSS_ID"), "SAMPLE");
            }
        }

        /// <summary>
        /// Sample lazy element
        /// </summary>
       // private LazyElement Sample
       // {
          //  get { return this.GetLazyElement(By.CssSelector("#CSS_ID"), "Sample message"); }
       // }

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
            return this.Sample.Displayed;
            // return this.WebDriver.Url.Equals(PageUrl, System.StringComparison.CurrentCultureIgnoreCase);
        }

        ///<summary>
        ///
        /// </summary>
        public void VerifyMyOrderPage()
        {
            this.testObject.WebDriver.Wait().UntilPageLoad();
            Assert.AreEqual(true, this.testObject.WebDriver.FindElement(By.CssSelector(".container > h1")).Text.Equals("My Order History"));
        }
    }
}
