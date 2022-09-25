using Library;


namespace Test.Library;

[TestFixture]
public class TestLibroHechizos
{
    [SetUp]
    public void SetUp()
    {
    }

    // A probar el name.
  

   [Test]
    public void NameFormatoCorrecto()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","Libro del mago");
        string nameEsperado = "Grimorio oscuro";
        Assert.AreEqual(nameEsperado, libro1.Name);
    }

    [Test]
     public void NameVacio()
    {
        LibroHechizos libro1 = new LibroHechizos("","Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    }
    [Test]
     public void NameSoloEspaciosVacios()
    {
        LibroHechizos libro1 = new LibroHechizos("        ","Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    } 
    [Test]

       public void NameNulo()
    {
        LibroHechizos libro1 = new LibroHechizos(null, "Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    }
   [Test]

       public void NameSoloSignos()
    {
        LibroHechizos libro1 = new LibroHechizos("_.:=)","Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    }

// Probar descripcion
    [Test]
    public void DescripcionCorrecta()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","Libro del mago");
        string descripcionEsperada = "Libro del mago";
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }

    [Test]
     public void DescripcionVacio()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","");
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }
    [Test]
     public void DescripcionSoloEspaciosVacios()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","        ");
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    } 
    [Test]

       public void DescripcionNulo()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro",null);
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }

     [Test]

       public void DescripcionSoloSignos()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","_.:=)");
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }

   
    // Probar comportamiento del libro.
    [Test]
    public void AgregarHechizoAtaque()
    {
        IHechizo bolaFuego = new HechizoAtaque("Bola de fuego",  20);
        LibroHechizos libroFuego = new LibroHechizos("Grimorio rojo","Libro de magia de fuego ancestral");
        libroFuego.AgregarHechizo(bolaFuego);
        //Comprobación
        Assert.IsTrue(libroFuego.Hechizos.Contains(bolaFuego));

    }
    [Test]

    public void EliminarHechizoAtaque()
    {
        IHechizo bolaFuego = new HechizoAtaque("Bola de fuego",  20);
        LibroHechizos grimorioAzul = new LibroHechizos("Grimorio rojo","Libro del mago");
        grimorioAzul.AgregarHechizo(bolaFuego);
        //Comportamiento
        grimorioAzul.QuitarHechizo(bolaFuego);
        //Comprobación
        Assert.IsFalse(grimorioAzul.Hechizos.Contains(bolaFuego));
    }
    [Test]
    public void AgregarHechizoDefensa()
    {
        IHechizo muroAgua = new HechizoDefensa("Muro de agua",40);
        LibroHechizos grimorioAzul = new LibroHechizos("Grimorio azul","Libro del mago");  
        //Comportamiento
        grimorioAzul.AgregarHechizo(muroAgua);     
        //Comprobación
        Assert.IsTrue(grimorioAzul.Hechizos.Contains(muroAgua));

    }
    [Test]

    public void EliminarHechizoDefensa()
    {
        IHechizo muroAgua = new HechizoDefensa("Muro de agua",40);
        LibroHechizos grimorioAzul = new LibroHechizos("Grimorio azul","Libro del mago");
        grimorioAzul.AgregarHechizo(muroAgua);
        //Comportamiento
        grimorioAzul.QuitarHechizo(muroAgua);
        //Comprobación
        Assert.IsFalse(grimorioAzul.Hechizos.Contains(muroAgua));
    }


}