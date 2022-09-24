using Library;


namespace Test.Library;

[TestFixture]
public class TestLibroHechizos
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void TestString()
    {
        LibroHechizos libro1 = new LibroHechizos("Libro del mago");
        string nombreEsperado = "Libro del mago";
        Assert.AreEqual(nombreEsperado, libro1.Descripcion);
    }

    [Test]
     public void NombreVacio()
    {
        LibroHechizos libro1 = new LibroHechizos("");
        string nombreEsperado = null;
        Assert.AreEqual(nombreEsperado, libro1.Descripcion);
    }
    [Test]
     public void NombreSoloEspaciosVacios()
    {
        LibroHechizos libro1 = new LibroHechizos("        ");
        string nombreEsperado = null;
        Assert.AreEqual(nombreEsperado, libro1.Descripcion);
    } 
    [Test]

       public void NombreNulo()
    {
        LibroHechizos libro1 = new LibroHechizos(null);
        string nombreEsperado = null;
        Assert.AreEqual(nombreEsperado, libro1.Descripcion);
    }
   [Test]

       public void NombreSoloSignos()
    {
        LibroHechizos libro1 = new LibroHechizos("_.:=)");
        string nombreEsperado = null;
        Assert.AreEqual(nombreEsperado, libro1.Descripcion);
    }

    [Test]

    public void AgregarHechizo()
    {
        Hechizo bolaFuego = new Hechizo("Bola de fuego", "Hechizo de fuego", 20,0);
        LibroHechizos libroFuego = new LibroHechizos("Fuego ancestral");
        libroFuego.AgregarHechizo(bolaFuego);
        //Comprobación
        Assert.IsTrue(libroFuego.Hechizos.Contains(bolaFuego));

    }
    [Test]

    public void EliminarHechizo()
    {
        Hechizo muroAgua = new Hechizo("Muro de agua", "Hechizo de agua", 0,40);
        LibroHechizos grimorioAzul = new LibroHechizos("Grimorio azul");
        grimorioAzul.AgregarHechizo(muroAgua);
        //Comportamiento
        grimorioAzul.QuitarHechizo(muroAgua);
        //Comprobación
        Assert.IsFalse(grimorioAzul.Hechizos.Contains(muroAgua));
    }


}