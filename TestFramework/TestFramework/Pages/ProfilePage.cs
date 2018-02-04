using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{
    class ProfilePage                    //профиль пользователя
    {
        private const string BASE_URL = "http://101.ru/profile";             //адрес
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "alslight")]
        private IWebElement labelLogin;                     //метка Логин

        [FindsBy(How = How.XPath, Using = "id('layout')//a[1]")]
        private IWebElement buttonChangePhoto;                     //кнопка Изменить фото

        [FindsBy(How = How.Name, Using = "sex")]
        private IWebElement listSex;                     //список Пол

        [FindsBy(How = How.Name, Using = "day")]
        private IWebElement listDay;                     //список День

        [FindsBy(How = How.Name, Using = "month")]
        private IWebElement listMonth;                     //список Месяц

        [FindsBy(How = How.Name, Using = "year")]
        private IWebElement listYear;                     //список Год

        [FindsBy(How = How.Name, Using = "about")]
        private IWebElement inputAbout;                     //поле О себе

        [FindsBy(How = How.XPath, Using = "//form[@name='profile']//input[@value='Изменить']")]
        private IWebElement buttonChange;                     //кнопка Изменить

        [FindsBy(How = How.XPath, Using = "//a[@class='logo']//img")]
        private IWebElement buttonMain;                     //кнопка Главная страница

        public ProfilePage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string GetLogin()                 //получить логин пользователя
        {
            return labelLogin.Text;
        }

        public void ChangePhoto()              //изменить фото
        {
            buttonChangePhoto.Click();
        }

        public void ChangeData(string sex, string day, string month, string year, string about)                 //изменить данные профиля
        {
            SelectElement select = new SelectElement(listSex);
            select.SelectByText(sex);
            select = new SelectElement(listDay);
            select.SelectByText(day);
            select = new SelectElement(listMonth);
            select.SelectByText(month);
            select = new SelectElement(listYear);
            select.SelectByText(year);
            inputAbout.Clear();
            inputAbout.SendKeys(about);
            buttonChange.Click();
        }

        public string GetSex()                 //получить пол пользователя
        {
            SelectElement select = new SelectElement(listSex);
            return select.SelectedOption.Text;
        }

        public string GetDay()                 //получить день рождения пользователя
        {
            SelectElement select = new SelectElement(listDay);
            return select.SelectedOption.Text;
        }

        public string GetMonth()                 //получить месяц рождения пользователя
        {
            SelectElement select = new SelectElement(listMonth);
            return select.SelectedOption.Text;
        }

        public string GetYear()                 //получить год рождения пользователя
        {
            SelectElement select = new SelectElement(listYear);
            return select.SelectedOption.Text;
        }

        public string GetAbout()                 //получить информацию о пользователе
        {
            return inputAbout.Text;
        }

        public void GoToMain()                 //перейти на главную страницу
        {
            buttonMain.Click();
        }
    }
}
