using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{
    //Falta terminar cada uno de estos casos de prueba
    [TestFixture]
    public class TestArma
    {
        // Conjunto de test sobre el nombre del arma.
        [Test]
        public void ArmaNombreCorrecto()
        {
            // Configuración.
            string nombreEsperado = "Espada del rey Arturo";
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nombreEsperado, espada.Name);
        }
        [Test]
        public void ArmaNombreVacio()
        {
            // Configuración.
            string nombreEsperado = null;
            // Comportamiento.
            Arma espada = new Arma("", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nombreEsperado, espada.Name);
        }
        [Test]
        public void ArmaNombreEspaciosEnBlanco()
        {
            // Configuración.
            string nombreEsperado = null;
            // Comportamiento.
            Arma espada = new Arma("   ", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nombreEsperado, espada.Name);
        }

        [Test]
        public void ArmaNombreSoloConSignos()
        {
            // Configuración.
            string nombreEsperado = null;
            // Comportamiento.
            Arma espada = new Arma("--.-.-=)", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nombreEsperado, espada.Name);
        }

        [Test]
        public void ArmaNombreNulo()
        {
            // Configuración.
            string nombreEsperado = null;
            // Comportamiento.
            Arma espada = new Arma(null, "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nombreEsperado, espada.Name);
        }

        // Pruebas de la descripción del arma.

 [Test]
        public void ArmaDescripcionCorrecta()
        {
            // Configuración.
            string descripcionEsperada = "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas";
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }
        [Test]
        public void ArmaDescripcionVacia()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", "", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }
        [Test]
        public void ArmaDescripcionEspaciosEnBlanco()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", "  ", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }

        [Test]
        public void ArmaDescripcionSoloConSignos()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", "---=)", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }

        [Test]
        public void ArmaDescripcionNula()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", null, 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }

        // Prueba con ataque.
        [Test]
        public void AtaqueCorrecto()
        {
            // Configuración.
            int dañoEsperado = 40;
            // Comportamiento.
            Arma espada = new Arma("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(dañoEsperado, espada.Ataque);
        }

        [Test]
        public void AtaqueMenorACero()
        {
            // Configuración.
            int dañoEsperado = 0;
            // Comportamiento.
            Arma espada = new Arma("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", -1111, 0);
            // Comprobación.
            Assert.AreEqual(dañoEsperado, espada.Ataque);
        }

        // Prueba con defensa.
        [Test]
        public void DefensaCorrecta()
        {
            // Configuración.
            int proteccionEsperada = 60;
            // Comportamiento.
            Arma espada = new Arma("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 0, 60);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, espada.Defensa);
        }

        [Test]
        public void DefensaMenorACero()
        {
            // Configuración.
            int proteccionEsperada = 0;
            // Comportamiento.
            Arma espada = new Arma("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 0,-1111);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, espada.Defensa);
        }

    }
}