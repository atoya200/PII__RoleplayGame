using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{
    [TestFixture]
    public class TestElementoMagico
    {
        // Conjunto de test sobre el name del elemento mágico.
        [Test]
        public void ElementoMagicoNameCorrecto()
        {
            // Configuración.
            string nameEsperado = "Espada del rey Arturo";
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }
        [Test]
        public void ElementoMagicoNameVacio()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }
        [Test]
        public void ElementoMagicoNameEspaciosEnBlanco()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("   ", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }

        [Test]
        public void ElementoMagicoNameSoloConSignos()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("--.-.-=)", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }

        [Test]
        public void ElementoMagicoNameNulo()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico(null, "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }

        // Pruebas de la descripción del elemento mágico.

 [Test]
        public void ElementoMagicoDescripcionCorrecta()
        {
            // Configuración.
            string descripcionEsperada = "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas";
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }
        [Test]
        public void ElementoMagicoDescripcionVacia()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del rey Arturo", "", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }
        [Test]
        public void ElementoMagicoDescripcionEspaciosEnBlanco()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del rey Arturo", "  ", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }

        [Test]
        public void ElementoMagicoDescripcionSoloConSignos()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del rey Arturo", "---=)", 40, 0);
            // Comprobación.
            Assert.AreEqual(descripcionEsperada, espada.Descripcion);
        }

        [Test]
        public void ElementoMagicoDescripcionNula()
        {
            // Configuración.
            string descripcionEsperada = null;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del rey Arturo", null, 40, 0);
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
            ElementoMagico espada = new ElementoMagico("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(dañoEsperado, espada.Ataque);
        }

        [Test]
        public void AtaqueMenorACero()
        {
            // Configuración.
            int dañoEsperado = 0;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", -1111, 0);
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
            ElementoMagico espada = new ElementoMagico("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 0, 60);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, espada.Defensa);
        }

        [Test]
        public void DefensaMenorACero()
        {
            // Configuración.
            int proteccionEsperada = 0;
            // Comportamiento.
            ElementoMagico espada = new ElementoMagico("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 0,-1111);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, espada.Defensa);
        }

       

    }
}