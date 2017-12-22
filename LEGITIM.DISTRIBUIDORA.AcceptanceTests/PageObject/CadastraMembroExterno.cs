using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class CadastraMembroExterno
    {
        IWebDriver driver;

        public CadastraMembroExterno(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            Thread.Sleep(100);
            driver.Navigate().GoToUrl("http://localhost:1654/MembroExterno/CadastraMembroExterno");
            Thread.Sleep(100);
        }

        public void MenbroExternoAdicionar(string nome, string cpf, string email, string telefone, string instituicao)
        {

            IWebElement nomeMenbro = driver.FindElement(By.Name("Nome"));
            IWebElement cpfMenbro = driver.FindElement(By.Name("CPF"));
            IWebElement emailMenbro = driver.FindElement(By.Name("Email"));
            IWebElement telefoneMenbro = driver.FindElement(By.Name("Telefone"));
            IWebElement instituicaoMenbro = driver.FindElement(By.Name("Instituicao"));
            IWebElement Cadastrar = driver.FindElement(By.ClassName("btn-primary"));

            nomeMenbro.SendKeys(nome);
            cpfMenbro.SendKeys(cpf);
            emailMenbro.SendKeys(email);
            telefoneMenbro.SendKeys(telefone);
            instituicaoMenbro.SendKeys(instituicao);

            Cadastrar.Click();
        }
    }
}
