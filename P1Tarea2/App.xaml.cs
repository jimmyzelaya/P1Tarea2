using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P1Tarea2
{
    public partial class App : Application
    {

        static Controllers.DBPersonas dbPersonas;

        public static Controllers.DBPersonas Dbpersonas
        {
            get
            {
                if (dbPersonas == null)
                {
                    var PathApp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    var DBName = Models.Configuraciones.DBname;
                    var PathFull = Path.Combine(PathApp, DBName);

                    dbPersonas = new Controllers.DBPersonas(PathFull);
                }
                return dbPersonas;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
