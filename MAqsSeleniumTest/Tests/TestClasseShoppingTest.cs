using Magenic.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

// TODO: Add reference to object model
// using PageModel;

namespace Tests
{
    /// <summary>
    /// TestClasseShoppingTest test class
    /// </summary>
    [TestClass]
    public class TestClasseShoppingTest : BaseSeleniumTest
    {
        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        public void LoginToUserAccount()
        {
            HomePage homePage = new HomePage(this.TestObject);

            homePage.NavigateToHomePage();
            Assert.AreEqual(true, homePage.IsPageLoaded());

            homePage.ClickonLoginLink();
            UserLoginPage loginToSite = new UserLoginPage(this.TestObject);
            loginToSite.LogInToUserAccount();
            homePage.SelectMyOrdersLink();

            MyOrderPageModel myOrders = new MyOrderPageModel(this.TestObject);
            myOrders.VerifyMyOrderPage();

            // TODO: Add test code
            //PageModel page = new PageModel(this.TestObject);
            //page.OpenPage();
        }
    }
}
