using System;
using System.Collections.Generic;

namespace Library;

public class Enano : IPersonaje
{
    public string Name { get; private set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida;
    public int Vida { get { return vida; } set { this.vida = value; } }

    public int Defensa { get; set; }
    public InventarioEnano Inventario { get; }

    public Arma ArmaEquipada { get; private set; }

    public List<Ropa> RopaEquipada { get; }

    public Enano(string name)
    {
        if (TextoValido(name))
        {
            this.Name = name.Trim();
        }
        else
        {
            this.Name = null;
        }
        this.Vida = 100;
        this.Defensa = 0;
        RopaEquipada = new List<Ropa>();
        Inventario = new InventarioEnano();
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

    public void Atacar(IPersonaje personaje)
    {

        if (this.ObtenerAtaqueTotal() >= personaje.ObtenerDefensaTotal())
        {
            int vidaNueva = personaje.Vida - (this.ObtenerAtaqueTotal() - personaje.ObtenerDefensaTotal());
            if (ValorMayorIgualCero(vidaNueva))
            {
                personaje.Vida = vidaNueva;
            }
            else
            {
                personaje.Vida = 0;
            }
        }
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
        int defensaTotal = this.Defensa;
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
        List<char> letras = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; 

        List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 
        List<char> letrasMin = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        List<char> algunosSimbolos = new List<char>() { ' ', '-' };
        List<char> conTilde = new List<char>{'á', 'é', 'í', 'ó', 'ú', 'Á', 'É', 'Ú','Í','Ó'};
        // Le quitamos los posibles espacios que pueda llegar a tener adelante y atras.
        texto = texto.Trim();

        // Una var para ir revisando que todos los caracteres esten correctos.
        bool formatoIncorrecto = true;
        foreach (char c in texto)
        {
                if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c) || algunosSimbolos.Contains(c) || conTilde.Contains(c))            {
                formatoIncorrecto = false;
            }
            else
            {
                return true;
            }
        }
        return formatoIncorrecto;
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