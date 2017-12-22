using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class EditarTurmaDataFimPage
    {
        IWebDriver driver;
        public EditarTurmaDataFimPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void visita(string url)
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Turma/ListarTurmas");
            driver.Navigate().GoToUrl(url);
            
        }
        public void EditarTurma(int ano)
        {
            //Datafim.Click();
            //string fim = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            Thread.Sleep(500);
            IWebElement Datafim = driver.FindElement(By.Name("DataFim"));
            if (ano == 2015)
            {
                string fim = "31/12/2017";
                Datafim.Clear();
                Datafim.SendKeys(fim);
                Thread.Sleep(300);
                IWebElement ClickFora = driver.FindElement(By.Name("Nome"));
                ClickFora.Click();
                Thread.Sleep(300);
                IWebElement CadastrarLinhaButton = driver.FindElement(By.Id("EditarTurma"));
                CadastrarLinhaButton.Click();
             
            }
            else
            {
                string fim = "31/12/2018";
                Datafim.Clear();
                Datafim.SendKeys(fim);
                IWebElement ClickFora = driver.FindElement(By.Name("Nome"));
                Thread.Sleep(300);
                ClickFora.Click();
                Thread.Sleep(300);
                IWebElement CadastrarLinhaButton = driver.FindElement(By.Id("EditarTurma"));
                CadastrarLinhaButton.Click();
            }
          
        }
    }
}
