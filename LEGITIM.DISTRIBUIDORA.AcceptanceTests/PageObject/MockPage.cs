using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject
{

    public class MockPage
    {
        IWebDriver driver;

        public MockPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void visita()
        {

            driver.Navigate().GoToUrl("http://localhost:1654/mock/index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("IdMock"));
            });
        }
    }
}
