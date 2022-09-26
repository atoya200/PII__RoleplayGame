using Library;
namespace Test.Library;


[TestFixture]
    public class TestEnano
    {

        [Test]
        public void CrearEnanoNameCorrecto()
        {
            string nameEsperado = "Golf";
            Enano golf = new Enano("Golf");
            Assert.AreEqual(nameEsperado, golf.Name);

        }
        // En este test creamos un enano con nombre correcto, esperando que el nombre sea igual a nameEsperado.
        [Test]
        public void CrearEnanoNameVacio()
        {
            string nameEsperado = null;
            Enano golf = new Enano("");
            Assert.AreEqual(nameEsperado, golf.Name);
        }
        // En este test creamos un enano con nombre inválido, esperando que el nombre sea null.
         [Test]
        public void CrearEnanoNameEspaciosEnBlanco()
        {
            string nameEsperado = null;
            Enano golf = new Enano("    ");
            Assert.AreEqual(nameEsperado, golf.Name);
        }
        // En este test creamos un enano con nombre inválido, esperando que el nombre sea null.
         [Test]
        public void CrearEnanoNameNulo()
        {
            string nameEsperado = null;
            Enano golf = new Enano(null);
            Assert.AreEqual(nameEsperado, golf.Name);
        }
        // En este test creamos un enano con nombre inválido, esperando que el nombre sea null.
        [Test]
        public void CrearEnanoNombrSoloSignos()
        {
            string nameEsperado = null;
            Enano golf = new Enano("-_?)=)");
            Assert.AreEqual(nameEsperado, golf.Name);

        }
        // En este test creamos un enano con nombre inválido, esperando que el nombre sea null.
         [Test]
        public void CrearEnanoNameConEspaciosAtrasYAdelante()
        {
            string nameEsperado = "d d";
            Enano golf = new Enano("     d d ");
            Assert.AreEqual(nameEsperado, golf.Name);
        }
        // En este test creamos un enano con nombre inválido, esperando que el nombre sea null.
        [Test]
        public void ArmaEquipada()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarArma(maso);
            // Comportamiento.
            golf.EquiparArma(maso);
            // Comprobación.
            Assert.AreEqual(maso, golf.ArmaEquipada);
        }
        // En este test creamos un arma y se la equipamos a un enano con nombre válido. Esperamos que el arma equipada por el enano sea igual a maso.
        [Test]
        public void DesequiparArma()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarArma(maso);
            golf.EquiparArma(maso);
            // Comportamiento.
            golf.DesequiparArma();
            // Comprobación.
            Assert.IsFalse(golf.ArmaEquipada == maso);

        }
        // En este test creamos un arma y se la equipamos a un enano con nombre válido, luego la desequipamos. Esperamos que el arma equipada por el enano sea null.
        [Test]
        public void RopaEquipada()
        {
            // Configuración.
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Ropa armadura1 = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarRopa(armadura);
            // Comportamiento.
            golf.EquiparRopa(armadura);
            // Comprobación.
            Assert.IsTrue(golf.RopaEquipada.Contains(armadura));

        }
        // En este test creamos una armadura y se la equipamos a un enano con nombre válido. Esperamos que la armadura equipada por el enano contenga a armadura.
        [Test]
        public void QuitarRopa()
        {
            // Configuración.
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Ropa armadura1 = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarRopa(armadura);
            golf.EquiparRopa(armadura);
            // Comportamiento.
            golf.QuitarRopa(armadura);
            // Comprobación.
            Assert.IsFalse(golf.RopaEquipada.Contains(armadura));

        }
        // En este test creamos una armadura y se la equipamos a un enano con nombre válido. Esperamos que la armadura equipada por el enano no contenga a armadura.
        [Test]
        public void AtacarConProteccion()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            rud.Inventario.AgregarRopa(armadura);
            golf.Inventario.AgregarArma(maso);
            golf.EquiparArma(maso);
            rud.EquiparRopa(armadura);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(80, rud.Vida);

        }
        // En este test creamos un arma, una armadura y dos enanos, todos válidos. Luego hacemos que el enano con el arma ataque al enano con la armadura y esperamos que la vida del enano atacado sea 80.
        [Test]
        public void AtacarSinProteccion()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            golf.Inventario.AgregarArma(maso);
            golf.EquiparArma(maso);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(50, rud.Vida);

        }
        // En este test creamos un arma y dos enanos, todos válidos. Luego hacemos que el enano con el arma ataque al otro enano y esperamos que la vida del enano atacado sea 50.
        [Test]
        public void AtacarSinArmaSinProteccion()
        {
            // Configuración.
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(90, rud.Vida);

        }
        // En este test creamos dos enanos, ambos válidos. Luego hacemos que un enano ataque al otro enano y esperamos que la vida del enano atacado sea 90.
        [Test]
        public void AtacarSinArmaConProteccion()
        {
            // Configuración.
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            rud.Inventario.AgregarRopa(armadura);
            rud.EquiparRopa(armadura);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(100, rud.Vida);

        }
        // En este test creamos dos enanos, ambos válidos. Luego hacemos que un enano ataque al otro enano y esperamos que la vida del enano atacado sea 100.
        [Test]
        public void AtaqueDeMuerte()
        {
            // Configuración.
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
            golf.Inventario.AgregarArma(maso);
            golf.EquiparArma(maso);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(0, rud.Vida);

        }
        // En este test creamos un arma y dos enanos, todos válidos. Luego hacemos que el enano con arma ataque al otro enano y esperamos que la vida del enano atacado sea 0.
    }