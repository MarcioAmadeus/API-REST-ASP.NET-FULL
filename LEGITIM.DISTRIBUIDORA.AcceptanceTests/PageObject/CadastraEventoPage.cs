using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class CadastraEventoPage
    {
        IWebDriver driver;
        public CadastraEventoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Evento/CadastraEvento");
        }

        public void Adicionarevento(string codigo, string turma, string tipoEvento, string descricao)
        {
            SelectElement cbBoxPrograma = new SelectElement(driver.FindElement(By.Name("ProgramaId")));
            cbBoxPrograma.SelectByText(codigo);

            Thread.Sleep(500);
            SelectElement cbBoxTurma = new SelectElement(driver.FindElement(By.Name("TurmaId")));
            cbBoxTurma.SelectByText(turma);

            Thread.Sleep(500);
            SelectElement cbBoxTipoEnvento = new SelectElement(driver.FindElement(By.Name("SiglaString")));
            cbBoxTipoEnvento.SelectByText(tipoEvento);

            Thread.Sleep(500);
            IWebElement DataInicio = driver.FindElement(By.Name("DataInicio"));
            string hj = DateTime.Now.ToString("dd/MM/yyyy");
            DataInicio.Clear();
            DataInicio.SendKeys(hj);

            Thread.Sleep(500);
            IWebElement DataFimSubmissao = driver.FindElement(By.Name("DataFimSubmissao"));
            //Datafim.Click();
            string FimSubmissao = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            DataFimSubmissao.Clear();
            DataFimSubmissao.SendKeys(FimSubmissao);

            Thread.Sleep(500);
            IWebElement DataFimAprovacao = driver.FindElement(By.Name("DataFimAprocacao"));
            //Datafim.Click();
            string FimAprovacao = DateTime.Now.AddDays(40).ToString("dd/MM/yyyy");
            DataFimAprovacao.Clear();
            DataFimAprovacao.SendKeys(FimAprovacao);

            IWebElement descricaoEvento = driver.FindElement(By.Name("Descricao"));
            descricaoEvento.SendKeys(descricao);

            IWebElement CadastrarLinhaButton = driver.FindElement(By.Id("btnAdicionar"));
            CadastrarLinhaButton.Click();
        }

    }
}
