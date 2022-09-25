using System.Collections.Generic;

namespace Library;

public interface IEquipamiento: IValidable  
{
    public string Name {get;}
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get;  }
}
