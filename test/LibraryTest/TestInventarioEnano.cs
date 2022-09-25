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
        bolsa.AgregarArma(maso);
        // Comprobación.
        Assert.IsTrue(bolsa.Armas.Contains(maso));
    }

    [Test]
    public void QuitarArma()
    {
        // Configuración.
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarArma(maso);
        // Comportamiento.
        bolsa.QuitarArma(maso);
        // Comprobación.
        Assert.IsFalse(bolsa.Armas.Contains(maso));
    }
    public void AgregarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarRopa(armadura);
        Assert.IsTrue(bolsa.Ropas.Contains(armadura));
    }

    [Test]
    public void QuitarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarRopa(armadura);
        bolsa.QuitarRopa(armadura);
        Assert.IsFalse(bolsa.Ropas.Contains(armadura));
    }
    [Test]
    public void MostrarContenidoTest()
    {
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioEnano testInventarioEnano = new InventarioEnano();
        testInventarioEnano.AgregarRopa(armadura);
        testInventarioEnano.AgregarArma(maso);
        testInventarioEnano.MostrarContenido();
        Assert.Pass();
    }
}