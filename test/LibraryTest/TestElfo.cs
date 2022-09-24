using Library;

namespace Test.Library;


    [TestFixture]
    public class TestElfo
    {
        [Test]

        public void CrearElfoNombreCorrecto()
        {
            string nombreEsperado = "Tom";
            Elfo tom = new Elfo("Tom");
            Assert.AreEqual(nombreEsperado,tom.Nombre);
        }
        [Test]
        public void CrearElfoNombreVacio()
        {
            string nombreEsperado = null;
            Elfo tom = new Elfo("");
            Assert.AreEqual(nombreEsperado, tom.Nombre);
        }
         [Test]
        public void CrearElfoNombreEspaciosEnBlanco()
        {
            string nombreEsperado = null;
            Elfo tom = new Elfo("     ");
            Assert.AreEqual(nombreEsperado, tom.Nombre);
        }

         [Test]
        public void CrearElfoNombreNulo()
        {
            string nombreEsperado = null;
            Elfo tom = new Elfo(null);
            Assert.AreEqual(nombreEsperado, tom.Nombre);
        }

        [Test]
        public void CrearElfoNombrSoloSignos()
        {
            string nombreEsperado = null;
            Elfo tom = new Elfo("!?#$%&");
            Assert.AreEqual(nombreEsperado, tom.Nombre);

        }
        [Test]
        public void ArmaEquipada()
        {
            // Configuración.
            Arma daga = new Arma("Daga de Miraak", "Esta daga fue usada por el mismisimo Miraak para conquistar Solstheim", 70, 0);
            Elfo tom = new Elfo("Tom");
            tom.Inventario.AgregarArma(daga);
            // Comportamiento.
            tom.EquiparArma(daga);
            // Comprobación.
            Assert.AreEqual(daga, tom.ArmaEquipada);

        }

        public void DesequiparArma()
        {
            // Configuración.
            Arma daga = new Arma("Daga de Miraak", "Esta daga fue usada por el mismisimo Miraak para conquistar Solstheim", 70, 0);
            Elfo tom = new Elfo("Tom");
            tom.Inventario.AgregarArma(daga);
            tom.EquiparArma(daga);
            // Comportamiento.
            tom.DesequiparArma();
            // Comprobación.
            Assert.AreEqual(daga, tom.ArmaEquipada);
            // ?????????????
        }

        [Test]
        public void RopaEquipada()
        {
            // Configuración.
            Ropa armadura = new Ropa("Gabardina del Silver Shroud", "La gabardina que usaba el personaje de los comics", 0, 30);
            Ropa armadura1 = new Ropa("Gabardina del Silver Shroud", "La gabardina que usaba el personaje de los comics", 0, 30);
            Elfo tom = new Elfo("Tom");
            tom.Inventario.AgregarRopa(armadura);
            // Comportamiento.
            tom.EquiparRopa(armadura);
            // Comprobación.
            Assert.IsTrue(tom.RopaEquipada.Contains(armadura));

        }
        [Test]
        public void QuitarRopa()
        {
            // Configuración.
            Ropa armadura = new Ropa("Gabardina del Silver Shroud", "La gabardina que usaba el personaje de los comics", 0, 30);
            Ropa armadura1 = new Ropa("Gabardina del Silver Shroud", "La gabardina que usaba el personaje de los comics", 0, 30);
            Elfo tom = new Elfo("Tom");
            tom.Inventario.AgregarRopa(armadura);
            tom.EquiparRopa(armadura);
            // Comportamiento.
            tom.QuitarRopa(armadura);
            // Comprobación.
            Assert.IsFalse(tom.RopaEquipada.Contains(armadura));

        }

        [Test]
        public void AtacarConProteccion()
        {
            // Configuración.
            Arma daga = new Arma("Daga de Miraak", "Esta daga fue usada por el mismisimo Miraak para conquistar Solstheim", 70, 0);
            Ropa armadura = new Ropa("Gabardina del Silver Shroud", "La gabardina que usaba el personaje de los comics", 0, 30);
            Elfo tom = new Elfo("Tom");
            Elfo john = new Elfo("John");
            john.Inventario.AgregarRopa(armadura);
            tom.Inventario.AgregarArma(daga);
            tom.EquiparArma(daga);
            john.EquiparRopa(armadura);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(50, john.Vida);

        }

        [Test]
        public void AtacarSinProteccion()
        {
            // Configuración.
            Arma daga = new Arma("Daga de Miraak", "Esta daga fue usada por el mismisimo Miraak para conquistar Solstheim", 70, 0);
            Elfo tom = new Elfo("Tom");
            Elfo john = new Elfo("John");
            tom.Inventario.AgregarArma(daga);
            tom.EquiparArma(daga);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(20, john.Vida);

        }
        [Test]
        public void AtacarSinArmaSinProteccion()
        {
            // Configuración.
            Elfo tom = new Elfo("Tom");
            Elfo john = new Elfo("John");
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(90, john.Vida);

        }

        [Test]
        public void AtacarSinArmaConProteccion()
        {
            // Configuración.
            Ropa armadura = new Ropa("Gabardina del Silver Shroud", "La gabardina que usaba el personaje de los comics", 0, 30);
            Elfo tom = new Elfo("Tom");
            Elfo john = new Elfo("John");
            john.Inventario.AgregarRopa(armadura);
            john.EquiparRopa(armadura);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(100, john.Vida);

        }
        [Test]
        public void AtaqueDeMuerte()
        {
            // Configuración.
            Elfo tom = new Elfo("Tom");
            Elfo john = new Elfo("John");
            Arma daga = new Arma("Daga de Miraak", "Esta daga fue usada por el mismisimo Miraak para conquistar Solstheim", 100, 0);
            tom.Inventario.AgregarArma(daga);
            tom.EquiparArma(daga);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(-10, john.Vida);

        }
    }
