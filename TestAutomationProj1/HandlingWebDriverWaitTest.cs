using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationProj1
{
    [TestClass]
    public class HandlingWebDriverWaitTest
    {
        ChromeOptions option;
        IWebDriver driver;
        [TestInitialize]
        public void MyInitialize()
        {
            option = new ChromeOptions();
            option.AddArgument("—start-maximized");
            driver = new ChromeDriver(option);
        }

        [TestCleanup]
        public void Dispose()
        {
             driver.Dispose();
        }

        [TestMethod]
        public void GoogleSearchWithoutWait()
        {
             driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class='sbsb_a']//ul/li[2]"));
            listValue.Click();
        }

        [TestMethod]
        public void GoogleSearchWithThreadWait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            Thread.Sleep(5000);
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class = 'sbsb_a']//ul/li[2]"));
            listValue.Click();
        }

        [TestMethod]
        public void GoogleSearchWithWait()
        {
             driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='sbsb_a']//ul/li[2]")));
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class = 'sbsb_a']//ul/li[2]"));
            listValue.Click();
        }

        [TestMethod]
        public void GoogleElementIsVisible()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // IWebElement loginIcon = wait.Until(ExpectedConditions.ElementExists(By.LinkText("Login")));

          //  Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentInElement(loginButton, "LOG IN")))
        }

        [TestMethod]
        public void ElementToBeClickable()
        {
           // IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
        }

        [TestMethod]
        public void TextToBePresentInElementLocated()
        {
            // IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));

           // Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"),"LOG IN")));
        }

        [TestMethod]
        public void TextToBePresentInElementValue()
        {
            //Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentIn
           // ElementValue(By.Id("Email"), "demouser@microsoft.com")));
        }

        [TestMethod]
        public void TitleContains()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Assert.AreEqual(true, wait.Until(ExpectedConditions.TitleContains("Log in")));
            //Assert.AreEqual(true,wait.Until(ExpectedConditions.TitleIs("Catalog -
          //  Microsoft.eShopOnWeb")));
        }

        [TestMethod]
        public void UrlContains()
        {
          //  Assert.AreEqual(true, wait.Until(ExpectedConditions.UrlContains("http://eshop-testweb")));

        }

        [TestMethod]
        public void UrlToBe()
        {
            //  Assert.AreEqual(true, wait.Until(ExpectedConditions.UrlToBe("http://eshop-testweb.azurewebsites.net/")));

        }

        [TestMethod]
        public void Test()
        {

        }

       

    }
}
