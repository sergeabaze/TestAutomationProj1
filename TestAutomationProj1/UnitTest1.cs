using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationProj1
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void MyInitialize()
        {

        }

        [TestCleanup]
        public void Dispose()
        {

        }

       // [TestProperty]
        public void MyPropeerties()
        {

        }

       // [TestClass]
        public void MyTestClass()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("—start-maximized");
            IWebDriver driver = new ChromeDriver(option);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
           // driver.Navigate().GoToUrl("https://nsissimquizz.azurewebsites.net/");
            driver.Navigate().GoToUrl("https://nsissimquizz.azurewebsites.net/account/login/");



            //var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("gLFyf")));

            //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditionsElementToBeClickable(By.Id("lst-ib")));
              wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Email")));
              IWebElement textFieldEmAil = driver.FindElement(By.Id("Email"));
            textFieldEmAil.SendKeys("admin@yahoo.fr");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Password")));
            IWebElement textFieldPAssword = driver.FindElement(By.Id("Password"));
            textFieldPAssword.SendKeys("admin");

            //ajout du click
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                  By.ClassName("btn-info")));
              IWebElement searchButton = driver.FindElement(By.ClassName("btn-info"));
              searchButton.Click();

            //assert

            Assert.AreEqual(true, wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Home Page - Quizz.UI")));

            driver.Dispose();
            //https://nsissimquizz.azurewebsites.net/Administration/Societe
            // driver.Navigate().GoToUrl("https://nsissimquizz.azurewebsites.net/Administration/Societe");

        }
    }
}
