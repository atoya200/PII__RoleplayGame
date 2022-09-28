using Library;
namespace Test.Library;

[TestFixture]
public class TestHechizoDefensa
{  
    /*
      En este test, verificamos que en el caso de poner una serie de caracteres incorrectos, 
      el programa lo tome como inválido y lo pase a null.
    */
    [Test]
    public void TestWithWrongName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("   ///<.;-   ",20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }

    /*
     En este caso, probamos que en el caso de poner un nombre de valor null, 
     en la asignación de los atributos también quede "null".
    */
    [Test]
    public void TestWithNullName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa(null,20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }

    /*
     En este caso, probamos construir el objeto con un nombre vacío. 
     El programa debe tomarlo como inválido y pasarlo a null, como se busca comprobar en este test.
    */
    [Test]
    public void TestWithEmptyName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("",20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
    }
    /* 
     En este caso, probamos introducir un nombre que sea un conjunto de espacios en blanco, 
     caso que también se debería tomar como inválido y pasarse a tipo "null"      
    */ 
    [Test]
    public void TestWithSpaceBoardName()
    {
        string expectedName = null;
        HechizoDefensa testHechizoDefensa = new HechizoDefensa("      ",20);
        Assert.AreEqual(expectedName,testHechizoDefensa.Descripcion);
        
    }
    
    /* 
     Pruebo que el daño que cargue no pueda ser menor a 0.
     Ahora no pasa el test por que no hay nada que valide ese dato, lo mismo con defensa
    */
    [Test]
    public void DefensaMenorACero()
    {
        int defensaEsperada = 0;
        HechizoDefensa bolaFuego = new HechizoDefensa("Bola de fuego", (-100));
        Assert.AreEqual(defensaEsperada, bolaFuego.Ataque);
    }
}