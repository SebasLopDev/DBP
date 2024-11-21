using CurriculumAppD;
using Xamarin.Forms;

namespace CurriculumAppD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Envolver la MainPage en un NavigationPage
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
