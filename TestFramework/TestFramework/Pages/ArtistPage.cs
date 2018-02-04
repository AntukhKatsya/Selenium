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
    class ArtistPage                             //страница исполнителя
    {
        private string BASE_URL;            //адрес
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//h1[@class='alslight']")]
        private IWebElement Artist;       //имя исполнителя

        public ArtistPage(IWebDriver driver, string url)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            BASE_URL = url;
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string GetArtist()
        {
            return Artist.Text;
        }
    }
}
