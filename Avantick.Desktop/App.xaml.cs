using System.Windows;
using Avantick.Desktop.Views;

namespace Avantick.Desktop
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var login = new LoginWindow();
            this.MainWindow = login;
            login.Show();
        }
    }
}
