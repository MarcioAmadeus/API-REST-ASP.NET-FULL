using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class PerfilUsuarioPage
    {
        IWebDriver driver;
        public PerfilUsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Usuario/PerfilUsuario");
        }

        public void completarPerfilAluno(string lattes)
        {
            Thread.Sleep(2200);
            IWebElement EditarButton = driver.FindElement(By.Id("lattesId"));
            IWebElement lattesAluno = driver.FindElement(By.Name("LattesLink"));
            EditarButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("LattesLink")));
            lattesAluno.SendKeys(lattes);

            Thread.Sleep(1000);
            IWebElement EditarButtonconfirm = driver.FindElement(By.Id("idLattesEdit"));
            EditarButtonconfirm.Click();



        }
    }
}
