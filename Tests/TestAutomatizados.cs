using Microsoft.VisualStudio.TestTools.UnitTesting;

//Debemos importar los siguientes using
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestClass]
    public class TestAutomatizados
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = "https://www.demoblaze.com/index.html";

            //Abrimos el navegador chrome
            IWebDriver driver = new ChromeDriver();

            //Abrimos mercado libre utilizando la url del mismo y el driver recien instanciado
            driver.Navigate().GoToUrl(url);

        }
    }
}
