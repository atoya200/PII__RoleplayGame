namespace Library;

public class Mago : IPersonaje
{

    public string Name { get; private set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida = 100;
    public int Vida { get { return vida; } set { this.vida = value; } }

    // Cómo decía que el libro de hechizos decidimos que cuanto más páginas tenga ese libro, más puntos 
    // de conocimiento tendría ese mago. 
    public int Conocimiento
    {
        get
        {
            if (this.LibroDeHechizosEquipado != null)
            {

                return Inventario.LibroDeHechizos.Hechizos.Count();

            }
            else
            {
                return 0;
            }
        }
    }

    public int Defensa { get; set; }

    public InventarioMago Inventario { get; }

    public Arma ArmaEquipada { get; set; }

    public List<Ropa> RopaEquipada { get; }
    public List<ElementoMagico> ElementosMagicosEquipados { get; private set; }

    public LibroHechizos LibroDeHechizosEquipado { get; private set; }

   /* 
     El constructor esta diseñado para que verifique si el valor ingresado es correcto.
     En caso de serlo asigna el valor recibido a la propiedad correspondiente.
     En el caso contrario le asigna null a la propiedad como forma de no dejar pasar datos erroneos.
     También crea la lista que necesita para almacenar la ropa que tenga puesta el personaje, y
     crea un objeto correspondiente a su inventario. También en este caso instancia una lista para 
     albergar los elementos mágicos. 
     Cada personaje tendrá un tipo de inventario para si mismo para así mantener el polimorfismo
     y no tener que hacer un control con tipos para validar si un personaje puede o no tener cierto
     objeto, como ser el libro de hechizos que solo lo puede usar el mago.
    */ 
    public Mago(string name)
    {
        if (TextoValido(name))
        {
            this.Name = name.Trim();
        }
        else
        {
            this.Name = null;
        }
        RopaEquipada = new List<Ropa>();
        ElementosMagicosEquipados = new List<ElementoMagico>();
        Inventario = new InventarioMago();
        this.Defensa = 0;
    }
    
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

    public void DesequiparArma()
    {
        this.ArmaEquipada = null;
    }
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

    public void QuitarRopa(Ropa ropa)
    {
        this.RopaEquipada.Remove(ropa);
    }

    public void EquiparElementoMagico(ElementoMagico elemento)
    {

        if (Inventario.ElementosMagicos.Contains(elemento))
        {
            this.ElementosMagicosEquipados.Add(elemento);
        }
        else
        {
            Console.WriteLine("Este elemento mágico no esta en el inventario");
        }
    }

    public void DesequiparElementoMagico(ElementoMagico elemento)
    {
        this.ElementosMagicosEquipados.Remove(elemento);
    }

   
    // Para este método decidimos que el mago haga que la vida del personaje al que va a curar vuelva a ser 100, el cual es el mismo valor con el que "nace".
    public void Curar(IPersonaje personaje)
    {
        personaje.Vida = 100;
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


    // Asinganos un libro, para que pueda usar sus hechizos. Queda equipado si es que el libro existe en el inventario.
    public void EquiparLibro(LibroHechizos libro)
    {
        if (this.Inventario.LibroDeHechizos != null)
        {
            LibroDeHechizosEquipado = libro;
        }
        else
        {
            Console.WriteLine("El mago no posee un libro de hechizos que pueda equipar");
        }
    }
    // Hacemos que el libro que tenía deje de estar equipado, cargando con null la propiedad. s
    public void DesequiparLibro()
    {
        LibroDeHechizosEquipado = null;
    }

    /* 
     Como el mago puede también usar hechizos de defensa, lo que haría sería subirle la 
     defensa a un personaje. Si este esta en el libro de hechizos que el mago tiene equipado, podría usarlo. 
     Si no esta en el libro o el libro no esta equipado, no podrá hacer uso de ese conjuro.
    */
    public void UsarHechizoDefensa(IPersonaje personaje, HechizoDefensa hechizo)
    {
        if(LibroDeHechizosEquipado.Hechizos.Contains(hechizo))
        {
            personaje.Defensa += hechizo.Defensa;
        }
        else
       {
        Console.WriteLine("El hechizo no pertenece al libro que esta equipado o no hay un libro equipado en este momento");
       }
    }
    /*
     Como el mago puede usar los hechizos, creamos este método para que haga uso de ellos. 
     Para poder usar un hechizo de Ataque, debe tener que espcificar cual es (lo pasa por parámetros), 
     y si este esta en el libro de hechizos que el mago tiene equipado, podría usarlo. 
     Si no esta en el libro o el libro no esta equipado, no podrá hacer uso de ese conjuro.
    */
    public void AtacarConHechizo(IPersonaje personaje, HechizoAtaque hechizo)
    {
       if(this.LibroDeHechizosEquipado.Hechizos.Contains(hechizo))
       {
        if (hechizo.Ataque >= personaje.ObtenerDefensaTotal())
        {
            int vidaNueva = personaje.Vida - (hechizo.Ataque - personaje.ObtenerDefensaTotal());
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
       else
       {
        Console.WriteLine("El hechizo no pertenece al libro que esta equipado o no hay un libro equipado en este momento");
       }
        
         
    }
    /*
     Para este caso pensamos que el mago podría tener varios elementos mágicos con los cuales 
     atacar, por ende  hacemos que especifique cuan cual quiere hacer el ataque al otro personaje.
    */
     public void AtacarConElementoMagico(IPersonaje personaje, ElementoMagico elemento)
    {
       
        if (elemento.Ataque >= personaje.ObtenerDefensaTotal() && this.ElementosMagicosEquipados.Contains(elemento))
        {
            int vidaNueva = personaje.Vida - (elemento.Ataque - personaje.ObtenerDefensaTotal());
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
        int ataqueTotal = this.Fuerza;
        if (this.ArmaEquipada != null)
        {
            ataqueTotal += this.ArmaEquipada.Ataque;

        }
        foreach (var item in this.Inventario.ElementosMagicos)
        {
            ataqueTotal += item.Ataque;
        }
        return ataqueTotal;
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
        return defensaTotal; ;
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
        List<char> conTilde = new List<char> { 'á', 'é', 'í', 'ó', 'ú', 'Á', 'É', 'Ú', 'Í', 'Ó' };
        // Le quitamos los posibles espacios que pueda llegar a tener adelante y atras.
        texto = texto.Trim();

        // Una var para ir revisando que todos los caracteres esten correctos.
        bool formatoIncorrecto = true;
        foreach (char c in texto)
        {
            if (letras.Contains(c) || numeros.Contains(c) || letrasMin.Contains(c) || algunosSimbolos.Contains(c) || conTilde.Contains(c))
            {
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