using System.Collections.Generic;
using System;

namespace Library;

    public class InventarioEnano: IInventario
    {
        
        public List<IEquipamiento> Elementos {get;private set;}
        
        public InventarioEnano()
        {
            Elementos = new List<IEquipamiento>();
        }
        public void AgregarElemento(IEquipamiento item)
        {
            this.Elementos.Add(item);
        }
        public void QuitarElemento(IEquipamiento item)
        {
            this.Elementos.Remove(item);
        }
        
         public void MostrarContenido()
        {
            this.ImprimirArmas();
            this.ImprmirRopa();
        } 

        public void ImprimirArmas()
        {
            Console.WriteLine("Armas");
            foreach(IEquipamiento item in this.Elementos)
            {
                if(item.Ataque !=0)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }
        }

          public void ImprmirRopa()
        {
            Console.WriteLine("Ropaje");
            foreach(IEquipamiento item in this.Elementos)
            {
                if(item.Ataque == 0)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }
        }

    }
