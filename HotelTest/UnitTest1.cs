using NUnit.Framework;
using HotelApp;
using System;

namespace HotelTest
{
    [TestFixture]
    public class Tests
    {


        [Test]
        public void CalcularPrecio_Cliente_VIP_AplicaDescuento()
        {
            var reserva = new h1 { v = true, d = 2, t = 1 };
            decimal resultado = reserva.procesar();
            // Precio base 100 - 15% VIP = 85
            Assert.That(resultado, Is.LessThan(100m));
        }

        [Test]
        public void CalcularPrecio_EstanciaLarga_AplicaDescuento()
        {
            var reserva = new h1 { t = 2, d = 10, v = false, b = 0 };
            decimal resultado = reserva.procesar();
            // Tu código aplica un 5% extra por estancia larga: (75 * 10) - 5% = 712.5
            Assert.That(resultado, Is.EqualTo(712.5m));
        }

        [Test]
        public void CalcularPrecio_ClienteVIP_Y_EstanciaLarga_AplicaAmbosDescuentos()
        {
            var reserva = new h1 { t = 3, d = 15, v = true };
            decimal resultado = reserva.procesar();
            decimal precioBase = 2250m; // 150 * 15
            Assert.That(resultado, Is.LessThan(precioBase));
        }



        // 1. Test para habitación Individual (Tarifa 50€)
        [Test]
        public void Test_TarifaIndividual_Correcta()
        {
            var h = new h1 { t = 1, d = 2 }; // 2 noches
            // 50 * 2 = 100
            Assert.That(h.procesar(), Is.EqualTo(100m));
        }

        // 2. Test para habitación Suite (Tarifa 150€)
        [Test]
        public void Test_TarifaSuite_Correcta()
        {
            var h = new h1 { t = 3, d = 1 }; // 1 noche
            // 150 * 1 = 150
            Assert.That(h.procesar(), Is.EqualTo(150m));
        }

        // 3. Test para excepción de días negativos
        [Test]
        public void Test_DiasNegativos_LanzaExcepcion()
        {
            var h = new h1 { t = 2, d = -5 };
            // Usamos Exception genérica porque es la que lanza tu código .cs
            Assert.Throws<Exception>(() => h.procesar());
        }
    }
}