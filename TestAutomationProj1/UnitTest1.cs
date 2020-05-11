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
            driver.Navigate().GoToUrl("https://www.google.lk/");
            //var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("gLFyf")));

            //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditionsElementToBeClickable(By.Id("lst-ib")));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("gLFyf")));
            IWebElement textField = driver.FindElement(By.ClassName("gLFyf"));
            textField.SendKeys("Selenium");
        }
    }
}
