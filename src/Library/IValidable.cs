using System.Collections.Generic;
namespace Library;

/* 
    Usamos esta interface para que todos los tipos que necesiten hacer una validación
    tengan las operaciones para validar marcadas de por si. Además si necesitan que el 
    comportamiento sea diferente en base a la clase en cuestión, de esa forma es posible. 
*/
    public interface IValidable
    {
        public bool TextoValido(string texto); 
        public bool NoTieneLetrasNumeros(string texto);
        public bool ValorMayorIgualCero(int valor);
    }