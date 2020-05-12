using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SPectFlowDemo2
{
    [Binding]
    //[TestFixture]
    public class InvalideLoginSteps
    {
        IWebDriver driver;
        WebDriverWait wait;

       // [Test]
        [Given(@"Utilisateur sur la Page Accueille")]
        public void GivenUtilisateurSurLaPageAccueille()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("—start-maximized");
            driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("https://github.com");


            // ScenarioContext.Current.Pending();
        }
       // [Test]
        [Given(@"Navigation vers la page Login")]
        public void GivenNavigationVersLaPageLogin()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.FindElement(By.LinkText("Sign in")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
            UrlContains("https://github.com/login"));
        }
       
        [When(@"Utilisateur entre le mot de passe et login incorrect")]
        public void WhenUtilisateurEntreLeMotDePasseEtLoginIncorrect()
        {
            driver.FindElement(By.Id("login_field")).SendKeys("ABC");
            driver.FindElement(By.Id("password")).SendKeys("123");

            // ScenarioContext.Current.Pending();
        }
       
        [When(@"Click sur le bouton signin")]
        public void WhenClickSurLeBoutonSignin()
        {
            driver.FindElement(By.Name("commit")).Click();
        }
       
        [Then(@"Message Erreur Afficher au Navigateur")]
        public void ThenMessageErreurAfficherAuNavigateur()
        {
            IWebElement validationMsg = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("js-flash-container")));
            StringAssert.Contains("Incorrect username or password",
            validationMsg.Text);
            driver.Dispose();
        }
    }
}
