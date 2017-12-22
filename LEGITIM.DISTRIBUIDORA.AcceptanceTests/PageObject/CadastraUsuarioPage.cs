using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{
    public class CadastraUsuarioPage
    {
        IWebDriver driver;

        public CadastraUsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void visita()
        {
            driver.Navigate().GoToUrl("http://localhost:1654/Usuario/CadastraUsuario");
        }
        public void UsuarioAdicionar(string nome, string email, string perfil, string login, string senha, string confirmarSenha)
        {

            IWebElement NomeUser = driver.FindElement(By.Name("Nome"));
            IWebElement EmailUser = driver.FindElement(By.Name("Email"));
            SelectElement cbBoxPerfil = new SelectElement(driver.FindElement(By.Name("PerfilId")));
            IWebElement LoginUser = driver.FindElement(By.Name("Login"));
            IWebElement SenhaUser = driver.FindElement(By.Name("Senha"));
            IWebElement ConfirmarSenhaUser = driver.FindElement(By.Name("ConfirmarSenha"));
            IWebElement checkBox1 = driver.FindElement(By.Id("EscolhaProgramaLista_0__Check"));
            IWebElement checkBox2 = driver.FindElement(By.Id("EscolhaProgramaLista_1__Check"));


         
            IWebElement CadastrarLinhaButton = driver.FindElement(By.Id("btnAdicionar"));

            NomeUser.SendKeys(nome);
            EmailUser.SendKeys(email);
            cbBoxPerfil.SelectByText(perfil);
            LoginUser.SendKeys(login);
            SenhaUser.SendKeys(senha);
            ConfirmarSenhaUser.SendKeys(confirmarSenha);
            checkBox1.Click();
            checkBox2.Click();
            CadastrarLinhaButton.Click();
        }

    }
}
