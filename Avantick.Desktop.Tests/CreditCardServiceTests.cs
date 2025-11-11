using NUnit.Framework;
using Avantick.Desktop.Services;

namespace Avantick.Desktop.Tests
{
    [TestFixture]
    public class CreditCardServiceTests
    {
        private CreditCardService _svc = null!;

        [SetUp] public void SetUp() => _svc = new CreditCardService();

        [TestCase("4111111111111111", true)]
        [TestCase("4242424242424242", true)]
        [TestCase("1234567812345678", false)]
        public void Luhn_Works(string num, bool expected)
        {
            Assert.That(_svc.ValidateLuhn(num), Is.EqualTo(expected));
        }

        [Test]
        public void Mask_ShowsLast4()
        {
            Assert.That(_svc.Mask("4111111111111111").EndsWith("1111"));
        }
    }
}
