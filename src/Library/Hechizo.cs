using System.Collections.Generic;

namespace Library;

    public class Hechizo: IValidable
    {
        public string Descripcion {get;}
        public string Tipo {get;}
        public int Ataque {get;}
        public int Defensa {get;}

        public Hechizo(string descripcion, string tipo, int ataque, int defensa)
        {
            if(TextoValido(descripcion))
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
            
            foreach (char c in nombre)
            {
             if(letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c))
             {
                return false;
            }
             }

            return true;
        }

        public bool ValidType(string tipo)
        {
            List<string> tipos  = new List<string>() {"Ataque","ataque","Defensa","defensa","Curación","curación"};
            if(tipos.Contains(tipo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
