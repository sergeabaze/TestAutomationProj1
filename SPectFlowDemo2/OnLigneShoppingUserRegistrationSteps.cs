using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using
OpenQA.Selenium.Support.UI;
using
ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SPectFlowDemo2
{
    [Binding]
    public class OnLigneShoppingUserRegistrationSteps
    {
        IWebDriver driver;
        WebDriverWait wait;

        [Given(@"user it at home page")]
        public void GivenUserItAtHomePage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Given(@"navigate to register page")]
        public void GivenNavigateToRegisterPage()
        {
            IWebElement loginLink = wait.Until(ExpectedConditions.
              ElementToBeClickable(By.LinkText("Login"))); loginLink.Click();
            IWebElement registerNewUser = wait.Until(ExpectedConditions.ElementExists
                (By.LinkText("Register as a new user?")));
            registerNewUser.Click();
        }

        [When(@"user enter valide valide email password and confirm password")]
        public void WhenUserEnterValideValideEmailPasswordAndConfirmPassword()
        {
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable
                (By.Id("Email")));
            emailField.SendKeys("ALLTECH@gmail.com");
            IWebElement passWord = wait.Until(ExpectedConditions.ElementExists
                (By.Id("Password"))); passWord.SendKeys("Pass@123");
            IWebElement confirmPassWord = wait.Until(ExpectedConditions.ElementExists
                (By.Id("ConfirmPassword")));
            confirmPassWord.SendKeys("Pass@123");
        }

        [When(@"click on signin button")]
        public void WhenClickOnSigninButton()
        {
            IWebElement registerButton = wait.Until(ExpectedConditions.ElementToBeClickable
                (By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big")));
            registerButton.Click();
        }

        [Then(@"user navigate to user account")]
        public void ThenUserNavigateToUserAccount()
        {
            Assert.AreEqual(true, driver.FindElement
                (By.LinkText("My account")).Displayed);
        }


        [When(@"user logout from user account")]
        public void WhenUserLogoutFromUserAccount()
        {
            IWebElement logoutLink = driver.FindElement
                (By.LinkText("Log Out"));
            logoutLink.Click();
        }


        [Then(@"myaccount link should not be displayed")]
        public void ThenMyaccountLinkShouldNotBeDisplayed()
        {
            Assert.AreEqual(false, driver.FindElements(By.LinkText
                ("My account")).Count > 0);
        }
    }
}
