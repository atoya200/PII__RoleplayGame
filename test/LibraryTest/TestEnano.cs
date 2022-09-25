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
        
        [Test]
        public void CrearEnanoNameVacio()
        {
            string nameEsperado = null;
            Enano golf = new Enano("");
            Assert.AreEqual(nameEsperado, golf.Name);
        }
         [Test]
        public void CrearEnanoNameEspaciosEnBlanco()
        {
            string nameEsperado = null;
            Enano golf = new Enano("    ");
            Assert.AreEqual(nameEsperado, golf.Name);
        }

         [Test]
        public void CrearEnanoNameNulo()
        {
            string nameEsperado = null;
            Enano golf = new Enano(null);
            Assert.AreEqual(nameEsperado, golf.Name);
        }

        [Test]
        public void CrearEnanoNombrSoloSignos()
        {
            string nameEsperado = null;
            Enano golf = new Enano("-_?)=)");
            Assert.AreEqual(nameEsperado, golf.Name);

        }

         [Test]
        public void CrearEnanoNameConEspaciosAtrasYAdelante()
        {
            string nameEsperado = "d d";
            Enano golf = new Enano("     d d ");
            Assert.AreEqual(nameEsperado, golf.Name);
        }
        [Test]
        public void ArmaEquipada()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarElemento(maso);
            // Comportamiento.
            golf.EquiparArma(maso);
            // Comprobación.
            Assert.AreEqual(maso, golf.ArmaEquipada);

        }
        [Test]
        public void DesequiparArma()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarElemento(maso);
            golf.EquiparArma(maso);
            // Comportamiento.
            golf.DesequiparArma();
            // Comprobación.
            Assert.IsFalse(golf.ArmaEquipada == maso);

        }

        [Test]
        public void RopaEquipada()
        {
            // Configuración.
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Ropa armadura1 = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarElemento(armadura);
            // Comportamiento.
            golf.EquiparRopa(armadura);
            // Comprobación.
            Assert.IsTrue(golf.RopaEquipada.Contains(armadura));

        }
        [Test]
        public void QuitarRopa()
        {
            // Configuración.
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Ropa armadura1 = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            golf.Inventario.AgregarElemento(armadura);
            golf.EquiparRopa(armadura);
            // Comportamiento.
            golf.QuitarRopa(armadura);
            // Comprobación.
            Assert.IsFalse(golf.RopaEquipada.Contains(armadura));

        }

        [Test]
        public void AtacarConProteccion()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            rud.Inventario.AgregarElemento(armadura);
            golf.Inventario.AgregarElemento(maso);
            golf.EquiparArma(maso);
            rud.EquiparRopa(armadura);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(80, rud.Vida);

        }

        [Test]
        public void AtacarSinProteccion()
        {
            // Configuración.
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 40, 0);
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            golf.Inventario.AgregarElemento(maso);
            golf.EquiparArma(maso);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(50, rud.Vida);

        }
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

        [Test]
        public void AtacarSinArmaConProteccion()
        {
            // Configuración.
            Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            rud.Inventario.AgregarElemento(armadura);
            rud.EquiparRopa(armadura);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(100, rud.Vida);

        }
        [Test]
        public void AtaqueDeMuerte()
        {
            // Configuración.
            Enano golf = new Enano("Golf");
            Enano rud = new Enano("Rud");
            Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
            golf.Inventario.AgregarElemento(maso);
            golf.EquiparArma(maso);
            // Comportamiento.
            golf.Atacar(rud);
            // Comprobación.
            Assert.AreEqual(0, rud.Vida);

        }
    }