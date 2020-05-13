using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.
Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestAutomationProj1
{
    [TestClass]
    public class Scenario_logineShop 
    {
        [TestMethod]
        public void TestMethod_NavigateToEshop()
        {
            string userEmail = "romuxxes@gmail.com";

            //1-home page
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/");
            WebDriverWait wait = new WebDriverWait(driver,
            TimeSpan.FromSeconds(30));

            //2-Navigate to login page
            IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
            loginLink.Click();

            // navigate to register page
            IWebElement registerNewUser = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Register as a new user?")));
            registerNewUser.Click();

            // 4- create user register
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Email")));
            emailField.SendKeys(userEmail);
            IWebElement passWordField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Password")));
            passWordField.SendKeys("Abc@123");
            IWebElement confirmPassWordField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ConfirmPassword")));
            confirmPassWordField.SendKeys("Abc@123");
            IWebElement registerButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector
            (".btn.btn-default.btn-brand.btn-brand-big")));
            registerButton.Submit();

            //6- move to my account
            IWebElement myAccountLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("My account")));
            myAccountLink.Click();

            Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("Email"), userEmail)));
        }
    }
}
