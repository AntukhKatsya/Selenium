using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace TestFramework.Steps
{
    class Steps
    {
        IWebDriver driver;
        Pages.MainPage mainPage;
        Pages.MoodPage moodPage;
        Pages.RadioPage radioPage;
        Pages.ClipsPage clipsPage;
        Pages.ArtistPage artistPage;
        Pages.ProfilePage profilePage;
        Pages.ArtistsPage artistsPage;
        Pages.PhotoAlbumPage photoAlbumPage;
        Pages.SoundtracksPage soundTrackPage;
        Pages.BackgroundMusicPage backgroundMusicPage;

        public void InitBrowser()                         //открыть браузер
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()                              //закрыть браузер
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void Enter101()                                       //авторизация или регистрация
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.ClickOnEnterButton();
        }

        public bool Register101(string login, string email, string password)        //регистрация
        {
            Enter101();
            mainPage.FillingRegistrationFields(login, email, password);
            profilePage = new Pages.ProfilePage(driver);
            return login.Equals(profilePage.GetLogin());
        }

        public bool Authorization101(string login, string password)         //авторизация
        {
            Enter101();
            mainPage.FillingAuthorizationFields(login, password);
            profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            return login.Equals(profilePage.GetLogin());
        }

        public void Photo()           //изменение фотографии
        {
            profilePage.ChangePhoto();
            photoAlbumPage = new Pages.PhotoAlbumPage(driver);
            photoAlbumPage.OpenPage();
            photoAlbumPage.LoadPhoto();
        }

        public bool ChangeProfileData101(string login, string password, string sex, string day, string month, string year, string about)   //изменение данных профиля
        {
            Authorization101(login, password);
            Photo();
            profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.ChangeData(sex, day, month, year, about);
            Thread.Sleep(3000);
            return (sex.Equals(profilePage.GetSex()) && day.Equals(profilePage.GetDay()) && month.Equals(profilePage.GetMonth()) && year.Equals(profilePage.GetYear()) && about.Equals(profilePage.GetAbout()));
        }

        public bool AddComment101(string login, string password, string comment)           //добавление комментария к фото
        {
            Authorization101(login, password);
            profilePage.ChangePhoto();
            photoAlbumPage = new Pages.PhotoAlbumPage(driver);
            photoAlbumPage.OpenPage();
            photoAlbumPage.AddComment(comment);
            return (comment.Equals(photoAlbumPage.getComment()));
        }

        public bool RadioByGenre101(string name)               //выбор радиостанции по жанру
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.RadioByGenre();
            backgroundMusicPage = new Pages.BackgroundMusicPage(driver);
            backgroundMusicPage.OpenPage();
            backgroundMusicPage.ClickSaudtracks();
            soundTrackPage = new Pages.SoundtracksPage(driver);
            soundTrackPage.OpenPage();
            return (name.Equals(soundTrackPage.getName()));
        }

        public bool Artist(string name)            //информация об исполнителе
        {
            string url;
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            url = mainPage.Artist();
            artistsPage = new Pages.ArtistsPage(driver, url);
            artistsPage.OpenPage();
            url = artistsPage.ChooseArtist();
            artistPage = new Pages.ArtistPage(driver, url);
            artistPage.OpenPage();
            return (name.Equals(artistPage.GetArtist()));
        }

        public bool Search(string name)                  //поиск
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            return (name.Equals(mainPage.Search()));
        }

        public bool Mood(string mood)                        //радио по настроению
        {
            string url;
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            url = mainPage.Mood();
            moodPage = new Pages.MoodPage(driver, url);
            moodPage.OpenPage();
            url = moodPage.SpringOpen();
            radioPage = new Pages.RadioPage(driver, url);
            radioPage.OpenPage();
            return (mood.Equals(radioPage.GetRadio()));
        }

        public bool Like()               //лайк
        {
            RadioByGenre101("Саундтреки");
            soundTrackPage = new Pages.SoundtracksPage(driver);
            soundTrackPage.Like();
            return soundTrackPage.GetLike();
        }

        public bool Clip()                   //клип
        {
            string url;
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            url = mainPage.Clip();
            clipsPage = new Pages.ClipsPage(driver, url);
            clipsPage.OpenPage();
            clipsPage.GoToClip();
            return clipsPage.HasPlayer();
        }
    }
}
