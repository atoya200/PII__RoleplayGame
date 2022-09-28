using Library;

namespace Test.Library;

[TestFixture]
public class TestInventarioElfo
{
   
    /* 
     En este test, se crea un objeto de la clase "Arma" y un inventario de Elfo.
     Luego se utiliza el método de agregar el arma al inventario del elfo, y se evalúa 
     si es verdad que el arma quedó contenida en ese inventario
    */
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

    /*
     Este caso es igual al anterior, solo que quitando el arma. Se crean los objetos, se agrega un arma, y luego se quita.
     Por último, verifica que sea falso que el arma está contenida en el inventario. 
    */
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

    /*
     En el test actual, se crea una Ropa y un Inventario de elfo. Esa ropa se intenta agregar al inventario del elfo.
     Por último, se comprueba que el elemento agregado esté en el inventario del elfo, pasando el test si es cierto.
    */
    [Test]
    public void AgregarRopaTest()
    {
        Ropa armadura = new Ropa("Armadura", "Defensa de soldados", 0, 20);
        InventarioElfo bolsa = new InventarioElfo();
        bolsa.AgregarRopa(armadura);
        Assert.IsTrue(bolsa.Ropas.Contains(armadura));
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
        Ropa armadura = new Ropa("Armadura", "Defensa de soldados", 0, 20);
        InventarioElfo bolsa = new InventarioElfo();
        // Agregar objeto a inventario
        bolsa.AgregarRopa(armadura);
        // Quitar del inventario
        bolsa.QuitarRopa(armadura);
        // Comprobar que no está en el inventario
        Assert.IsFalse(bolsa.Ropas.Contains(armadura));
    }

    /*
     Por último, en este test se crea un objeto de Ropa, de Arma y un Inventario de elfo.
     Estos objetos son agregados al Inventario, y luego se ejecuta el método "MostrarContenido", 
     que es el encargado de imprimir en consola lo que contiene el mago
    */
    [Test]
    public void MostrarContenidoTest()
    {
        // Cofiguración. 
        Ropa armadura = new Ropa("Armadura","Armadura de hierro",0,30);
        Arma escopeta = new Arma("Escopeta","Escopeta calibre 12 bañada en oro de 18 kilates",70,0);
        InventarioElfo testInventarioElfo = new InventarioElfo();
        testInventarioElfo.AgregarRopa(armadura);
        testInventarioElfo.AgregarArma(escopeta);
        // Comportamiento.
        testInventarioElfo.MostrarContenido();
        // Comprobación.
        Assert.Pass();
    }
}