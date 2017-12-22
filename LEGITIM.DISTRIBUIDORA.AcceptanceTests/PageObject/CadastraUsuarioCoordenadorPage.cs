using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class CadastraUsuarioCoordenadorPage
    {
        IWebDriver driver;
        public CadastraUsuarioCoordenadorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Usuario/CadastraUsuarioCoordenador");
        }

        public void AdicionarCoordenador(string codigo, string coodenador, string Adjunto)
        {
            Thread.Sleep(1000);
            SelectElement cbBoxPrograma= new SelectElement(driver.FindElement(By.Name("ProgramaId")));
            cbBoxPrograma.SelectByText(codigo);


            Thread.Sleep(1500);
            SelectElement cbBoxCoordenador = new SelectElement(driver.FindElement(By.Name("CoordenadorId")));
            cbBoxCoordenador.SelectByText(coodenador);

           
            SelectElement cbBoxAdjunto = new SelectElement(driver.FindElement(By.Name("CoordenadorAdjuntoId")));
            cbBoxAdjunto.SelectByText(Adjunto);
            

            IWebElement CadastrarLinhaButton = driver.FindElement(By.Id("btnAdicionar"));
            CadastrarLinhaButton.Click();
        }
    }
}
