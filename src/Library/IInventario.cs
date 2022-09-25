using System.Collections.Generic;
using System;

namespace Library;

    public interface IInventario
    {
        
      public List<Arma> Armas {get;} 
       public List<Ropa> Ropas  {get;}
        
        public void AgregarRopa(Ropa prenda);
        
        public void QuitarRopa(Ropa prenda);
        

        public void AgregarArma(Arma arma);
       
        public void QuitarArma(Arma arma);
       
       

    }
