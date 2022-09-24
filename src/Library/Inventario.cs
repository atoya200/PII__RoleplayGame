using System.Collections.Generic;
using System;

namespace Library;

    public class Inventario
    {
        
        public List<Arma> Armas {get;} = new List<Arma>();
        public List<Ropa> Ropas  {get; private set;}= new List<Ropa>();
        
        public void AgregarRopa(Ropa prenda)
        {
            this.Ropas.Add(prenda);
        }
        public void QuitarRopa(Ropa prenda)
        {
            this.Ropas.Remove(prenda);
        }

          public void AgregarArma(Arma arma)
        {
            this.Armas.Add(arma);
        }
        public void QuitarArma(Arma arma)
        {
            this.Armas.Remove(arma);

        }
         

        
         public void MostrarContenido()
        {
            Console.WriteLine("Armas");
            foreach(Arma a in this.Armas)
            {
                Console.WriteLine($"{a.Descripcion}");
            }
            Console.WriteLine("Ropas");
            foreach(Ropa r in this.Ropas)
            {
                Console.WriteLine($"{r.Descripcion}");
            }
            Console.WriteLine("Libros de Hechizos");
            

        } 

    }
