using System.Collections.Generic;

namespace Library
{
    public class Ropa: IEquipamiento
    {
        public string Name{get;private set;}
        public string Descripcion{get;private set;}
        public int Ataque{get;private set;}
        public int Defensa{get;private set;}
        public Ropa(string nombre, string Descripcion, int Ataque, int Defensa)
        {
            if(TextoValido(nombre))
            {
                this.Name = nombre;
            }
            else
            {
                this.Name = null;
            }
            this.Descripcion = Descripcion;
            this.Ataque = Ataque;
            this.Defensa = Defensa;
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
        
    }
}
