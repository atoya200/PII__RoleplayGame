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
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioMago bolsa = new InventarioMago();
        // Comportamiento.
        bolsa.AgregarElemento(maso);
        // Comprobación.
        Assert.IsTrue(bolsa.Elementos.Contains(maso));
    }

    [Test]
    public void QuitarArma()
    {
        // Configuración.
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElemento(maso);
        // Comportamiento.
        bolsa.QuitarElemento(maso);
        // Comprobación.
        Assert.IsFalse(bolsa.Elementos.Contains(maso));
    }
    public void AgregarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElemento(armadura);
        Assert.IsTrue(bolsa.Elementos.Contains(armadura));
    }

    [Test]
    public void QuitarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElemento(armadura);
        bolsa.QuitarElemento(armadura);
        Assert.IsFalse(bolsa.Elementos.Contains(armadura));
    }
    [Test]
    public void AgregarElementoMagicoTest()
    {
        ElementoMagico runa = new ElementoMagico("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElementoMagico(runa);
        Assert.IsTrue(bolsa.ElementosMagicos.Contains(runa));
    }

    [Test]
    public void QuitarElementoMagicoTest()
    {
        ElementoMagico runa = new ElementoMagico("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
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
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioMago testInventarioMago = new InventarioMago();
        testInventarioMago.AgregarElemento(armadura);
        testInventarioMago.AgregarElemento(maso);
        testInventarioMago.MostrarContenido();
        Assert.Pass();
    }
}