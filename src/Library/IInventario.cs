using System.Collections.Generic;
using System;

namespace Library;
/* 
 Consideramos que cada personaje debía de tener un inventario que fuera de un tipo
 diferente al de los demás, ya que sería una forma de garantizar
 que un personaje no equipe algo que le corresponde solo a otro, como en el caso 
 del libro de hechizos. Sin embargo, como comparten propiedades consideramos que 
 tendrían que tener un tipo en común que represente esas propiedades y métodos en común.
*/
public interface IInventario
{

    public List<Arma> Armas { get; }
    public List<Ropa> Ropas { get; }

    // Aplicando polimorfismo creamos una lista para 
    // albergar a los objetos de tipo Ropa.
    // Estos pueden quitarse o agregarse. 
    public void AgregarRopa(Ropa prenda);

    public void QuitarRopa(Ropa prenda);

    // Aplicando polimorfismo creamos una lista para 
    // albergar a los objetos de tipo Ropa.
    // Estos pueden quitarse o agregarse. 
    public void AgregarArma(Arma arma);

    public void QuitarArma(Arma arma);

    // Se encarga de imprimir los objetos que contiene el inventario.
    public void MostrarContenido();

    // Se encarga de imprimir la ropa que hay en inventario.
    public void ImprmirRopa();
    // se encarga de imprimir las armas que posee el personaje. 
    public void ImprimirArmas();

}
