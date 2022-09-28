using System;
using System.Collections.Generic;

namespace Library;

public class Enano : IPersonaje
{
    public string Name { get; private set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida;
    public int Vida { get { return vida; } set { this.vida = value; } }

    public int Defensa { get; set; }
    public InventarioEnano Inventario { get; }

    public Arma ArmaEquipada { get; private set; }

    public List<Ropa> RopaEquipada { get; }

    /* 
      El constructor esta diseñado para que verifique si el valor ingresado es correcto.
      En caso de serlo asigna el valor recibido a la propiedad correspondiente.
      En el caso contrario le asigna null a la propiedad como forma de no dejar pasar datos erroneos.
      También crea la lista que necesita para almacenar la ropa que tenga puesta el personaje y
      crea un objeto correspondiente a su inventario.
      Cada personaje tendrá un tipo de inventario para si mismo para así mantener el polimorfismo
      y no tener que hacer un control con tipos para validar si un personaje puede o no tener cierto
      objeto, como ser el libro de hechizos que solo lo puede usar el mago.
    */ 
    public Enano(string name)
    {
        if (TextoValido(name))
        {
            this.Name = name.Trim();
        }
        else
        {
            this.Name = null;
        }
        // En todos los personajes elegimos asignarle por defecto una vida de 100
        this.Vida = 100;
        /*
         En todos los personajes menos el Enano les pusimos una defensa de 0 por defecto.
         Este caso es una excepción por que la letra decía son resistentes, entonces para 
         represetnar ese hecho le asignamos una defensa  más alta que el resto.
        */
        this.Defensa = 20;
        RopaEquipada = new List<Ropa>();
        Inventario = new InventarioEnano();
    }
    /* 
     Acá lo que hacemos es equipar el arma que es recibida por parámetros, si es que existe en
     inventario carga la propiedad ArmaEquipada con esa arma.
    */
    public void EquiparArma(Arma arma)
    {
        if (Inventario.Armas.Contains(arma))
        {
            this.ArmaEquipada = arma;
        }
        else
        {
            Console.WriteLine("Esa arma no esta en el inventario");
        }
    }
    /* 
     Este método lo que hace es dejar vacía el arma equipada, haciendo el proceso de desequipar el arma, ya que
     esta seguirá estando en el inventario pero no se sumara a los ataques o a la defensa (si es que tiene valor de defensa).
    */ 
    public void DesequiparArma()
    {
        this.ArmaEquipada = null;
    }
    // Se encarga de equipar la ropa que le llega como parámetro si es que existe en el inventario.
    // Si la prenda no esta en el inventario le avisa por consola que no se puede realizar la acción.
    public void EquiparRopa(Ropa ropa)
    {
        if (Inventario.Ropas.Contains(ropa))
        {
            this.RopaEquipada.Add(ropa);
        }
        else
        {
            Console.WriteLine("Ese ropaje no esta en el inventario");
        }
    }
    // Se encarga de quitar la ropa que hay equipada, si es que esa prenda fue realmente equipada.
    public void QuitarRopa(Ropa ropa)
    {
        this.RopaEquipada.Remove(ropa);
    }
    /* 
     Para este método decidimos que el ataque de un personaje al otro va a
     ser el ataque total del atacante menos la defensa total del atacado.
     Si el resultado de esta resta es mayor o igual a 0, la nueva vida del 
     personaje atacado será esta, sino el personaje morirá y su vida será 0.
    */ 
    public void Atacar(IPersonaje personaje)
    {

        if (this.ObtenerAtaqueTotal() >= personaje.ObtenerDefensaTotal())
        {
            int vidaNueva = personaje.Vida - (this.ObtenerAtaqueTotal() - personaje.ObtenerDefensaTotal());
            if (ValorMayorIgualCero(vidaNueva))
            {
                personaje.Vida = vidaNueva;
            }
            else
            {
                personaje.Vida = 0;
            }
        }
    }
    /* 
     Para este método decidimos que el ataque total dependa de dos cosas, la fuerza del personaje
     y la fuerza del arma que tiene equipada, si es que tiene. Si no tiene un arma su ataque va a ser
     su fuerza normal. En caso de tener, se suma la fuerza al daño que hace el arma. 
    */
    public int ObtenerAtaqueTotal()
    {
        if (this.ArmaEquipada == null)
        {
            return this.Fuerza;
        }
        else
        {
            return this.Fuerza + this.ArmaEquipada.Ataque;
        }

    }
    /* 
     Para este método decidimos que el personaje puede tener varias piezas de armadura, por lo tanto, 
     la defensa total va a ser la suma de cada pieza de armadura que tiene. A su vez, como el arma puede
     también de defensa, sumamos la defensa del item que esta equipada, si es que el personaje tiene un arma equipada.
    */
    public int ObtenerDefensaTotal()
    {
        int defensaTotal = this.Defensa;
        foreach (var item in RopaEquipada)
        {
            defensaTotal += item.Defensa;
        }
        if (this.ArmaEquipada != null)
        {
            defensaTotal += this.ArmaEquipada.Defensa;
        }
        return defensaTotal;
    }
    /*
     Este método revisa si el string que le llega es nulo, vacío
     o tiene un formato inadecuado. En cualquiera de los tres casos
     devuelve false, ya que el texto no es valido. Si el formato es 
     correcto y no es ni un string vacío ni un null, devuelve true.  
    */
    public bool TextoValido(string texto)
    {
        if (texto== null || texto.Length == 0 || NoTieneLetrasNumeros(texto))
        {
            return false;
        }
        return true;
    }
    /*
     Este método lo que hace es verificar que el texto esta correcto o no.
     En caso de no tener letras, números o algunos simbolos devolverá true,
     ya que no es un formato correcto. En caso de que tenga el formato adecuado
     devolvera false. 
    */
    public bool NoTieneLetrasNumeros(string texto)
    {
        List<char> letras = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; 

        List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 
        List<char> letrasMin = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        List<char> algunosSimbolos = new List<char>() { ' ', '-' };
        List<char> conTilde = new List<char>{'á', 'é', 'í', 'ó', 'ú', 'Á', 'É', 'Ú','Í','Ó'};
        // Le quitamos los posibles espacios que pueda llegar a tener adelante y atras.
        texto = texto.Trim();

        // Una var para ir revisando que todos los caracteres esten correctos.
        bool formatoIncorrecto = true;
        foreach (char c in texto)
        {
                if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c) || algunosSimbolos.Contains(c) || conTilde.Contains(c))            {
                formatoIncorrecto = false;
            }
            else
            {
                return true;
            }
        }
        return formatoIncorrecto;
    }
    /* 
     Este método se encarga de validar que un valor no sea inferior a cero.
     Si ese es el caso devuelve false, y en el caso contrario devuleve true, 
     ya que el valor será 0 o mayor que cero.
    */
    public bool ValorMayorIgualCero(int valor)
    {
        if (valor < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}