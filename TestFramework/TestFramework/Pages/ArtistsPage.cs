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
    class ArtistsPage                      //страница исполнителей
    {
        private string BASE_URL;            //адрес
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'А')]")]
        private IWebElement linkA;                     //ссылка А

        [FindsBy(How = How.XPath, Using = "//a[span = 'Агата Кристи']")]
        private IWebElement linkAgataKristi;                    //ссылка Агата Кристи



        public ArtistsPage(IWebDriver driver, string url)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            BASE_URL = url;
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string ChooseArtist()
        {
            string url;
            linkA.Click();
            url = linkAgataKristi.GetAttribute("href");
            linkAgataKristi.Click();
            return url;
        }
    }
}
