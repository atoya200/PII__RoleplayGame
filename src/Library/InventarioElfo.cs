using System.Collections.Generic;
using System;

namespace Library;

public class InventarioElfo : IInventario
{


    public List<Arma> Armas { get; } 
    public List<Ropa> Ropas { get; private set; } 

    public InventarioElfo()
    {
        Ropas = new List<Ropa>();
        Armas = new List<Arma>();
    }
    public void AgregarRopa(Ropa prenda)
    {
        this.Ropas.Add(prenda);
    }
    public void QuitarRopa(Ropa prenda)
    {
        this.Ropas.Remove(prenda);
    }

    public void AgregarArma(Arma arma)
    {
        this.Armas.Add(arma);
    }
    public void QuitarArma(Arma arma)
    {
        this.Armas.Remove(arma);

    }

    public void MostrarContenido()
    {
        this.ImprimirArmas();
        this.ImprmirRopa();
    }

    public void ImprimirArmas()
    {
        Console.WriteLine("Armas");
        foreach (Arma item in this.Armas)
        {
           Console.WriteLine($"{item.Name}");    
        }
    }

    public void ImprmirRopa()
    {
        Console.WriteLine("Ropaje");
        foreach (IEquipamiento item in this.Ropas)
        {
                Console.WriteLine($"{item.Name}");
        }
    }

}
