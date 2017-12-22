using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654");
        }

        public LoginPage logar(string login, string senha)
        {
            IWebElement loginUser = driver.FindElement(By.Name("Login"));
            IWebElement senhaUser = driver.FindElement(By.Name("Senha"));
            IWebElement logarButton = driver.FindElement(By.Id("btnAdicionar"));

            loginUser.SendKeys(login);
            senhaUser.SendKeys(senha);
            Thread.Sleep(1000);
            logarButton.Click();
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("main"));
            });

            
            return new LoginPage(driver);
        }

    }
}
