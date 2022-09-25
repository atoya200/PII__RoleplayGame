using System.Collections.Generic;
namespace Library
{   
    public interface IPersonaje: IValidable
    {
        public int Vida {get;set;}
        public string Name {get;}
        public int Fuerza  {get;}

        public int Defensa {get;set;}

        public Arma ArmaEquipada {get;}

        public List<Ropa> RopaEquipada {get;}

        public void EquiparRopa(Ropa ropa);
        public void QuitarRopa(Ropa ropa);

        public void EquiparArma(Arma arma);
        public void DesequiparArma();

        //public IInventario Inventario {get;}

        public void Atacar(IPersonaje personaje);
        public int ObtenerAtaqueTotal();
        public int ObtenerDefensaTotal();
    }
    
}