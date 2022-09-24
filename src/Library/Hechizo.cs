using System.Collections.Generic;

namespace Library;

public class Hechizo : IValidable
{
    public string Descripcion { get; }
    public string Tipo { get; }
    public int Ataque { get; }
    public int Defensa { get; }

    public Hechizo(string descripcion, string tipo, int ataque, int defensa)
    {
        if (TextoValido(descripcion))
        {
            this.Descripcion = descripcion;
        }
        else
        {
            this.Descripcion = null;
        }
        this.Ataque = ataque;
        this.Defensa = defensa;
        if (ValidType(tipo))
        {
            this.Tipo = tipo;
        }
        else
        {
            this.Tipo = null;
        }
    }
    public bool TextoValido(string nombre)
    {
        if (nombre == null || nombre.Length == 0 || NoTieneLetrasNumeros(nombre))
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

    public bool ValidType(string tipo)
    {
        List<string> tipos = new List<string>() { "Ataque", "ataque", "Defensa", "defensa", "Curación", "curación" };
        if (tipos.Contains(tipo))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
