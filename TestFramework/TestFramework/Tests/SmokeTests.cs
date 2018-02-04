using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace TestFramework
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()                      //открыть браузер
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()                            //закрыть браузер
        {
            steps.CloseBrowser();
        }

        [Test]
        public void register()                                  //регистрация
        {
            Assert.IsTrue( steps.Register101("LyutovaOktyabrina204", "wafixe@mail.ru", "LnacQDPsZY3z"));
        }

        [Test]
        public void authorization()                                  //авторизация
        {
            Assert.IsTrue(steps.Authorization101("SmorchkovProkl162", "aZdyJKaACs5Y"));
        }

        [Test]
        public void changeProfileData()                                  //заполнение данных профиля
        {
            Assert.IsTrue(steps.ChangeProfileData101("SmorchkovProkl162", "aZdyJKaACs5Y", "женский", "23", "ноября", "1978", "Люблю рок"));
        }

        [Test]
        public void addComment()                                  //добавление комментария к фото
        {
            Assert.IsTrue(steps.AddComment101("SmorchkovProkl162", "aZdyJKaACs5Y", "Sven"));
        }

        [Test]
        public void radioByGenre()                    //выбор радиостанции по жанру
        {
            Assert.IsTrue(steps.RadioByGenre101("Саундтреки"));
        }

        [Test]
        public void artist()              //информация об исполнителе
        {
            Assert.IsTrue(steps.Artist("Агата Кристи"));
        }

        [Test]
        public void search()                      //поиск
        {
            Assert.IsTrue(steps.Search("Русский Рок"));
        }

        [Test]
        public void mood()            //музыка по настроению
        {
           Assert.IsTrue(steps.Mood("Весеннее"));
        }

        [Test]
        public void like()                //лайк
        {
            Assert.IsTrue(steps.Like());
        }

        [Test]
        public void clip()                      //клип
        {
            Assert.IsTrue(steps.Clip());
        }
    }
}
