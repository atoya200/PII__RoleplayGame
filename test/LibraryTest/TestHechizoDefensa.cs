using Library;



namespace Test.Library;

[TestFixture]
public class TestHechizoDefensa
{
    [SetUp]
    public void SetUp()
    {
    }

    /* [Test]
    public void TestConstuctor()
    {
        string expectedName = "Super fuerza";
        string expectedType = "Ataque";
        int expectedAttack = 20;
        int expectedDeffense = 0;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("Super fuerza",20,0);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
        Assert.AreEqual(expectedType,testHechizoDefensa.Tipo);
        Assert.AreEqual(expectedAttack,testHechizoDefensa.Ataque);
        Assert.AreEqual(expectedDeffense,testHechizoDefensa.Defensa);
    } */
    [Test]
    public void TestWithWrongName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("         ",20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }
    [Test]
    public void TestWithNullName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa(null,20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }
    [Test]
    public void TestWithEmptyName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("",20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }
    [Test]
    public void TestWithSpaceBoardName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("      ",20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }
    
    // Reepensar
    [Test]
    public void DefensaMenorACero()
    {
        // Pruebo que el daño que cargue no pueda ser menor a 0
        int defensaEsperada = 0;
        HechizoDefensa bolaFuego = new HechizoDefensa("Bola de fuego", (-100));
        Assert.AreEqual(defensaEsperada, bolaFuego.Ataque);
        // Ahora no pasa el test por que no hay nada que valide ese dato, lo mismo con defensa
    }
}