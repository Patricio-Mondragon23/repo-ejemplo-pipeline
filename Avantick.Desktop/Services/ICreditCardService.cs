namespace Avantick.Desktop.Services
{
    public interface ICreditCardService
    {
        bool ValidateLuhn(string number);
        string Mask(string number);
    }
}
