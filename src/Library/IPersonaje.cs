using System.Collections.Generic;
namespace Library
{   
    public interface IPersonaje
    {
        public int Vida {get;set;}
        public string Nombre {get; set;}
        public int Fuerza  {get;}

        public Arma ArmaEquipada {get;}

        public List<Ropa> RopaEquipada {get;}

        public void EquiparRopa(Ropa ropa);
        public void QuitarRopa(Ropa ropa);

        public void EquiparArma(Arma arma);
        public void DesequiparArma();

        public Inventario Inventario {get;}

        public void Atacar(IPersonaje personaje);
        public int ObtenerAtaqueTotal();
        public int ObtenerDefensaTotal();
    }
    
}