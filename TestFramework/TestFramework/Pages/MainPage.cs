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
    class MainPage                                               //главная страница
    {
        private const string BASE_URL = "http://101.ru/";             //адрес
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "profile-enter")]
        private IWebElement buttonEnter;                     //кнопка Вход

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Зарегистрироваться')]")]
        private IWebElement linkRegister;                     //ссылка Зарегестрироваться

        [FindsBy(How = How.XPath, Using = "//div[@id='registration']//form[@id='login-form']//input[@type='text'][1]")]
        private IWebElement inputRegisterLogin;                     //поле Логин для регистрации

        [FindsBy(How = How.XPath, Using = "//div[@id='registration']//form[@id='login-form']//input[@type='email'][1]")]
        private IWebElement inputEmail;                     //поле e-mail

        [FindsBy(How = How.XPath, Using = "//div[@id='registration']//form[@id='login-form']//input[@type='password'][1]")]
        private IWebElement inputRegisterPassword;                     //поле Пароль для регистрации

        [FindsBy(How = How.XPath, Using = "//div[@id='registration']//form[@id='login-form']//input[@type='password'][2]")]
        private IWebElement inputRepeatPassword;                     //поле Повторите пароль

        [FindsBy(How = How.XPath, Using = "//div[@id='registration']//form[@id='login-form']//input[@type='submit']")]
        private IWebElement buttonRegister;                     //кнопка Зарегестрироваться

        [FindsBy(How = How.XPath, Using = "//form[@id='login-form']//input[@type='text'][1]")]
        private IWebElement inputAuthorizationLogin;         //поле Логин для авторизации

        [FindsBy(How = How.XPath, Using = "//form[@id='login-form']//input[@type='password'][1]")]
        private IWebElement inputAuthorizationPassword;       //поле Пароль для регистрации

        [FindsBy(How = How.XPath, Using = "//form[@id='login-form']//input[@type='submit']")]
        private IWebElement buttonAuthorization;       //кнопка Войти

        [FindsBy(How = How.XPath, Using = "//center//input[@value='Нет']")]
        private IWebElement buttonNotMoskow;       //кнопка не из Москвы

        [FindsBy(How = How.XPath, Using = "(//div[@id='layout']/div//h2)[1]/span[2]/a[1]")]
        private IWebElement linkTaste;                     //ссылка По вкусу

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Фоновая Музыка')]")]
        private IWebElement linkBackgroundMusic;                     //ссылка Фоновая музыка

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Музыка')]")]
        private IWebElement itemMusic;                     //пункт меню Музыка

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Исполнители')]")]
        private IWebElement linkArtists;                     //ссылка Исполнители

        [FindsBy(How = How.XPath, Using = "//span[@class='pr']//a[1]")]
        private IWebElement linkSearch;                     //ссылка поиск

        [FindsBy(How = How.Name, Using = "search")]
        private IWebElement testboxSearch;                     //поле поиск

        [FindsBy(How = How.XPath, Using = "//form[@class='search-form']//a[1]")]
        private IWebElement linkSubmitSearch;                     //ссылка найти

        [FindsBy(How = How.XPath, Using = "//div[@class='h3 caps htitle']")]
        private IWebElement labelSearch;                     //название найденной станции

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Радио')]")]
        private IWebElement itemRadio;                     //пункт меню Радио

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'настроению')]")]
        private IWebElement linkMood;                     //ссылка Радио по настроению

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Клипы')]")]
        private IWebElement linkClips;                  //ссылка клипы

        public MainPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnEnterButton()                    //кнопка войти
        {
            buttonEnter.Click();
        }

        public void ClickOnRegisterButton()                    //кнопка зарегестрироваться
        {
            linkRegister.Click();
        }

        public void FillingRegistrationFields(string login, string email, string password)  //заполнение полей регистрации
        {
            linkRegister.Click();
            inputRegisterLogin.SendKeys(login);
            inputEmail.SendKeys(email);
            inputRegisterPassword.SendKeys(password);
            inputRepeatPassword.SendKeys(password);
            buttonRegister.Click();
        }

        public void FillingAuthorizationFields(string login, string password)  //заполнение полей авторизации
        {
            inputAuthorizationLogin.SendKeys(login);
            inputAuthorizationPassword.SendKeys(password);
            buttonAuthorization.Click();
        }

        public void RadioByGenre()              //выбор радио по вкусу
        {
            linkTaste.Click();
            linkBackgroundMusic.Click();
        }

        public string Artist()                    //открываем страничку исполнителей
        {
            Actions builder = new Actions(driver);
            builder
                .MoveToElement(driver.FindElement(By.XPath("//span[contains(text(), 'Музыка')]")))
                .Click(linkArtists)
                .Build()
                .Perform();
            return linkArtists.GetAttribute("href");     //возвращаем ссылку на страницу исполнителей
        }

        public string Search()              //поиск
        {
            linkSearch.Click();
            testboxSearch.SendKeys("русский рок");
            linkSubmitSearch.Click();
            string str = linkSearch.Text;
            return linkSearch.Text;
        }

        public string Mood()            //радио по настроению
        {
            Actions builder = new Actions(driver);
            builder
                .MoveToElement(driver.FindElement(By.XPath("//span[contains(text(), 'Радио')]")))
                .Click(linkMood)
                .Build()
                .Perform();
            return linkMood.GetAttribute("href");     //возвращаем ссылку на страницу исполнителей
        }

        public string Clip()                      //клип
        {
            Actions builder = new Actions(driver);
            builder
                .MoveToElement(driver.FindElement(By.XPath("//span[contains(text(), 'Музыка')]")))
                .Click(linkClips)
                .Build()
                .Perform();
            return linkClips.GetAttribute("href");     //возвращаем ссылку на страницу клипов
        }
    }
}
