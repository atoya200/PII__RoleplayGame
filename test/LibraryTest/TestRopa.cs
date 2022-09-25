using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{
    //Falta terminar cada uno de estos casos de prueba
    [TestFixture]
    public class TestRopa
    {
        // Conjunto de test sobre el name de la Ropa.
        [Test]
        public void RopaNameCorrecto()
        {
            // Configuración.
            string nameEsperado = "Armadura de Bronce";
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "Forjada por los enanos hace siglos", 0, 25);
            // Comprobación.
            Assert.AreEqual(nameEsperado, armadura.Name);
        }
        [Test]
        public void RopaNameVacio()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Ropa armadura = new Ropa("", "Forjada por los enanos hace siglos", 0, 25);
            // Comprobación.
            Assert.AreEqual(nameEsperado, armadura.Name);
        }
        [Test]
        public void RopaNameEspaciosEnBlanco()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Ropa armadura = new Ropa("   ", "Forjada por los enanos hace siglos", 0, 25);
            // Comprobación.
            Assert.AreEqual(nameEsperado, armadura.Name);
        }

        [Test]
        public void RopaNameSoloConSignos()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Ropa armadura = new Ropa("--.-.-=)", "Forjada por los enanos hace siglos", 0, 25);
            // Comprobación.
            Assert.AreEqual(nameEsperado, armadura.Name);
        }

        [Test]
        public void RopaNameNulo()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Ropa armadura = new Ropa(null, "Forjada por los enanos hace siglos", 0, 25);
            // Comprobación.
            Assert.AreEqual(nameEsperado, armadura.Name);
        }

        // Pruebas de la descripción del Ropa.

 [Test]
        public void RopaDescripcionCorrecta()
        {
            // Configuración.
            string descripcionEsperada = "Forjada por los enanos hace siglos";
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "Forjada por los enanos hace siglos", 0, 25);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, armadura.Descripcion);
        }
        [Test]
        public void RopaDescripcionVacia()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "", 0, 25);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, armadura.Descripcion);
        }
        [Test]
        public void RopaDescripcionEspaciosEnBlanco()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "  ", 0, 25);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, armadura.Descripcion);
        }

        [Test]
        public void RopaDescripcionSoloConSignos()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "---=)", 0, 25);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, armadura.Descripcion);
        }

        [Test]
        public void RopaDescripcionNula()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", null, 0, 25);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, armadura.Descripcion);
        }

        // Prueba con defensa.
        [Test]
        public void DefensaCorrecta()
        {
            // Configuración.
            int proteccionEsperada = 60;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "Forjada por los enanos hace siglos", 0, 60);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, armadura.Defensa);
        }

        [Test]
        public void DefensaMenorACero()
        {
            // Configuración.
            int proteccionEsperada = 0;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "Forjada por los enanos hace siglos", 0,-1111);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, armadura.Defensa);
        }

    }
}