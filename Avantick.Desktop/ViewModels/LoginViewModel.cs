namespace Avantick.Desktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string? _user;
        public string? User { get => _user; set => Set(ref _user, value); }

        private string? _password;
        public string? Password { get => _password; set => Set(ref _password, value); }
    }
}
