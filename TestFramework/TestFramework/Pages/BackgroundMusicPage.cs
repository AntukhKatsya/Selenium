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
    class BackgroundMusicPage      //страница фоновой музыки
    {
        private const string BASE_URL = "http://101.ru/radio-group/group/5";             //адрес
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//img[@alt='Саундтреки']")]
        private IWebElement imgSoundracks;                     //картинка Саундтреки

        public BackgroundMusicPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickSaudtracks()                    //картинка Саундтреки
        {
            imgSoundracks.Click();
        }
    }
}
