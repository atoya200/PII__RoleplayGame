using Library;

namespace Test.Library;

[TestFixture]
public class TestInventarioMago
{
    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public void AgregarArma()
    {
        // Configuración.
        Arma baston = new Arma("Bastón del Rey Mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
        InventarioMago bolsa = new InventarioMago();
        // Comportamiento.
        bolsa.AgregarArma(baston);
        // Comprobación.
        Assert.IsTrue(bolsa.Armas.Contains(baston));
    }

    [Test]
    public void QuitarArma()
    {
        // Configuración.
        Arma baston = new Arma("Bastón del rey Mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarArma(baston);
        // Comportamiento.
        bolsa.QuitarArma(baston);
        // Comprobación.
        Assert.IsFalse(bolsa.Armas.Contains(baston));
    }
    public void AgregarRopaTest()
    {
        Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarRopa(tunica);
        Assert.IsTrue(bolsa.Ropas.Contains(tunica));
    }

    [Test]
    public void QuitarRopaTest()
    {
        Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarRopa(tunica);
        // Comportamiento.
        bolsa.QuitarRopa(tunica);
        // Comprobación.
        Assert.IsFalse(bolsa.Ropas.Contains(tunica));
    }
    [Test]
    public void AgregarElementoMagicoTest()
    {
        ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 30, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElementoMagico(runa);
        Assert.IsTrue(bolsa.ElementosMagicos.Contains(runa));
    }

    [Test]
    public void QuitarElementoMagicoTest()
    {
        ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 30, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElementoMagico(runa);
        bolsa.QuitarElementoMagico(runa);
        Assert.IsFalse(bolsa.ElementosMagicos.Contains(runa));
    }

    [Test]
    public void AgregarLibroHechizosTest()
    {
        LibroHechizos grimorio = new LibroHechizos("Grimorio del Rey Mago", "Uno de los tres grimorios legandarios");
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarLibro(grimorio);
        Assert.AreEqual(grimorio, bolsa.LibroDeHechizos);
    }

    [Test]
    public void QuitarLibroHechizosTest()
    {
        LibroHechizos grimorio = new LibroHechizos("Grimorio del Rey Mago", "Uno de los tres grimorios legandarios");
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarLibro(grimorio);
        bolsa.QuitarLibro(grimorio);
        Assert.IsFalse(grimorio == bolsa.LibroDeHechizos);
    }

    [Test]
    public void MostrarContenidoTest()
    {
        Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
        Arma baston = new Arma("Bastón del rey mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
        InventarioMago testInventarioMago = new InventarioMago();
        testInventarioMago.AgregarRopa(tunica);
        testInventarioMago.AgregarArma(baston);
        testInventarioMago.MostrarContenido();
        Assert.Pass();
    }
}