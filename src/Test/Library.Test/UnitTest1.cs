using NUnit.Framework;
using Telegram;

namespace Library.Test
{
    public class Tests
    {
        [Test]
        public void Test()
        {   
            Category HabilitadoMetales = new Category("HabilitadoMetales","Poseehabilitación");
            Ratings OfRecurrente = new Ratings("Recurrente", "OfRecurrente");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer(OfRecurrente, HabilitadoMetales, "Tipo", "Metal", 200, Toneladas, "dirección",2000);
            Assert.AreEqual(OfRecurrente,Metal.Ratings);
        }
    }
}