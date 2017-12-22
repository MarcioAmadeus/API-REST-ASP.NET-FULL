using System;
using OpenQA.Selenium;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class ImportarOrientacao
    {
        IWebDriver driver;
        public ImportarOrientacao(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Importacao/ImportaOrientacoes");
        }

        public void upload(string path)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(300));
            IWebElement uploadButton = driver.FindElement(By.Id("Arquivo"));
            uploadButton.SendKeys(path);

            IWebElement logarButton = driver.FindElement(By.Id("load"));
            logarButton.Click();
        }
    }
}
