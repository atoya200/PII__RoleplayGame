using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{
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
        // En este test creamos una armadura con un nombre correcto, esperando que nameEsperado sea igual que el nombre de armadura.
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
        // En este test creamos una armadura con un nombre inválido, esperando que el nombre de la armadura sea nulo.
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
        // En este test creamos una armadura con un nombre inválido, esperando que el nombre de la armadura sea nulo.
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
        // En este test creamos una armadura con un nombre inválido, esperando que el nombre de la armadura sea nulo.
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
        // En este test creamos una armadura con un nombre nulo, esperando que el nombre de la armadura sea nulo.

        // Pruebas de la descripción de la Ropa.

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
        // En este test creamos una armadura con un descripción válida, esperando que la descripción de la armadura sea igual a descripcionEsperada.
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
        // En este test creamos una armadura con un descripción inválido, esperando que la descripción de la armadura sea nula.
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
        // En este test creamos una armadura con un descripción inválido, esperando que la descripción de la armadura sea nula.

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
        // En este test creamos una armadura con un descripción inválido, esperando que la descripción de la armadura sea nula.

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
        // En este test creamos una armadura con un descripción inválido, esperando que la descripción de la armadura sea nula.

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
        // En este test creamos una armadura con defensa correcta, esperando que la defensa de la armadura sea igual a produccionEsperada.

        [Test]
        public void DefensaMenorACero()
        {
            // Configuración.
            int proteccionEsperada = 0;
            // Comportamiento.
            Ropa armadura = new Ropa("Armadura de Bronce", "Forjada por los enanos hace siglos", 0, -1111);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, armadura.Defensa);
        }
        // En este test creamos una armadura con defensa inválida, esperando que la defensa de la armadura sea nula.

    }
}