using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class ImportaProfessorPage
    {
        IWebDriver driver;


        public ImportaProfessorPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Importacao/ImportaProfessores");
        }
        public void upload(string path, string codigo)
        {

            SelectElement cbBoxUser = new SelectElement(driver.FindElement(By.Name("ProgramaId")));
            cbBoxUser.SelectByText(codigo);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(300));
            IWebElement uploadButton = driver.FindElement(By.Id("Arquivo"));
            uploadButton.SendKeys(path);

            IWebElement logarButton = driver.FindElement(By.Id("load"));
            logarButton.Click();
        }
    }
}
