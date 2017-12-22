using System;
using OpenQA.Selenium;
using System.Web;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{

    public class ImportaAlunoPage
    {
        IWebDriver driver;

        public ImportaAlunoPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Importacao/ImportaAlunos");
        }
        public void upload(string path)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            IWebElement uploadButton = driver.FindElement(By.Id("Arquivo"));
            uploadButton.SendKeys(path);
            IWebElement logarButton = driver.FindElement(By.Id("load"));
            logarButton.Click();
          
        }
    }
}
