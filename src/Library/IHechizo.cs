namespace Library;
public interface IHechizo : IValidable
{
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get; }

}