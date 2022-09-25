using Library;



namespace Test.Library;

[TestFixture]
public class TestHechizoAtaque
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
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("Super fuerza",20,0);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
        Assert.AreEqual(expectedType,testHechizoAtaque.Tipo);
        Assert.AreEqual(expectedAttack,testHechizoAtaque.Ataque);
        Assert.AreEqual(expectedDeffense,testHechizoAtaque.Defensa);
    } */
    [Test]
    public void TestWithWrongName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("         ",20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
    }
    [Test]
    public void TestWithNullName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque(null,20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
    }
    [Test]
    public void TestWithEmptyName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("",20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
    }
    [Test]
    public void TestWithSpaceBoardName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("      ",20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
    }
    

    [Test]
    public void DañoInferiorACero()
    {
        // Pruebo que el daño que cargue no pueda ser menor a 0
        int dañoEsperado = 0;
        HechizoAtaque bolaFuego = new HechizoAtaque("Bola de fuego", (-100));
        Assert.AreEqual(dañoEsperado, bolaFuego.Ataque);
        // Ahora no pasa el test por que no hay nada que valide ese dato, lo mismo con defensa
    }
}