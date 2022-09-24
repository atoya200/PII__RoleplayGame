using System.Collections.Generic;
using System;
namespace Library
{
    public class LibroHechizos : IEquipamiento, IValidable
    {
        public string Descripcion { get; set; }

        public LibroHechizos(string nombre)
        {
            // Para hacer que se eliminen espacios innecesarios al inicio o al final del string.
            if (TextoValido(nombre))
            {
                this.Descripcion = nombre;
            }
            else
            {
                this.Descripcion = null;
            }
        }
        public List<Hechizo> Hechizos { get; private set; } = new List<Hechizo>();

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

        public int Ataque
        {
            get
            {
                int valor = 0;
                foreach (Hechizo item in Hechizos)
                {
                    valor += item.Ataque;
                }
                return valor;
            }
        }

        public int Defensa
        {
            get
            {
                int valor = 0;
                foreach (Hechizo h in Hechizos)
                {
                    valor += h.Defensa;
                }
                return valor;
            }
        }

        public void AgregarHechizo(Hechizo h)
        {
            this.Hechizos.Add(h);
        }

        public void QuitarHechizo(Hechizo h)
        {
            this.Hechizos.Remove(h);
        }

        public void ImprimirHechizos()
        {
            foreach (var hechizo in Hechizos)
            {
                Console.WriteLine($"Descripción: {hechizo.Descripcion} \nValor de Ataque {hechizo.Ataque} \nValor de defensa {hechizo.Defensa} \nTipo de hechizo {hechizo.Tipo}");
            }
        }




    }
}