using System.Collections.Generic;
using System;

namespace Library;

public class InventarioMago : IInventario
{

    public List<Arma> Armas { get; }
    public List<Ropa> Ropas { get; private set; }
    public List<ElementoMagico> ElementosMagicos { get; private set; }

    public LibroHechizos LibroDeHechizos { get; private set; }
    




    // Imprime por consola el contenido del inventario

    // Imprime las armas que posee el persoanje por consola. 

    // Imprime la ropa que el personaje posee, desde la equipada hasta la que no, pero esta en el inventario.

    /*
     Instancia las listas que contendran los objetos del inventario
     Para mayor control y no tener que preguntar por tipos más adelante
     fue que usando polimorfismo separamos por tipo las listas.
    */
    public InventarioMago()
    {
        Ropas = new List<Ropa>();
        Armas = new List<Arma>();
        ElementosMagicos = new List<ElementoMagico>();
    }
    // Agregamos un objeto de tipo Ropa a la lista de ropa
    public void AgregarRopa(Ropa prenda)
    {
        this.Ropas.Add(prenda);
    }
    // Quitamos el objeto de tipo Ropa que nos llega por parametro de lista de ropa.
    public void QuitarRopa(Ropa prenda)
    {
        this.Ropas.Remove(prenda);
    }

    // Agregamos un objeto de tipo Arma a la lista de armas
    public void AgregarArma(Arma arma)
    {
        this.Armas.Add(arma);
    }
    // Quitamos el objeto de tipo Arma que nos llega por parametro de la lista de armas
    public void QuitarArma(Arma arma)
    {
        this.Armas.Remove(arma);

    }
    
    // Asignamos a la propiedad LIbroDeHechizos un libro que se recibe por el parámetro, ese "espacio" en el inventario deja de estar vacío
    public void AgregarLibro(LibroHechizos libro)
    {
        this.LibroDeHechizos = libro;
    }

    // Aquí quitamos ese libro de esa "ranura" o "espacio" 
    public void QuitarLibro(LibroHechizos libro)
    {
        this.LibroDeHechizos = null;
    }

    // Agregamos un ElementoMagico que llega por el parametro a la lista correspondiente a su tipo
    public void AgregarElementoMagico(ElementoMagico elemento)
    {
        this.ElementosMagicos.Add(elemento);
    }

    // Quitamos un ElementoMagico de la lista correspondiente a su tipo, siendo el eliminado el que llega por el parámetro.
    public void QuitarElementoMagico(ElementoMagico elemento)
    {
        this.ElementosMagicos.Remove(elemento);
    }
    // Imprime por consola el contenido del inventario
    public void MostrarContenido()
    {
        this.ImprimirArmas();
        this.ImprmirRopa();
        this.ImprmirElementosMagicos();
        this.ImprmirLibroHechizos();
    }
    // Imprime las armas que posee el persoanje por consola. 
    public void ImprimirArmas()
    {
        Console.WriteLine("Armas");
        foreach (Arma item in this.Armas)
        {
           Console.WriteLine($"{item.Name}");    
        }
    }
    // Imprime la ropa que el personaje posee, desde la equipada hasta la que no, pero esta en el inventario.
    public void ImprmirRopa()
    {
        Console.WriteLine("Ropaje");
        foreach (IEquipamiento item in this.Ropas)
        {
                Console.WriteLine($"{item.Name}");
        }
    }

    // Imprime los elementos mágicos contenidos en el inventario del mago.
    public void ImprmirElementosMagicos()
    {
        Console.WriteLine("Elmentos magicos");
        foreach (ElementoMagico item in this.ElementosMagicos)
        {
            Console.WriteLine($"{item.Name}");
        }
    }
    // Imprime el nombre del libro y su contenido por consola, si hay un libro guardado en el inventario.
    public void ImprmirLibroHechizos()
    {
        if (this.LibroDeHechizos != null)
        {
            Console.WriteLine("Libro de hechizos {1} contiene los siguientes hechizos", LibroDeHechizos.Name);
            foreach (IHechizo hechizo in this.LibroDeHechizos.Hechizos)
            {
                Console.WriteLine($"{hechizo.Descripcion}");
            }
        }
        else
        {
            Console.WriteLine("No hay un libro de hechizos en el inventario");
        }

    }



}
