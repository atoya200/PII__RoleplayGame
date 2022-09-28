using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{

    [TestFixture]
    public class TestArma
    {
        // Conjunto de test sobre el name del arma.
        // En este test creamos un arma con un nombre correcto, esperando que nameEsperado sea igual que el nombre de espada.
        [Test]
        public void ArmaNameCorrecto()
        {
            // Configuración.
            string nameEsperado = "Espada del rey Arturo";
            // Comportamiento.
            Arma espada = new Arma("Espada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }

        // En este test creamos un arma con un nombre vacío, esperando que el nombre de espada sea nulo.
        [Test]
        public void ArmaNameVacio()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Arma espada = new Arma("", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }

        // En este test creamos un arma con un nombre vacío, esperando que el nombre de espada sea nulo.
        [Test]
        public void ArmaNameEspaciosEnBlanco()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Arma espada = new Arma("   ", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }

        // En este test creamos un arma con un nombre inválido, esperando que el nombre de espada sea nulo.
        [Test]
        public void ArmaNameSoloConSignos()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Arma espada = new Arma("--.-.-=)", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }
        
        // En este test creamos un arma con un nombre nulo, esperando que el nombre de espada sea nulo.
        [Test]
        public void ArmaNameNulo()
        {
            // Configuración.
            string nameEsperado = null;
            // Comportamiento.
            Arma espada = new Arma(null, "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
            // Comprobación.
            Assert.AreEqual(nameEsperado, espada.Name);
        }
        
        // Pruebas de la descripción del arma.
        // En este test creamos un arma con descripción correcta, esperando que la descripción del arma sea igual a descripcionEsperada.
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

        // En este test creamos un arma con descripción vacía, esperando que la descripción del arma sea nula.
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
        
        // En este test creamos un arma con descripción vacía, esperando que la descripción del arma sea nula.
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

        // En este test creamos un arma con descripción nula, esperando que la descripción del arma sea nula.
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
        
        // En este test creamos un arma con descripción nula, esperando que la descripción del arma sea nula.
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
        // En este test creamos un arma con ataque válido, esperando que el daño sea dañoEsperado.
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
        
        // En este test creamos un arma con ataque inválido, esperando que el daño sea nulo.
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
        // En este test creamos un arma con defensa válido, esperando que la defensa sea proteccionEsperada.
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
        
        // En este test creamos un arma con defensa válido, esperando que la defensa sea nula.
        [Test]
        public void DefensaMenorACero()
        {
            // Configuración.
            int proteccionEsperada = 0;
            // Comportamiento.
            Arma espada = new Arma("Espada del Rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 0, -1111);
            // Comprobación.
            Assert.AreEqual(proteccionEsperada, espada.Defensa);
        }


    }
}