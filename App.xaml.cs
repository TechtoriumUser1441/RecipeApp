using System;
using System.IO;
using RecipeApp.Data;
using Xamarin.Forms;

namespace RecipeApp
{
    public partial class App : Application
    {
        static RecipeDatabase database;

        // Create the database connection as a singleton.
        public static RecipeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecipeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RecipeApp.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}