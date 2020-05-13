using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationProj1
{
    [TestClass]
    public class CaptureWbElementWebTest
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

        [TestMethod]
        public void TestLocatorID()
        {
             driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
    
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("demouser@microsoft.com");

        }

        [TestMethod]
        public void TestLocatorName()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");

            IWebElement password = driver.FindElement(By.Name("Password"));
            password.SendKeys("Pass@word1");
        }

        [TestMethod]
        public void TestLocatorClassName()
        {
            driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/");

            // IWebElement password = driver.FindElement(By.Name("Password"));
            //password.SendKeys("Pass@word1");
           IWebElement basketImage = driver.FindElement
            (By.ClassName("esh-basketstatus-badge"));
            basketImage.Click();
            //CssSelector:Attribute
           // IWebElement submitButton = driver.FindElement(By.CssSelector
           // ("button[type='submit']"));

            //section 3 de la classe mer .row
           // IWebElement basketIcon = driver.FindElement(By.CssSelector(".row >section: nth - of - type(3) > a"));


        }

        [TestMethod]
        public void TestCSSSelector()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement submitButton = driver.FindElement
            (By.CssSelector(".btn.btn-default.btn-brand.btn - brand - big"));
            submitButton.Submit();
        }

        [TestMethod]
        public void TestLinkText()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
        }

        [TestMethod]
        public void TestPartialLinkText()
        {
            //<a class=text href="">register as a new user
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement registerNewUser = driver.FindElement(By.PartialLinkText("Register as a"));
            registerNewUser.Click();
        }

        [TestMethod]
        public void TestTagName()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement tagElement = driver.FindElement(By.TagName("select"));
            tagElement.Click();
        }

        [TestMethod]
        public void TestABsoluteXpath()
        {
            //Xpath
            ///html/body/div/div[2]/div[3]/form/input[1]

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();

            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("demouser@microsoft.com");

            IWebElement password = driver.FindElement(By.Name("Password"));
            password.SendKeys("Pass@word1");

            IWebElement submitButton = driver.FindElement(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"));
            submitButton.Submit();

            IWebElement myAccount = driver.FindElement(By.XPath("//*[@id='logoutForm']/section[2]/a[2]/div"));
            myAccount.Click();
        }

        [TestMethod]
        public void TestRelativeXpath()
        {
            //It starts with a double slash (//)
            //    //*[@id="logoutForm"]/section[2]/a[2]/div
        }

        [TestMethod]
        public void TestGetAttribute()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
             driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement email = driver.FindElement(By.Id("Email"));
            var value = email.GetAttribute("type");
            var valuecolor = email.GetCssValue("background-color");
            Console.WriteLine(value);
            Console.WriteLine(valuecolor);
        }

        [TestMethod]
        public void TestClickAndHold()
        {
             driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            driver.SwitchTo().Frame(0);
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            IWebElement drop = driver.FindElement(By.Id("droppable"));
            Actions action = new Actions(driver);
            action.ClickAndHold(drag).Build().Perform();
            action.MoveToElement(drop).Build().Perform();
        }

        [TestMethod]
        public void TestDragAndDrop()
        {
             driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            driver.SwitchTo().Frame(0);
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            IWebElement drop = driver.FindElement(By.Id("droppable"));
            Actions action = new Actions(driver);
            action.DragAndDrop(drag, drop).Build().Perform();
        }

        [TestMethod]
        public void TestDragAndDropOffset()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            driver.SwitchTo().Frame(0);
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            Actions action = new Actions(driver);
            action.DragAndDropToOffset(drag, 100, 100).Build().
            Perform();
        }


        [TestCleanup]
        public void Dispose()
        {
           // driver.Dispose();
        }
    }
}
