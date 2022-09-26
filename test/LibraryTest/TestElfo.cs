using Library;

namespace Test.Library;


    [TestFixture]
    public class TestElfo
    {
        [Test]

        public void CrearElfoNameCorrecto()
        {
            string nameEsperado = "Tom";
            Elfo tom = new Elfo("Tom");
            Assert.AreEqual(nameEsperado,tom.Name);
        }
        // En este test creamos un elfo con nombre correcto, esperando que el nombre sea igual a nameEsperado.
        [Test]
        public void CrearElfoNameVacio()
        {
            string nameEsperado = null;
            Elfo tom = new Elfo("");
            Assert.AreEqual(nameEsperado, tom.Name);
        }
        // En este test creamos un elfo con nombre inválido, esperando que el nombre sea nulo.
         [Test]
        public void CrearElfoNameEspaciosEnBlanco()
        {
            string nameEsperado = null;
            Elfo tom = new Elfo("     ");
            Assert.AreEqual(nameEsperado, tom.Name);
        }
        // En este test creamos un elfo con nombre inválido, esperando que el nombre sea nulo.
         [Test]
        public void CrearElfoNameNulo()
        {
            string nameEsperado = null;
            Elfo tom = new Elfo(null);
            Assert.AreEqual(nameEsperado, tom.Name);
        }
        // En este test creamos un elfo con nombre inválido, esperando que el nombre sea nulo.
        [Test]
        public void CrearElfoNombrSoloSignos()
        {
            string nameEsperado = null;
            Elfo tom = new Elfo("!?#$%&");
            Assert.AreEqual(nameEsperado, tom.Name);

        }
        // En este test creamos un elfo con nombre inválido, esperando que el nombre sea nulo.
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
        // En este test creamos un arma y se la equipamos a un elfo con nombre válido. Esperamos que el arma equipada por el elfo sea igual a daga.
        [Test]
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
            Assert.IsFalse(tom.ArmaEquipada == daga);
        }
        // En este test creamos un arma y se la equipamos a un elfo con nombre válido, luego la desequipamos. Esperamos que el arma equipada por el elfo no sea igual a daga.
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
        // En este test creamos una armadura y se la equipamos a un elfo con nombre válido. Esperamos que la armadura equipada por el elfo contenga a armadura.
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
            // En este test creamos una armadura y se la equipamos a un elfo con nombre válido, luego la desequipamos. Esperamos que la armadura equipada por el elfo no contenga a armadura.
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
        // En este test creamos un arma, una armadura y dos elfos, todos válidos. Luego hacemos que el elfo con el arma ataque al elfo con la armadura y esperamos que la vida del elfo atacado sea 50.
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
        // En este test creamos un arma y dos elfos, todos válidos. Luego hacemos que el elfo con el arma ataque al otro elfo y esperamos que la vida del elfo atacado sea 20.
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
        // En este test creamos dos elfos, ambos válidos. Luego hacemos que un elfo ataque al otro elfo y esperamos que la vida del elfo atacado sea 90.
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
        // En este test creamos dos elfos, ambos válidos. Luego hacemos que un elfo ataque al otro elfo y esperamos que la vida del elfo atacado sea 100.
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
            //Assert.AreEqual(-10, john.Vida);
            Assert.AreEqual(0, john.Vida);

        }
        // En este test creamos un arma y dos elfos, todos válidos. Luego hacemos que el elfo con arma ataque al otro elfo y esperamos que la vida del elfo atacado sea 0.
    }
