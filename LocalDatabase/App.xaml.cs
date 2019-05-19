using System;
using System.IO;
using LocalDatabase.Data;
using LocalDatabase.Model;
using LocalDatabase.View;
using Xamarin.Forms;

namespace LocalDatabase
{
    public partial class App : Application
    {

        // database
        static UsersDatabase database;

        public App()
        {
            InitializeComponent();

           //InitUsers(); // shunchaki moteck userla qoshadi 10 ta


            // user kiritmay rostanam database dan ochdimi yoqmi tekshiramiz


            MainPage = new NavigationPage( new UsersListPage());
        }

        private void InitUsers()
        {
            for(int i=1;i<=10;i++)
            {
                Database.SaveUserAsync
                    (
                        new UserModel() { Name = "User" + i,
                                           Email = "fsdf"
                                        }
                    );
            }
        }

        // database property
        public static UsersDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new UsersDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UsersDB.db3"));
                }

                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }




    }
}
