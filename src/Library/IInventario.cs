using System.Collections.Generic;
using System;

namespace Library;

    public interface IInventario
    {
        
        public List<IEquipamiento> Elementos {get;}
        
        
        public void AgregarElemento(IEquipamiento item);
      
        public void QuitarElemento(IEquipamiento item);
        
        
         public void MostrarContenido();
       

    }
