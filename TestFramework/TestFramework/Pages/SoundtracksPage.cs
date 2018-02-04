using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;


namespace TestFramework.Pages     //страница саундтреков
{
    class SoundtracksPage
    {
        private const string BASE_URL = "http://101.ru/radio/channel/25";             //адрес
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "alslight")]
        private IWebElement labelName;                     //Название станции

        [FindsBy(How = How.XPath, Using = "//span[@atitle='Нравится']")]
        private IWebElement spanLike;                     //лайк

        public SoundtracksPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string getName()
        {
            string name = labelName.Text;
            return name;
        }

        public void Like()   //лайк
        {
            spanLike.Click();
        }

        public bool GetLike()                   //получить лайк
        {
            string str = spanLike.GetAttribute("class");
            if (spanLike.GetAttribute("class") == "h2 icon icon-heart TitleSongAirPoll TitleSongAirPollVoted TitleSongAirPollActive")
                return true;
            return false;
        }
    }
}
