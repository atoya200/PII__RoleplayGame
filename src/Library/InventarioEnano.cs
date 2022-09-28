using System.Collections.Generic;
using System;

namespace Library;

    public class InventarioEnano: IInventario
    {
        
        public List<Arma> Armas { get; } 
    public List<Ropa> Ropas { get; private set; }
    /*
     Instancia las listas que contendran los objetos del inventario
     Para mayor control y no tener que preguntar por tipos más adelante
     fue que usando polimorfismo separamos por tipo las listas.

    */
    public InventarioEnano()
    {
        Ropas = new List<Ropa>();
        Armas = new List<Arma>();
    }
    // Agregamos un objeto de tipo Ropa a la lista de ropa
    public void AgregarRopa(Ropa prenda)
    {
        this.Ropas.Add(prenda);
    }

    // Quitamos el objeto de tipo Ropa que nos llega por parametro de la lista de ropa.
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
    

    // Imprime por consola el contenido del inventario
    public void MostrarContenido()
    {
        this.ImprimirArmas();
        this.ImprmirRopa();
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

    }
