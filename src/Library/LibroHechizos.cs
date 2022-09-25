using System.Collections.Generic;
using System;
namespace Library
{
    public class LibroHechizos: IEquipamiento
    {
        public string Name {get; private set;}
        public string Descripcion { get; private set; }

        public List<IHechizo> Hechizos { get; private set; }    
        public int Ataque
        {
            get
            {
                int valor = 0;
                foreach (IHechizo item in Hechizos)
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
                foreach (IHechizo h in Hechizos)
                {
                    valor += h.Defensa;
                }
                return valor;
            }
        }

        public LibroHechizos(string name, string descripcion)
        {
            // Para hacer que se eliminen espacios innecesarios al inicio o al final del string.
            if (TextoValido(name))
            {
                this.Name = name;
            }
            else
            {
                this.Name = null;
            }
             if (TextoValido(descripcion))
            {
                this.Descripcion = descripcion;
            }
            else
            {
                this.Descripcion = null;
            }
            Hechizos = new List<IHechizo>();
        }

        public void AgregarHechizo(IHechizo h)
        {
            this.Hechizos.Add(h);
        }

        public void QuitarHechizo(IHechizo h)
        {
            this.Hechizos.Remove(h);
        }

        public void ImprimirHechizos()
        {
            foreach (var hechizo in Hechizos)
            {
                Console.WriteLine($"Descripción: {hechizo.Descripcion} \nValor de Ataque {hechizo.Ataque} \nValor de defensa {hechizo.Defensa}");
            }
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
                if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c) || algunosSimbolos.Contains(c) || conTilde.Contains(c))                {
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
}
