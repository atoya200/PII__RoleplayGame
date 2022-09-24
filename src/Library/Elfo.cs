using System;
using System.Collections.Generic;

namespace Library;

public class Elfo: IPersonaje
{
    public string Nombre { get; set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida = 100;
    public int Vida { get { return vida; } set{this.vida = value;} }
    public Inventario Inventario { get; }

    public Arma ArmaEquipada { get; private set; }

    public List<Ropa> RopaEquipada { get; }

    public Elfo(string nombre)
    {
        if(TextoValido(nombre))
            {
                this.Nombre = nombre;
            }
            else
            {
                this.Nombre = null;
            } 
        RopaEquipada = new List<Ropa>();
        Inventario = new Inventario();;
    }
    public bool TextoValido(string nombre)
        {
            if(nombre == null || nombre.Length == 0  || NoTieneLetrasNumeros(nombre))
            {
                return false;
            }
            return true;
        }

        public bool NoTieneLetrasNumeros(string nombre)
        { 
            List<char> letras  = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P','Q', 'R', 'S', 'T', 'V', 'X', 'Y', 'Z'}; //Terminar de escribir las letras
            List<char> numeros  = new List<char>() {'0','1','2','3','4','5','6','7','8','9'}; //Terminar de escribir las letras
            List<char> letrasMin = new List<char>(){'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p','q', 'r', 's', 't', 'v', 'x', 'y', 'z'};;
            
            // Una var para ir revisando que todos los caracteres esten correctos
        bool formatoIncorrecto = true;
        foreach (char c in nombre)
        {
             if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c))
            {
                formatoIncorrecto = (formatoIncorrecto && false);
            }
            else
            {
                return true;
            }
        }

        return formatoIncorrecto;
        }
    public void Atacar(IPersonaje personaje)
    {
        if (this.ObtenerAtaqueTotal() >= personaje.ObtenerDefensaTotal())
        {
            personaje.Vida = personaje.Vida - (this.ObtenerAtaqueTotal() - personaje.ObtenerDefensaTotal());
        }
    }

 public void EquiparArma(Arma arma)
   {
    if(Inventario.Armas.Contains(arma))
        {
            this.ArmaEquipada = arma;
        }
        else
        {
            Console.WriteLine("Esa arma no esta en el inventario");
        }
   }

   public void DesequiparArma()
   {
        this.ArmaEquipada = null;
   }
     public void EquiparRopa(Ropa ropa)
    {
        if(Inventario.Ropas.Contains(ropa))
        {
            this.RopaEquipada.Add(ropa);
        }
        else
        {
            Console.WriteLine("Ese ropaje no esta en el inventario");
        }
    }

    public void QuitarRopa(Ropa ropa)
    {
        this.RopaEquipada.Remove(ropa);
    }
    public int ObtenerAtaqueTotal()
    {
        if (this.ArmaEquipada == null)
        {
            return this.Fuerza;
        }
        else
        {
            return this.Fuerza + this.ArmaEquipada.Ataque;
        }

    }
    public int ObtenerDefensaTotal()
    {
        int defensaTotal = 0;
        foreach (var item in RopaEquipada)
        {
            defensaTotal += item.Defensa;
        }
        if (this.ArmaEquipada != null)
        {
            defensaTotal += this.ArmaEquipada.Defensa;
        }
        return defensaTotal;
    }
}