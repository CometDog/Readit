using Readit.View;
using Xamarin.Forms;

namespace Readit
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage();
        }

        protected override void OnStart()
        {
            MainPage.Navigation.PushAsync(new PostView());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}