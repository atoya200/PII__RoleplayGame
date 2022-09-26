using Library;


namespace Test.Library;

[TestFixture]
public class TestLibroHechizos
{
    [SetUp]
    public void SetUp()
    {
    }

    // En este test creamos un libro de hechizos, y comprobamos que el nombre que le pasamos sea asignado correctamente por que esta en un formato correcto.
    public void NameFormatoCorrecto()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","Libro del mago");
        string nameEsperado = "Grimorio oscuro";
        Assert.AreEqual(nameEsperado, libro1.Name);
    }
    // En este test creamos un libro de hechizos, y comprobamos que el nombre como esta vacío, sea cargado como nulo en las propiedades del libro. 
    [Test]
     public void NameVacio()
    {
        LibroHechizos libro1 = new LibroHechizos("","Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    }

    // En este test creamos un libro de hechizos, y comprobamos que el nombre no sea asignado, puesto que es una cadena vacía. Así que lo que debe hacer es cargar en el nombre un valor null. 
    [Test]
     public void NameSoloEspaciosVacios()
    {
        LibroHechizos libro1 = new LibroHechizos("        ","Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    } 
    // En este test creamos un libro de hechizos con el nombre nulo, por lo cual debería de cargarlo de esa manera, ya que ante formatos incorrectos las propiedades del objeto quedan cargadas como nulo en caso de ser string o como 0 en caso de ser int. 
    [Test]
       public void NameNulo()
    {
        LibroHechizos libro1 = new LibroHechizos(null, "Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    }
    // En este test creamos un libro de hechizos con un nombre de solo signos, sin letras, entonces comprobamos que se cargue como nulo, ya que no es un formato valido. 

   [Test]
       public void NameSoloSignos()
    {
        LibroHechizos libro1 = new LibroHechizos("_.:=)","Libro del mago");
        string nameEsperado = null;
        Assert.AreEqual(nameEsperado, libro1.Name);
    }

    // En este test creamos un libro de hechizos, y comprobamos que la descripción que le pasamos sea asignada correctamente por que esta en un formato correcto.    
    [Test]
    public void DescripcionCorrecta()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","Libro del mago");
        string descripcionEsperada = "Libro del mago";
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }
    // En este test creamos un libro de hechizos, y comprobamos que si la descripción esta vacía, sea cargada como nulo en la propiedad del libro. 
    [Test]
     public void DescripcionVacio()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","");
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }
        // En este test creamos un libro de hechizos, y comprobamos que la descripción no sea asignado, puesto que es una cadena vacía. Así que lo que debe hacer es cargar la descripción como un valor null. 
    [Test]
     public void DescripcionSoloEspaciosVacios()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","        ");
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    } 
        // En este test creamos un libro de hechizos con la descipción como nula, por lo cual debería de cargarlo de esa manera. 
    [Test]

       public void DescripcionNulo()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro",null);
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }

    // En este test creamos un libro de hechizos con una descripción de solo signos, sin letras, entonces comprobamos que se cargue como nulo, ya que no es un formato valido. 
     [Test]

       public void DescripcionSoloSignos()
    {
        LibroHechizos libro1 = new LibroHechizos("Grimorio oscuro","_.:=)");
        string descripcionEsperada = null;
        Assert.AreEqual(descripcionEsperada, libro1.Descripcion);
    }

   
    // En este test creamos un hechizo de ataque, creamos un libro de hechizos  y probamos la función AgregarHechizo de libro, para ver si efectivamente el hechizo quedaba dentro del libro.
    [Test]
    public void AgregarHechizoAtaque()
    {
        IHechizo bolaFuego = new HechizoAtaque("Bola de fuego",  20);
        LibroHechizos libroFuego = new LibroHechizos("Grimorio rojo","Libro de magia de fuego ancestral");
        libroFuego.AgregarHechizo(bolaFuego);
        //Comprobación
        Assert.IsTrue(libroFuego.Hechizos.Contains(bolaFuego));

    }
    // En este test lo que hicimos fue crear un hechizo de ataque, colocarlo en el libro de hechizos que creamos y luego probar si podíamos sacarlo de este libro (eliminarlo).
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
    /*
     En este test creamos un hechizo de defensa, creamos un libro de hechizos  y probamos la función
      AgregarHechizo de libro, para ver si efectivamente el hechizo quedaba dentro del libro.
      Comprobamos la existencia del hechizo en el libro.
    */
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
    /*
    En este test lo que hicimos fue crear un hechizo de defensa, colocarlo en el libro de hechizos que creamos y 
    luego probar si podíamos sacarlo de este libro (eliminarlo) Comprobando que ya no estuviera en la lista
    que lo contenía.
    */
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