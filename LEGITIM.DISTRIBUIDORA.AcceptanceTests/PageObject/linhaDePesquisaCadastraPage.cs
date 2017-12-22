using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{

    public class linhaDePesquisaCadastraPage
    {
        IWebDriver driver;

        public linhaDePesquisaCadastraPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            Thread.Sleep(150);
            driver.Navigate().GoToUrl("http://localhost:1654/LinhaDePesquisa/Adicionar");
            Thread.Sleep(150);
        }


        public void LinhaDePesquisaAdicionar(string programa, string codigo, string titulo)
        {

            SelectElement cbBoxUser = new SelectElement(driver.FindElement(By.Name("ProgramaId")));
            IWebElement codigoUser = driver.FindElement(By.Name("Codigo"));
            IWebElement tituloUser = driver.FindElement(By.Name("Titulo"));
            IWebElement CadastrarLinhaButton = driver.FindElement(By.ClassName("btn-primary"));

            cbBoxUser.SelectByText(programa);
            codigoUser.SendKeys(codigo);
            tituloUser.SendKeys(titulo);

            CadastrarLinhaButton.Click();
        }

    }
}
