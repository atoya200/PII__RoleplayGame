using System;
using System.Collections.Generic;

namespace Library
{
    public class Arma : IEquipamiento
    {
        public string Name { get; private set; }
        public string Descripcion { get; private set; }
        public int Ataque { get; private set; }
        public int Defensa { get; private set; }
        public Arma(string nombre, string descripcion, int ataque, int defensa)
        {
            if (TextoValido(nombre))
            {
                this.Name = nombre.Trim();
            }
            else
            {
                this.Name = null;
            }
            if (TextoValido(descripcion))
            {
                this.Descripcion = descripcion.Trim();
            }
            else
            {
                this.Descripcion = null;
            }
            if (ValoresDefensaAtaqueValidos(ataque))
            {
                this.Ataque = ataque;
            }
            else
            {
                this.Ataque = 0;
            }
            if (ValoresDefensaAtaqueValidos(defensa))
            {
                this.Defensa = defensa;
            }
            else
            {
                this.Defensa = 0;
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

        public bool ValoresDefensaAtaqueValidos(int valor)
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
}
