using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    
    public class ListarEventosPage
    {
        IWebDriver driver;
        public ListarEventosPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Evento/ListarEventos");
        }

    }
}
