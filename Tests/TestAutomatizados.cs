using System;
using System.Text.RegularExpressions;

//Debemos importar los siguientes using
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class TestAutomatizados
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = "https://www.demoblaze.com/index.html";
            IWebDriver driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[contains(text(),'Samsung galaxy s6')]")).Click();

            Thread.Sleep(2000);
            var nombre = driver.FindElement(By.XPath("//h2[@class=\"name\"]")).Text;
            var precio = driver.FindElement(By.XPath("//h3[@class=\"price-container\"]")).Text;
            precio = Regex.Replace(precio, @"[^\d]", "");
            driver.FindElement(By.XPath("//a[contains(text(),'Add to cart')]")).Click();

            Thread.Sleep(1000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            driver.FindElement(By.XPath("//*[@id=\"cartur\"]")).Click();

            Thread.Sleep(2000);
            var nombreCarro = driver.FindElement(By.XPath("//td[2]")).Text;
            var precioCarro = driver.FindElement(By.XPath("//*[@id=\"totalp\"]")).Text;

            Assert.AreEqual(nombre, nombreCarro);
            Assert.AreEqual(precio, precioCarro);
        }            
    }
}