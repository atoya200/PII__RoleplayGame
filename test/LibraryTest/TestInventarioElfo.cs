using Library;

namespace Test.Library;

[TestFixture]
public class TestInventarioElfo
{
    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public void AgregarArma()
    {
        // Configuración.
        Arma espada = new Arma("Esapada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
        Arma espada2 = new Arma("Esapada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
        InventarioElfo bolsa = new InventarioElfo();
        // Comportamiento.
        bolsa.AgregarArma(espada);
        // Comprobación.
        Assert.IsTrue(bolsa.Armas.Contains(espada));
    }

    [Test]
     public void QuitarArma()
    {
        // Configuración.
        Arma espada2 = new Arma("Esapada del rey Arturo", "Fue la santa espada que uso el Rey Arturo para guiar a sus caballeros en las cruzadas", 40, 0);
        InventarioElfo bolsa = new InventarioElfo();
        bolsa.AgregarArma(espada2);
        // Comportamiento.
        bolsa.QuitarArma(espada2);
        // Comprobación.
        Assert.IsFalse(bolsa.Armas.Contains(espada2));
    }
    public void AgregarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura", "Defensa de soldados", 0, 20);
        InventarioElfo bolsa = new InventarioElfo();
        bolsa.AgregarRopa(armadura);
        Assert.IsTrue(bolsa.Ropas.Contains(armadura));
    }

    [Test]
     public void QuitarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura", "Defensa de soldados", 0, 20);
        InventarioElfo bolsa = new InventarioElfo();
        bolsa.AgregarRopa(armadura);
        bolsa.QuitarRopa(armadura);
        Assert.IsFalse(bolsa.Ropas.Contains(armadura));
    }
    [Test]
    public void MostrarContenidoTest()
    {
        Ropa armadura = new Ropa("Armadura","Armadura de hierro",0,30);
        Arma escopeta = new Arma("Escopeta","Escopeta calibre 12 bañada en oro de 18 kilates",70,0);
        InventarioElfo testInventarioElfo = new InventarioElfo();
        testInventarioElfo.AgregarRopa(armadura);
        testInventarioElfo.AgregarArma(escopeta);
        testInventarioElfo.MostrarContenido();
        Assert.Pass();
    }
}