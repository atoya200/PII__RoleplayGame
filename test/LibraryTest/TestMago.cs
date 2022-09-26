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
        // En este test creamos un mago con nombre correcto, esperando que el nombre sea igual a nameEsperado.
        [Test]
        public void CrearMagoNameVacio()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("");
            Assert.AreEqual(nombreEsperado, jason.Name);
        }
        // En este test creamos un mago con nombre inválido, esperando que el nombre sea nulo.
        [Test]
        public void CrearMagoNameEspaciosEnBlanco()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("     ");
            Assert.AreEqual(nombreEsperado, jason.Name);
        }
        // En este test creamos un mago con nombre inválido, esperando que el nombre sea nulo.
        [Test]
        public void CrearMagoNameNulo()
        {
            string nombreEsperado = null;
            Mago jason = new Mago(null);
            Assert.AreEqual(nombreEsperado, jason.Name);
        }
        // En este test creamos un mago con nombre inválido, esperando que el nombre sea nulo.
        [Test]
        public void CrearMagoNombrSoloSignos()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("&/$#&");
            Assert.AreEqual(nombreEsperado, jason.Name);

        }
        // En este test creamos un mago con nombre inválido, esperando que el nombre sea nulo.
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
        // En este test creamos una armadura y se la equipamos a un mago con nombre válido. Esperamos que la armadura equipada por el mago contenga a armadura.
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
        // En este test creamos una armadura y se la equipamos a un mago con nombre válido, luego la desequipamos. Esperamos que la armadura equipada por el mago no contenga a armadura.
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
        // En este test creamos un arma y se la equipamos a un mago con nombre válido. Esperamos que el arma equipada por el mago sea igual a baston.
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
        // En este test creamos un arma y se la equipamos a un mago con nombre válido, luego lo desequipamos. Esperamos que el arma equipada por el mago no sea igual a baston.
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
        // En este test creamos un libro y se lo equipamos a un mago con nombre válido. Esperamos que el libro equipado sea igual a grimorio.
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
        // En este test creamos un libro y se lo equipamos a un mago con nombre válido, luego lo desequipamos. Esperamos que el libro equipado no sea igual a grimorio.
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
        // En este test creamos un elemento mágico y se lo equipamos a un mago con nombre válido. Esperamos que elementos mágicos equipados contenga a runa.
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
        // En este test creamos un elemento mágico y se lo equipamos a un mago con nombre válido. Esperamos que elementos mágicos equipados no contenga a runa.

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
        // En este test creamos un arma, una armadura y dos magos, todos válidos. Luego hacemos que el mago con el arma ataque al mago con la armadura y esperamos que la vida del mago atacado sea 80.

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
        // En este test creamos un arma y dos magos, todos válidos. Luego hacemos que el mago con el arma ataque al otro mago y esperamos que la vida del mago atacado sea 50.
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
        // En este test creamos dos magos, todos válidos. Luego hacemos que un mago ataque al otro mago y esperamos que la vida del mago atacado sea 90.
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
        // En este test creamos una armadura y dos magos, todos válidos. Luego hacemos que un mago ataque al mago con armadura y esperamos que la vida del mago atacado sea 100.
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
        // En este test creamos un hechizo de ataque, un libro, una armadura y dos magos, todos válidos. Luego hacemos que el mago con el hechizo y el libro ataque al mago con armadura y esperamos que la vida del mago atacado sea 50.
        

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
        // En este test creamos un hechizo de ataque, un libro y dos magos, todos válidos. Luego hacemos que el mago con el hechizo y el libro ataque al otro mago y esperamos que la vida del mago atacado sea 20.

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
        // En este test creamos un elemento mágico, una armadura y dos magos, todos válidos. Luego hacemos que el mago con el elemento mágico ataque al mago con armadura y esperamos que la vida del mago atacado sea 73.

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
        // En este test creamos un elemento mágico y dos magos, todos válidos. Luego hacemos que el mago con el elemento mágico ataque al otro mago y esperamos que la vida del mago atacado sea 53.


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
        // En este test creamos un elemento mágico y dos magos, todos válidos. Luego hacemos que el mago con el elemento mágico ataque al otro mago y esperamos que la vida del mago atacado sea 0.

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
        // En este test creamos un hechizo de ataque, un libro y dos magos, todos válidos. Luego hacemos que el mago con el hechizo de ataque y el libro ataque al otro mago y esperamos que la vida del mago atacado sea 0.
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
        // En este test creamos un arma y dos magos, todos válidos. Luego hacemos que el mago con el arma y el libro ataque al otro mago y esperamos que la vida del mago atacado sea 0.

           [Test]
        public void AumetnarDefensaPeronsaje()
        {
            // Configuración.
            Mago tom = new Mago("Tom");
            Elfo john = new Elfo("John");
            HechizoDefensa pielDeAcero = new HechizoDefensa("Piel de acero", 20);
            LibroHechizos grimorioGris = new LibroHechizos("Grimorio gris", "Libro del mago");
            grimorioGris.AgregarHechizo(pielDeAcero);
            tom.Inventario.AgregarLibro(grimorioGris);
            tom.EquiparLibro(grimorioGris);
            // Comportamiento.
            tom.UsarHechizoDefensa(john, pielDeAcero);
            // Comprobación.
            Assert.AreEqual(20, john.Defensa);
        }
        // Con este test probamos que efectivamente se aumetna la defensa de un personaje con un hechizo de defensa.

        [Test]
        public void CurarPeronsaje()
        {
            // Configuración.
            Mago tom = new Mago("Tom");
            Elfo john = new Elfo("John");
            HechizoAtaque bolaFuego = new HechizoAtaque("Bola de fuego", 70);
            LibroHechizos grimorioAzul = new LibroHechizos("Grimorio rojo", "Libro del mago");
            grimorioAzul.AgregarHechizo(bolaFuego);
            tom.Inventario.AgregarLibro(grimorioAzul);
            tom.EquiparLibro(grimorioAzul);
            tom.AtacarConHechizo(john, bolaFuego);
            // Comportamiento.
            tom.Curar(john);
            // Comprobación.
            Assert.AreEqual(100, john.Vida);
        }
        /*
         Con este test primero atacamos al personaje y luego usamos la capacidad del mago de curar
         para restablecer a 100 su vida, que es la que elegimos en esta oportunidad como vida máxima. 
        */

    }
}
