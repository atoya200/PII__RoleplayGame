using System.Collections.Generic;
namespace Library
{   
    /*
     Como iban a haber varias razas de personajes nos parecío mejor
     separar por tipo en base a las razas.  Poniendo lo que tenían en común
     como un tipo.
    */
    public interface IPersonaje: IValidable
    {
        public int Vida {get;set;}
        public string Name {get;}
        public int Fuerza  {get;}

        public int Defensa {get;set;}

        // Defenimimos que por ahora el personaje pueda tener equipada solamente un arma
        public Arma ArmaEquipada {get;}

        // El personaje puede tener más de una prenda puesta, como armadura, botas, casco, etc.
        public List<Ropa> RopaEquipada {get;}

        /* Pensamos que por más que la ropa o el arma este en el inventario, 
          no tenía por que usarse toda o estar usandose en todo momento.
          Por eso surge la idea de "equipado", que es cuando sale del inventario
          y lo usa el personaje. De ahí tenemos la RopaEquipada, el ArmaEquipada
          en el caso de los tres personajes. En cambio, mago también tiene dos más de "equipado"
          que se refeieren al libro y a los elementos mágicos.
        */
        public void EquiparRopa(Ropa ropa);
        public void QuitarRopa(Ropa ropa);

        public void EquiparArma(Arma arma);
        public void DesequiparArma();

        /* 
         Con esta definición, el método atacar es polimórfico y no hay que 
         preguntar por el tipo del personaje que se quiere atacar o al que se va a atacar. 
        */ 
        public void Atacar(IPersonaje personaje);
        public int ObtenerAtaqueTotal();
        public int ObtenerDefensaTotal();
    }
    
}