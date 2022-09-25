using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{
    [TestFixture]
    public class TestMago
    {
        [Test]

        public void CrearMagoNameCorrecto()
        {
            string nombreEsperado = "Jason";
            Mago jason = new Mago("Jason");
            Assert.AreEqual(nombreEsperado, jason.Name);
        }
        [Test]
        public void CrearMagoNameVacio()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("");
            Assert.AreEqual(nombreEsperado, jason.Name);
        }
        [Test]
        public void CrearMagoNameEspaciosEnBlanco()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("     ");
            Assert.AreEqual(nombreEsperado, jason.Name);
        }

        [Test]
        public void CrearMagoNameNulo()
        {
            string nombreEsperado = null;
            Mago jason = new Mago(null);
            Assert.AreEqual(nombreEsperado, jason.Name);
        }

        [Test]
        public void CrearMagoNombrSoloSignos()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("&/$#&");
            Assert.AreEqual(nombreEsperado, jason.Name);

        }
        [Test]
        public void RopaEquipada()
        {
            // Configuración.
            Ropa armadura = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Ropa armadura1 = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarRopa(armadura);
            // Comportamiento.
            jason.EquiparRopa(armadura);
            // Comprobación.
            Assert.IsTrue(jason.RopaEquipada.Contains(armadura));

        }
        [Test]
        public void DesequiparRopa()
        {
            // Configuración.
            Ropa armadura = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Ropa armadura1 = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarRopa(armadura);
            jason.EquiparRopa(armadura);
            // Comportamiento.
            jason.QuitarRopa(armadura);
            // Comprobación.
            Assert.IsFalse(jason.RopaEquipada.Contains(armadura));

        }

        [Test]
        public void EquiparArma()
        {
            // Configuración.
            Arma baston = new Arma("Bastón del Rey Mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 400, 0);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarArma(baston);
            // Comportamiento.
            jason.EquiparArma(baston);
            // Comprobación.
            Assert.AreEqual(baston, jason.ArmaEquipada);

        }
        [Test]
        public void DesequiparArma()
        {
            // Configuración.
            Arma baston = new Arma("Bastón del Rey Mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 400, 0);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarArma(baston);
            jason.EquiparArma(baston);
            // Comportamiento.
            jason.DesequiparArma();
            // Comprobación.
            Assert.IsFalse(baston == jason.ArmaEquipada);
        }

        [Test]
        public void EquiparLibro()
        {
            // Configuración.
            LibroHechizos grimorio = new LibroHechizos("Grimorio del Rey Mago", "Uno de los tres grimorios legandarios");
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarLibro(grimorio);
            // Comportamiento.
            jason.EquiparLibro(grimorio);
            // Comprobación.
            Assert.AreEqual(grimorio, jason.LibroDeHechizosEquipado);

        }
        [Test]
        public void DesequiparLibro()
        {
            // Configuración.
            LibroHechizos grimorio = new LibroHechizos("Grimorio del Rey Mago", "Uno de los tres grimorios legandarios");
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarLibro(grimorio);
            jason.EquiparLibro(grimorio);
            // Comportamiento.
            jason.DesequiparLibro();
            // Comprobación.
            Assert.IsFalse(grimorio == jason.LibroDeHechizosEquipado);
        }

        [Test]
        public void EquiparelEmentosMagicos()
        {
            // Configuración.
            ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 30, 0);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarElementoMagico(runa);
            // Comportamiento.
            jason.EquiparElementoMagico(runa);
            // Comprobación.
            Assert.IsTrue(jason.ElementosMagicosEquipados.Contains(runa));

        }
        [Test]
        public void DesequiparElementosMagicos()
        {
            // Configuración.
            ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 30, 0);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarElementoMagico(runa);
            jason.EquiparElementoMagico(runa);
            // Comportamiento.
            jason.DesequiparElementoMagico(runa);
            // Comprobación.
            Assert.IsFalse(jason.ElementosMagicosEquipados.Contains(runa));

        }


        [Test]
        public void AtacarConProteccion()
        {
            // Configuración.
            Arma baston = new Arma("Bastón del rey mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
            Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            john.Inventario.AgregarRopa(tunica);
            tom.Inventario.AgregarArma(baston);
            tom.EquiparArma(baston);
            john.EquiparRopa(tunica);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(80, john.Vida);

        }

        [Test]
        public void AtacarSinProteccion()
        {
            // Configuración.
            Arma baston = new Arma("Bastón del rey mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            tom.Inventario.AgregarArma(baston);
            tom.EquiparArma(baston);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(50, john.Vida);

        }
        [Test]
        public void AtacarSinArmaSinProteccion()
        {
            // Configuración.
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(90, john.Vida);

        }

        [Test]
        public void AtacarSinArmaConProteccion()
        {
            // Configuración.
            Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            john.Inventario.AgregarRopa(tunica);
            john.EquiparRopa(tunica);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(100, john.Vida);

        }

        [Test]
        public void AtacarConHechizoConProteccion()
        {
            // Configuración.
            HechizoAtaque bolaFuego = new HechizoAtaque("Bola de fuego", 80);
            LibroHechizos grimorioAzul = new LibroHechizos("Grimorio rojo", "Libro del mago");
            grimorioAzul.AgregarHechizo(bolaFuego);
            Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            john.Inventario.AgregarRopa(tunica);
            john.EquiparRopa(tunica);
            tom.Inventario.AgregarLibro(grimorioAzul);
            tom.EquiparLibro(grimorioAzul);
            // Comportamiento.
            tom.AtacarConHechizo(john, bolaFuego);
            // Comprobación.
            Assert.AreEqual(50, john.Vida);

        }

        [Test]
        public void AtacarConHechizoSinProteccion()
        {
            // Configuración.
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            HechizoAtaque bolaFuego = new HechizoAtaque("Bola de fuego", 80);
            LibroHechizos grimorioAzul = new LibroHechizos("Grimorio rojo", "Libro del mago");
            grimorioAzul.AgregarHechizo(bolaFuego);
            tom.Inventario.AgregarLibro(grimorioAzul);
            tom.EquiparLibro(grimorioAzul);
            // Comportamiento.
            tom.AtacarConHechizo(john, bolaFuego);
            // Comprobación.
            Assert.AreEqual(20, john.Vida);

        }


        public void AtacarConElemtentosMagicosConProteccion()
        {
            // Configuración.
            ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 47, 0);
            Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            john.Inventario.AgregarRopa(tunica);
            john.EquiparRopa(tunica);
            tom.Inventario.AgregarElementoMagico(runa);
            tom.EquiparElementoMagico(runa);
            // Comportamiento.
            tom.AtacarConElementoMagico(john, runa);
            // Comprobación.
            Assert.AreEqual(73, john.Vida);

        }

        [Test]
        public void AtacarConElemtentoMagicoSinProteccion()
        {
            // Configuración.
            ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 47, 0);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            tom.Inventario.AgregarElementoMagico(runa);
            tom.EquiparElementoMagico(runa);
            // Comportamiento.
            tom.AtacarConElementoMagico(john, runa);
            // Comprobación.
            Assert.AreEqual(53, john.Vida);

        }


        [Test]
        public void AtaqueDeMuerteConElemtentoMagicoSinProteccion()
        {
            // Configuración.
            ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 100, 0);
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            tom.Inventario.AgregarElementoMagico(runa);
            tom.EquiparElementoMagico(runa);
            // Comportamiento.
            tom.AtacarConElementoMagico(john, runa);
            // Comprobación.
            Assert.AreEqual(0, john.Vida);

        }

        [Test]
        public void AtaqueDeMuerteConHechizo()
        {
            // Configuración.
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            HechizoAtaque bolaFuego = new HechizoAtaque("Bola de fuego", 100);
            LibroHechizos grimorioAzul = new LibroHechizos("Grimorio rojo", "Libro del mago");
            grimorioAzul.AgregarHechizo(bolaFuego);
            tom.Inventario.AgregarLibro(grimorioAzul);
            tom.EquiparLibro(grimorioAzul);
            // Comportamiento.
            tom.AtacarConHechizo(john, bolaFuego);
            // Comprobación.
            Assert.AreEqual(0, john.Vida);

        }
        [Test]
        public void AtaqueDeMuerte()
        {
            // Configuración.
            Mago tom = new Mago("Tom");
            Mago john = new Mago("John");
            Arma baston = new Arma("Bastón del rey mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 100, 0);
            tom.Inventario.AgregarArma(baston);
            tom.EquiparArma(baston);
            // Comportamiento.
            tom.Atacar(john);
            // Comprobación.
            Assert.AreEqual(0, john.Vida);
        }

    }
}
