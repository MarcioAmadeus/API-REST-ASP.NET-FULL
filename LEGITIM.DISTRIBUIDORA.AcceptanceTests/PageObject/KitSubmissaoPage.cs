using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class KitSubmissaoPage
    {
        IWebDriver driver;

        public KitSubmissaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            Thread.Sleep(150);
            driver.Navigate().GoToUrl("http://localhost:1654/Evento/Cadastrakit");
            Thread.Sleep(150);
        }

        public void KitSubmissaoAdicionar(string programa, string evento, string path)
        {

            SelectElement cbBoxPrograma = new SelectElement(driver.FindElement(By.Name("ProgramaId")));
            cbBoxPrograma.SelectByText(programa);
            Thread.Sleep(2000);

            SelectElement cbBoxUser2 = new SelectElement(driver.FindElement(By.Name("SiglaString")));
            cbBoxUser2.SelectByText(evento);
            Thread.Sleep(2000);

            IWebElement uploadButton = driver.FindElement(By.Id("File"));
            uploadButton.SendKeys(path);
            Thread.Sleep(2000);

            


            Thread.Sleep(1000);
            IWebElement logarButton = driver.FindElement(By.Id("btnAdicionar"));
            logarButton.Click();
            var test = "";
        }
    }
}
