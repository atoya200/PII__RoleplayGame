using System.Collections.Generic;

namespace Library;

public interface IEquipamiento   // REVISAR NOMENCLATURAS PARA ESTAR TODO IGUAL
{
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get;  }
}
