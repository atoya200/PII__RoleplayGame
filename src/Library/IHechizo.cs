namespace Library;
/*
 Definimos que podrían haber varios tipos de hechizos
 pero que todos tendría que tener algo en común
 el tipo Hechizo. Este contiene las propiedades que 
 podrían tener todos los diferentes tipos de hechizo: 
 descripción, ataque y defensa. Esto último por que al 
 igual que las armas podrían haber hechizos que ataquen
 y defiendan. 
*/ 
public interface IHechizo : IValidable
{
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get; }
}