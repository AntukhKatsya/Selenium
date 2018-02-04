using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;


namespace TestFramework.Pages
{
    class MoodPage                     //страница настроений
    {
        private string BASE_URL;            //адрес
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//li[2]/a[1]")]
        private IWebElement linkSpring;                     //ссылка Весеннее

        public MoodPage(IWebDriver driver, string url)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            BASE_URL = url;
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string SpringOpen()                 //запустить весеннее радио
        {
            string url;
            url = linkSpring.GetAttribute("href");
            linkSpring.Click();
            return url;
        }
    }
}
