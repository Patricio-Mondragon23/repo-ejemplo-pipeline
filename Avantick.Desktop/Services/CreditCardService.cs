using System.Linq;

namespace Avantick.Desktop.Services
{
    public class CreditCardService : ICreditCardService
    {

        //ISC: Valida si la tarjeta de crédito 
        // tiene solo digitos
        // si tiene 2 digitos seguidos no aplica
        // si la sumatoria se divide entre 10 y da 0 esta bien
        //https://es.wikipedia.org/wiki/Algoritmo_de_Luhn
        public bool ValidateLuhn(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return false;
            var d = new string(number.Where(char.IsDigit).ToArray());
            int sum = 0; bool alt = false;
            for (int i = d.Length - 1; i >= 0; i--)
            {
                int n = d[i] - '0';
                if (alt) { n *= 2; if (n > 9) n -= 9; }
                sum += n; alt = !alt;
            }
            return sum % 10 == 0;
        }
        public string Mask(string number)
        {
            var d = new string(number.Where(char.IsDigit).ToArray());
            if (d.Length < 4) return "****";
            return $"**** **** **** {d[^4..]}";
        }
    }
}
