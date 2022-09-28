using Library;

namespace Test.Library;

[TestFixture]
public class TestInventarioMago
{
    /*
     En este test, se crea un objeto de la clase "Arma" y un inventario de Mago.
     Luego se utiliza el método de agregar el arma al inventario del mago, y se
     evalúa si es verdad que el arma quedó contenida en ese inventario
    */
    [Test]
    public void AgregarArma()
    {
        // Configuración.
        Arma baston = new Arma("Bastón del Rey Mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
        InventarioMago bolsa = new InventarioMago();
        // Comportamiento.
        bolsa.AgregarArma(baston);
        // Comprobación.
        Assert.IsTrue(bolsa.Armas.Contains(baston));
    }

    /*
     Este caso es igual al anterior, solo que quitando el arma. Se crean los objetos, se agrega un arma, y luego se quita.
     Por último, verifica que sea falso que el arma está contenida en el inventario. 
    */
    [Test]
    public void QuitarArma()
    {
        // Configuración.
        Arma baston = new Arma("Bastón del rey Mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarArma(baston);
        // Comportamiento.
        bolsa.QuitarArma(baston);
        // Comprobación.
        Assert.IsFalse(bolsa.Armas.Contains(baston));
    }
    /*
     En el test actual, se crea una Ropa y un Inventario de mago. Esa ropa se intenta agregar al inventario del mago.
     Por último, se comprueba que el elemento agregado esté en el inventario del mago, pasando el test si es cierto.
    */
    [Test]
    public void AgregarRopaTest()
    {
        // Configuración
        Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
        // Comportamiento
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarRopa(tunica);
        // Comprobación
        Assert.IsTrue(bolsa.Ropas.Contains(tunica));
    }

    /* 
     En este caso vemos el opuesto, se asigna la ropa al inventario y luego se quita del mismo.
     Para que el test pase, se debe comprobar que es falso que el objeto de la clase Ropa está 
     en el inventario, ya que debe haber sido removido. 
    */
    [Test]
    public void QuitarRopaTest()
    {       
        // Creación de objetos
        Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarRopa(tunica);
        // Comportamiento.
        bolsa.QuitarRopa(tunica);
        // Comprobación.
        Assert.IsFalse(bolsa.Ropas.Contains(tunica));
    }
    /* 
     En el test actual, se crea un Elemento magico y un Inventario de mago.
     Ese elemento magico se intenta agregar al inventario del mago.
     Por último, se comprueba que el elemento agregado esté en el inventario del mago, pasando el test si es cierto.
    */
    [Test]
    public void AgregarElementoMagicoTest()
    {
        ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 30, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElementoMagico(runa);
        Assert.IsTrue(bolsa.ElementosMagicos.Contains(runa));
    }

    /* 
     En este caso vemos el opuesto, se asigna el elemento magico al inventario y luego se quita del mismo. 
     Para que el test pase, se debe comprobar que es falso que el objeto de la clase ElementoMagico está
     en el inventario, ya que debe haber sido removido.
    */
    [Test]
    public void QuitarElementoMagicoTest()
    {  
        ElementoMagico runa = new ElementoMagico("Runa del gran dragón rojo", "Item desprendido del cuerpo del colosal dragón rojo del bosco de Kellv", 30, 0);
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarElementoMagico(runa);
        bolsa.QuitarElementoMagico(runa);
        Assert.IsFalse(bolsa.ElementosMagicos.Contains(runa));
    }

    /*
     Se crea un libro de hechizos y se le asigna al atributo LibroDeHechizos del mago.
     El test pasa si el objeto que se intentó asignar es el mismo que el que está asignado en el atributo del inventario del mago
    */
    [Test]
    public void AgregarLibroHechizosTest()
    {
        LibroHechizos grimorio = new LibroHechizos("Grimorio del Rey Mago", "Uno de los tres grimorios legandarios");
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarLibro(grimorio);
        Assert.AreEqual(grimorio, bolsa.LibroDeHechizos);
    }

    /*
     En este caso se crea un LibroHechizos y se le asigna al mago, pero luego se quita.
     El test pasa si es falso que ese libro es el que está asignado al atributo LibroDeHechizos del inventario del mago.
    */
    [Test]
    public void QuitarLibroHechizosTest()
    {
        LibroHechizos grimorio = new LibroHechizos("Grimorio del Rey Mago", "Uno de los tres grimorios legandarios");
        InventarioMago bolsa = new InventarioMago();
        bolsa.AgregarLibro(grimorio);
        bolsa.QuitarLibro(grimorio);
        Assert.IsFalse(grimorio == bolsa.LibroDeHechizos);
    }

    /*
     Por último, en este test se crea un objeto de Ropa, de Arma y un Inventario de mago.
     Estos objetos son agregados al Inventario, y luego se ejecuta el método "MostrarContenido",
     que es el encargado de imprimir en consola lo que contiene el mago.
    */
    [Test]
    public void MostrarContenidoTest()
    {
        // Configuración.
        Ropa tunica = new Ropa("Tunica del maestro Gangan", "Fue usada por el gran mago Gangan, dicen que con ella te volveras igual de poderoso", 0, 30);
        Arma baston = new Arma("Bastón del rey mago", "Se cree que es el mismo bastón que uso el Rey Mago hace 200 años", 40, 0);
        InventarioMago testInventarioMago = new InventarioMago();
        testInventarioMago.AgregarRopa(tunica);
        testInventarioMago.AgregarArma(baston);
        // Verificación de impresión en consola
        testInventarioMago.MostrarContenido();
        // Usamos este método Assert para saber si el test llegó hasta aquí.
        Assert.Pass();
    }
}