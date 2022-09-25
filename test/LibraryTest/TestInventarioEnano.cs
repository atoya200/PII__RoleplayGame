using Library;

namespace Test.Library;

[TestFixture]
public class TestInventarioEnano
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
        InventarioEnano bolsa = new InventarioEnano();
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
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarElemento(maso);
        // Comportamiento.
        bolsa.QuitarElemento(maso);
        // Comprobación.
        Assert.IsFalse(bolsa.Elementos.Contains(maso));
    }
    public void AgregarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarElemento(armadura);
        Assert.IsTrue(bolsa.Elementos.Contains(armadura));
    }

    [Test]
    public void QuitarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarElemento(armadura);
        bolsa.QuitarElemento(armadura);
        Assert.IsFalse(bolsa.Elementos.Contains(armadura));
    }
    [Test]
    public void MostrarContenidoTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioEnano testInventarioEnano = new InventarioEnano();
        testInventarioEnano.AgregarElemento(armadura);
        testInventarioEnano.AgregarElemento(maso);
        testInventarioEnano.MostrarContenido();
        Assert.Pass();
    }
}