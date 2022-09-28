using Library;

namespace Test.Library;

[TestFixture]
public class TestInventarioEnano
{
    /*
     En este test, se crea un objeto de la clase "Arma" y un inventario de Enano.
     Luego se utiliza el método de agregar el arma al inventario del enano, y 
     se evalúa si es verdad que el arma quedó contenida en ese inventario
    */
    [Test]
    public void AgregarArma()
    {
        // Configuración.
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioEnano bolsa = new InventarioEnano();
        // Comportamiento.
        bolsa.AgregarArma(maso);
        // Comprobación.
        Assert.IsTrue(bolsa.Armas.Contains(maso));
    }

    /*
     Este caso es igual al anterior, solo que quitando el arma. Se crean los objetos, se agrega un arma, y luego se quita.
     Por último, verifica que sea falso que el arma está contenida en el inventario. 
    */
    [Test]
    public void QuitarArma()
    {
        // Configuración.
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioEnano bolsa = new InventarioEnano();
        bolsa.AgregarArma(maso);
        // Comportamiento.
        bolsa.QuitarArma(maso);
        // Comprobación.
        Assert.IsFalse(bolsa.Armas.Contains(maso));
    }
    /* 
     En el test actual, se crea una Ropa y un Inventario de enano. Esa ropa se intenta agregar al inventario del enano.
     Por último, se comprueba que el elemento agregado esté en el inventario del enano, pasando el test si es cierto.
    */
    [Test]
    public void AgregarRopaTest()
    {
        // Configuración.
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioEnano bolsa = new InventarioEnano();
        // Comportamiento.
        bolsa.AgregarRopa(armadura);
        // Comprobación.
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
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        InventarioEnano bolsa = new InventarioEnano();
        // Agregar objeto a inventario
        bolsa.AgregarRopa(armadura);
        // Quitar del inventario
        bolsa.QuitarRopa(armadura);
        // Comprobar que no está en el inventario.
        Assert.IsFalse(bolsa.Ropas.Contains(armadura));
    }
    /*
     Por último, en este test se crea un objeto de Ropa, de Arma y un Inventario de enano.
     Estos objetos son agregados al Inventario, y luego se ejecuta el método "MostrarContenido", 
     que es el encargado de imprimir en consola lo que contiene el Enano.
    */
    [Test]
    public void MostrarContenidoTest()
    {
        // Configuración.
        Ropa armadura = new Ropa("Armadura de plata", "Fundida en plata te protegera de los ataques de cientos de enemigos", 0, 30);
        Arma maso = new Arma("Maso de Odin", "Se cree que fue forjado por los enanos al servicio del dios Odin", 400, 0);
        InventarioEnano testInventarioEnano = new InventarioEnano();
        // Comportamiento, agrega los items al inventario. 
        testInventarioEnano.AgregarRopa(armadura);
        testInventarioEnano.AgregarArma(maso);
        // Verificación de impresión en consola
        testInventarioEnano.MostrarContenido();
        // Usamos este método Assert para saber si el test llegó hasta aquí.
        Assert.Pass();
    }
}