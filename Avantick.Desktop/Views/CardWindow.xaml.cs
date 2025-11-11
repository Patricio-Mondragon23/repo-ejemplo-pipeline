using System.Windows;
using Avantick.Desktop.ViewModels;
using Avantick.Desktop.Services;

namespace Avantick.Desktop.Views
{
    public partial class CardWindow : Window
    {
        private readonly ICreditCardService _svc;
        public CardWindow()
        {
            InitializeComponent();
            _svc = new CreditCardService();
            DataContext = new CardViewModel();
        }

        private void ValidateClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is CardViewModel vm)
            {
                if (!_svc.ValidateLuhn(vm.CardNumber ?? string.Empty))
                    vm.Result = "Tarjeta inválida";
                else
                    vm.Result = $"OK: {_svc.Mask(vm.CardNumber!)}";
            }
        }
    }
}
