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
    class PhotoAlbumPage                       //фото альбом
    {
        private const string BASE_URL = "http://101.ru/photoalbum";             //адрес
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='central']//a")]
        private IWebElement buttonLoadPhoto;                     //кнопка Загрузить фото

        [FindsBy(How = How.XPath, Using = "//form[@class='user-data-form']//input[@id='photo']")]
        private IWebElement buttonSelectFile;                     //кнопка Выберите файл

        [FindsBy(How = How.XPath, Using = "//form[@class='user-data-form']//input[@type='submit']")]
        private IWebElement buttonLoadFile;                     //кнопка Загрузить

        [FindsBy(How = How.XPath, Using = "//ul//li[1]//div//a[1]")]
        private IWebElement buttonMakeMain;                     //кнопка Сделать основной

        [FindsBy(How = How.XPath, Using = "//ul//li[1]//a[@atitle='Редактировать название']")]
        private IWebElement buttonEditTitle;                     //кнопка Редактировать название

        [FindsBy(How = How.XPath, Using = "//ul//li[1]//input[@name='comment']")]
        private IWebElement inputPhotoName;                     //поле Название фото

        [FindsBy(How = How.XPath, Using = "//ul//li[1]//input[@value='OK']")]
        private IWebElement buttonOK;                     //кнопка ОК

        [FindsBy(How = How.XPath, Using = "//ul//li[1]//h5")]
        private IWebElement labelComment;                     //метка Комментарий

        public PhotoAlbumPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void LoadPhoto()                             //загрузить фото
        {
            string fileName = "D:\\10549922_864266420304927_844931975_n.jpg";
            buttonLoadPhoto.Click();
            buttonSelectFile.SendKeys(fileName);
            buttonLoadFile.Submit();
            Actions builder = new Actions(driver);
            builder
                .MoveToElement(driver.FindElement(By.XPath("//ul//li[1]//img")))
                .Click(buttonMakeMain)
                .Build()
                .Perform();
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void AddComment(string comment)                    //добавить комментарий к фото
        {
            Actions builder = new Actions(driver);
            builder
                .MoveToElement(driver.FindElement(By.XPath("//ul//li[1]//img")))
                .Click(buttonEditTitle)
                .Build()
                .Perform();
            inputPhotoName.Clear();
            inputPhotoName.SendKeys(comment);
            buttonOK.Click();
        }

        public string getComment()                //получить комментарий
        {
            return labelComment.Text;
        }
    }
}
