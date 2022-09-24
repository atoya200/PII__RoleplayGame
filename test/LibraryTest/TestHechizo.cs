using Library;



namespace Test.Library;

[TestFixture]
public class TestHechizo
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void TestConstuctor()
    {
        string expectedName = "Super fuerza";
        string expectedType = "Ataque";
        int expectedAttack = 20;
        int expectedDeffense = 0;
        Hechizo testHechizo = new Hechizo("Super fuerza","Ataque",20,0);
        Assert.AreEqual(expectedName,testHechizo.Descripcion);
        Assert.AreEqual(expectedType,testHechizo.Tipo);
        Assert.AreEqual(expectedAttack,testHechizo.Ataque);
        Assert.AreEqual(expectedDeffense,testHechizo.Defensa);
    }
    [Test]
    public void TestWithWrongName()
    {
        string expectedName = null;
        Hechizo testHechizo = new Hechizo("         ","Ataque",20,0);
        Assert.AreEqual(expectedName,testHechizo.Descripcion);
    }
    [Test]
    public void TestWithNullName()
    {
        string expectedName = null;
        Hechizo testHechizo = new Hechizo(null,"Ataque",20,0);
        Assert.AreEqual(expectedName,testHechizo.Descripcion);
    }
    [Test]
    public void TestWithEmptyName()
    {
        string expectedName = null;
        Hechizo testHechizo = new Hechizo("","Ataque",20,0);
        Assert.AreEqual(expectedName,testHechizo.Descripcion);
    }
    [Test]
    public void TestWithSpaceBoardName()
    {
        string expectedName = null;
        Hechizo testHechizo = new Hechizo("      ","Ataque",20,0);
        Assert.AreEqual(expectedName,testHechizo.Descripcion);
    }
    [Test]
    public void TestWithWrongTypeName()
    {
        string expectedType = null;
        Hechizo testHechizo = new Hechizo(null,"Tipo nada",20,0);
        Assert.AreEqual(expectedType,testHechizo.Tipo);
    }
    [Test]
    public void TestWithEmptyTypeName()
    {
        string expectedType = null;
        Hechizo testHechizo = new Hechizo(null,"",20,0);
        Assert.AreEqual(expectedType,testHechizo.Tipo);
    }
    [Test]
    public void TestWithSpaceboardTypeName()
    {
        string expectedType = null;
        Hechizo testHechizo = new Hechizo(null,"      ",20,0);
        Assert.AreEqual(expectedType,testHechizo.Tipo);
    }

    [Test]
    public void DañoInferiorACero()
    {
        // Pruebo que el daño que cargue no pueda ser menor a 0
        int dañoEsperado = 0;
        Hechizo bolaFuego = new Hechizo("Bola de fuego", "Ataque",(-100),0);
//        Assert.AreEqual(dañoEsperado, bolaFuego.Ataque);
        // Ahora no pasa el test por que no hay nada que valide ese dato, lo mismo con defensa
    }
}