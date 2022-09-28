using System.Collections.Generic;

namespace Library;

/*
 Como identificamos características similares entre los elementos 
 que describía la letra, consideramos que era una buena idea
 separar por tipos, teniendo un tipo arma, otro ropa. Sin embargo
 esos tipos compartían características, por lo cual decidimos que 
 teníamos que definir un tipo que fuera común para ellos. De esa idea 
 surge este tipo IEquipamiento. 
*/
public interface IEquipamiento: IValidable  
{
    public string Name {get;}
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get;  }
}
