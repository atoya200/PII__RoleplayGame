using System;
using System.Collections.Generic;

namespace Library;

public class Mago : IPersonaje
{

    public string Name { get; private set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida = 100;
    public int Vida { get { return vida; } set { this.vida = value; } }

    public int Conocimiento { get
    {
        if(this.LibroDeHechizosEquipado != null)
          {
          
          return Inventario.LibroDeHechizos.Hechizos.Count();

          }
          else{
            return 0;
          }
    } }
    // Habría que contemplar el nivel o sabiduría del mago dependiendo del libro en particular
    // Viendo si hay que sumar el poder de defensa y ataque de los hechizos, o el total de hechizos
    //public int Conocimiento {get{};}
    // Si se quiere usar hechizos que aumenten la defensa tendría que haber un valor de defensa nato que luego pueda aumentarse
    public int Defensa{get;set;}
  
    public InventarioMago Inventario { get; }

    public Arma ArmaEquipada { get; set; }

    public List<Ropa> RopaEquipada { get; }

    public LibroHechizos LibroDeHechizosEquipado { get; private set; }

    public Mago( string name)
    {
        if (TextoValido(name))
        {
            this.Name = name;
        }
        else
        {
            this.Name = null;
        }
        RopaEquipada = new List<Ropa>();
        Inventario = new InventarioMago();
    }
    public bool TextoValido(string name)
    {
        if (name == null || name.Length == 0 || NoTieneLetrasNumeros(name))
        {
            return false;
        }
        return true;
    }

    public bool NoTieneLetrasNumeros(string texto)
    {
        List<char> letras = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; //Terminar de escribir las letras

        List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //Terminar de escribir las letras
        List<char> letrasMin = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        List<char> algunosSimbolos = new List<char>() { ' ', '-' };
        // Le quitamos los posibles espacios que pueda llegar a tener adelante y atrás
        texto = texto.Trim();

        // Una var para ir revisando que todos los caracteres esten correctos
        bool formatoIncorrecto = true;
        foreach (char c in texto)
        {
            if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c) || algunosSimbolos.Contains(c))
            {
                formatoIncorrecto = false;
            }
            else
            {
                return true;
            }
        }
        return formatoIncorrecto;
    }

    public void EquiparArma(Arma arma)
    {
        if (Inventario.Elementos.Contains(arma))
        //if(Inventario.Armas.Contains(arma)) //ya no existe Ropas, todo es lo mismo, por ende podemos meterlo junto
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
        if (Inventario.Elementos.Contains(ropa))
        //if(Inventario.Ropas.Contains(ropa)) //ya no existe Ropas, todo es lo mismo, por ende podemos meterlo junto
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

    public void Curar(IPersonaje personaje)
    {
        personaje.Vida = 100;
    }
    public void Atacar(IPersonaje personaje)
    {
        if (this.ObtenerAtaqueTotal() >= personaje.ObtenerDefensaTotal())
        {
            personaje.Vida = personaje.Vida - (this.ObtenerAtaqueTotal() - personaje.ObtenerDefensaTotal());
        }
    }



    public void EquiparLibro(LibroHechizos libro)
    {
        if (this.Inventario.LibroDeHechizos != null)
        {
            LibroDeHechizosEquipado = libro;
        }
        else
        {
            Console.WriteLine("El mago no posee un libro de hechizos que pueda equipar");
        }
    }

    public void DesequiparLibro()
    {
        LibroDeHechizosEquipado = null;
    }

    // Zona dudosa


       public void ActualizarConocimiento()
      {
          
      }

       public void UsarHechizoDefensa(IPersonaje personaje, HechizoDefensa hechizo)
    {
        personaje.Defensa += hechizo.Defensa;
    } 

    public void AtacarConHechizo(IPersonaje personaje, HechizoAtaque hechizo)
    {
        if (hechizo.Ataque >= personaje.ObtenerDefensaTotal())
        {
            personaje.Vida = personaje.Vida - (hechizo.Ataque - personaje.ObtenerDefensaTotal());
        }
    }
    // Obtener Ataque Total 
    public int ObtenerAtaqueTotal()
    {
        int ataqueTotal = this.Fuerza;
        //int ataqueTotal = this.Ataque;
        if (this.ArmaEquipada != null)
        {
            ataqueTotal += this.ArmaEquipada.Ataque;

        }
        foreach (var item in this.Inventario.ElementosMagicos)
        {
            ataqueTotal += item.Ataque;
        }
        return ataqueTotal;



    }
    public int ObtenerDefensaTotal()
    {
        int defensaTotal = this.Defensa;
        foreach (var item in RopaEquipada)
        {
            defensaTotal += item.Defensa;
        }
        if (this.ArmaEquipada != null)
        {
            defensaTotal += this.ArmaEquipada.Defensa;
        }
        return defensaTotal; ;
    }

 public bool ValorMayorIgualCero(int valor)
        {
            if (valor < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

}