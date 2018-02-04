using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace TestFramework.Pages
{
    class ClipsPage                      //клип
    {
        private string BASE_URL;            //адрес
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='videos']/li[1]/div[2]/a")]
        private IWebElement linkVideo;       //ссылка Видео 1

        [FindsBy(How = How.XPath, Using = "//iframe")]
        private IWebElement iframeVideo;       //проигрыватель

        public ClipsPage(IWebDriver driver, string url)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            BASE_URL = url;
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void GoToClip()                  //перейти к странице клипа
        {
            linkVideo.Click();
            driver.Navigate().GoToUrl(linkVideo.GetAttribute("href"));
        }

        public bool HasPlayer()                     //содержит видеоплеер 
        {
            try
            {
                driver.FindElement(By.XPath("//iframe"));
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
    }
}
