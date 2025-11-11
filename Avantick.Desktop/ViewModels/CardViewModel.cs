namespace Avantick.Desktop.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        private string? _cardNumber;
        public string? CardNumber { get => _cardNumber; set => Set(ref _cardNumber, value); }

        private string _result = string.Empty;
        public string Result { get => _result; set => Set(ref _result, value); }
    }
}
