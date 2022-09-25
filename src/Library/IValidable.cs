using System.Collections.Generic;
namespace Library;

    public interface IValidable
    {
        public bool TextoValido(string name); 
        public bool ValorMayorIgualCero(int valor);
    }