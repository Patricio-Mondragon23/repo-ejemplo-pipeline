using System.Windows;
using Avantick.Desktop.ViewModels;

namespace Avantick.Desktop.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = (Pwd.Password ?? string.Empty);
                if (vm.User == "demo@avantick" && vm.Password == "Password123")
                {
                    var next = new CardWindow();
                    next.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
