using Library;



namespace Test.Library;

[TestFixture]
public class TestHechizoAtaque
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void TestConstuctor() //En este test, testeamos en general la entrada de los parámetros y si se asgignan correctamente.
                                //Para lograr esto, introducimos los parámetros creando el objeto, y a la vez determinamos que sería lo esperado en su asignación a los atributos.
    {
        // Atributos esperados
        string expectedName = "Super fuerza";
        string expectedType = "Ataque";
        int expectedAttack = 20;
        int expectedDeffense = 0;
        // Creación del objeto
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("Super fuerza",20,0);
        // Comprobante
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
        Assert.AreEqual(expectedType,testHechizoAtaque.Tipo);
        Assert.AreEqual(expectedAttack,testHechizoAtaque.Ataque);
        Assert.AreEqual(expectedDeffense,testHechizoAtaque.Defensa);
    }
    [Test]
    public void TestWithWrongName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("  .-/,,    ",20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
        // En este test, verificamos que en el caso de poner una serie de caracteres incorrectos, 
        // el programa lo tome como inválido y lo pase a null
    }
    [Test]
    public void TestWithNullName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque(null,20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
        //En este caso, probamos que en el caso de poner un nombre de valor null, en la asignación de los atributos también quede "null"
    }
    [Test]
    public void TestWithEmptyName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("",20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
        // En este caso, probamos construir el objeto con un nombre vacío. 
        //El programa debe tomarlo como inválido y pasarlo a null, como se busca comprobar en este test.
    }
    [Test]
    public void TestWithSpaceBoardName()
    {
        string expectedName = null;
        HechizoAtaque testHechizoAtaque = new HechizoAtaque("      ",20);
        Assert.AreEqual(expectedName,testHechizoAtaque.Descripcion);
        // En este caso, probamos introducir un nombre que sea un conjunto de espacios en blanco, 
        // caso que también se debería tomar como inválido y pasarse a tipo "null"
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