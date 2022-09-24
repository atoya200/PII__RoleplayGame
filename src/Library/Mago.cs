using System;
using System.Collections.Generic;

namespace Library;

public class Mago : IPersonaje
{

    public string Nombre { get; set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida = 100;
    public int Vida { get { return vida; } set { this.vida = value; } }

    // Si se quiere usar hechizos que aumenten la defensa tendría que haber un valor de defensa nato que luego pueda aumentarse
    public int Defensa {get; private set;}
    public Inventario Inventario { get; }

    public LibroHechizos LibroDeHechizos { get; private set; }

    public int NivelMagico { get; set; }

    public Arma ArmaEquipada { get; set; }

    public List<Ropa> RopaEquipada { get; }

    public Mago(int vida, string nombre)
    {
        if (TextoValido(nombre))
        {
            this.Nombre = nombre;
        }
        else
        {
            this.Nombre = null;
        }
        RopaEquipada = new List<Ropa>();
        Inventario = new Inventario();
    }
    public bool TextoValido(string nombre)
    {
        if (nombre == null || nombre.Length == 0 || NoTieneLetrasNumeros(nombre))
        {
            return false;
        }
        return true;
    }

    public bool NoTieneLetrasNumeros(string nombre)
    {
        List<char> letras = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X', 'Y', 'Z' }; //Terminar de escribir las letras
        List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //Terminar de escribir las letras
        List<char> letrasMin = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'v', 'x', 'y', 'z' }; ;
        // Una var para ir revisando que todos los caracteres esten correctos
        bool formatoIncorrecto = false;
        foreach (char c in nombre)
        {
            if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c))
            {
                formatoIncorrecto = formatoIncorrecto && true;
            }
            else
            {
                formatoIncorrecto = formatoIncorrecto && false;
            }
        }

        return formatoIncorrecto;
    }

    public void EquiparArma(Arma arma)
    {
        if (Inventario.Armas.Contains(arma))
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
        if (Inventario.Ropas.Contains(ropa))
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

    public void UsarHechizoDefensa(Hechizo hechizo)
    {
        if(hechizo.Tipo == "Defensa")
        {
            
        }
    }

    public void AtacarConHechizo(IPersonaje personaje, Hechizo hechizo)
    {
        if(hechizo.Tipo == "Ataque")
        {
        if (hechizo.Ataque >= personaje.ObtenerDefensaTotal())
        {
            personaje.Vida = personaje.Vida - (hechizo.Ataque - personaje.ObtenerDefensaTotal());
        }
        }
        else
        {
            Console.WriteLine($"Este hechizo es de tipo {hechizo.Tipo}, por lo que no puede usarse para atacar");
        }
        

    }

    // Obtener Ataque Total 
    public int ObtenerAtaqueTotal()
    {
        int ataqueTotal = this.Fuerza;


        if (this.ArmaEquipada != null)
        {
            ataqueTotal += this.ArmaEquipada.Ataque;

        }
        if (this.LibroDeHechizos != null)
        {
            ataqueTotal += this.LibroDeHechizos.Defensa;

        }

        return ataqueTotal;



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
        if(this.LibroDeHechizos != null)
        {
            defensaTotal += this.LibroDeHechizos.Defensa;
        }

        return defensaTotal;
    }

    public void AgregarLibro(LibroHechizos libro)
    {
        this.LibroDeHechizos = libro;
    }
    public void QuitarLibro(LibroHechizos libro)
    {
        this.LibroDeHechizos = null;
    }
}