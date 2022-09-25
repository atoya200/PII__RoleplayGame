using System.Collections.Generic;
using System;

namespace Library;

    public class InventarioMago: IInventario
    {
        
        public List<IEquipamiento> Elementos {get;private set;}
        public List<ElementoMagico> ElementosMagicos {get;private set;}

        public LibroHechizos LibroDeHechizos {get;  private set;}
        
        public InventarioMago()
        {
            Elementos = new List<IEquipamiento>();
            ElementosMagicos = new List<ElementoMagico>();
        }
        public void AgregarElemento(IEquipamiento item)
        {
            this.Elementos.Add(item);
        }
        public void QuitarElemento(IEquipamiento item)
        {
            this.Elementos.Remove(item);
        }

        // Nuevo falta hacer test
            public void AgregarLibro(LibroHechizos libro)
            {
                this.LibroDeHechizos = libro;
            }

            public void QuitarLibro(LibroHechizos libro)
            {
                this.LibroDeHechizos = null;
            }

            public void AgregarElementoMagico(ElementoMagico elemento)
            {
                this.ElementosMagicos.Add(elemento);
            }

            
            public void QuitarElementoMagico(ElementoMagico elemento)
            {
                this.ElementosMagicos.Remove(elemento);
            }
        // Nuevo
        
          public void MostrarContenido()
        {
            this.ImprimirArmas();
            this.ImprmirRopa();
            this.ImprmirElementosMagicos();
            this.ImprmirLibroHechizos();
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

            public void ImprmirElementosMagicos()
        {
            Console.WriteLine("Elmentos magicos");
            foreach(ElementoMagico item in this.ElementosMagicos)
            {
                    Console.WriteLine($"{item.Name}");
            }
        }
            public void ImprmirLibroHechizos()
        {
            if(this.LibroDeHechizos != null)
            {
            Console.WriteLine("Libro de hechizos {1} contiene los siguientes hechizos", LibroDeHechizos.Name );
            foreach(IHechizo hechizo in this.LibroDeHechizos.Hechizos)
            {
                    Console.WriteLine($"{hechizo.Descripcion}");
            }
            } 
            else
            {
                Console.WriteLine("No hay un libro de hechizos en el inventario");
            }
            
        }



    }
