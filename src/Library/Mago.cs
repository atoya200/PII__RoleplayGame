namespace Library;

public class Mago : IPersonaje
{

    public string Name { get; private set; }
    private int fuerza = 10;
    public int Fuerza { get { return fuerza; } }
    private int vida = 100;
    public int Vida { get { return vida; } set { this.vida = value; } }

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

    public Mago(string name)
    {
        if (TextoValido(name))
        {
            this.Name = name;
        }
        else
        {
            this.Name = null;
        }
        RopaEquipada = new List<Ropa>();
        ElementosMagicosEquipados = new List<ElementoMagico>();
        Inventario = new InventarioMago();
    }
    public bool TextoValido(string name)
    {
        if (name == null || name.Length == 0 || NoTieneLetrasNumeros(name))
        {
            return false;
        }
        return true;
    }

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

   

    public void Curar(IPersonaje personaje)
    {
        personaje.Vida = 100;
    }
    // Para este método decidimos que el mago haga que la vida del personaje al que va a curar vuelva a ser 100, el cual es el mismo valor con el que "nace".

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
    // Para este método decidimos que el ataque de un personaje al otro va a ser el ataque total del atacante menos la defensa total del atacado. Si el resultado de esta resta es mayor o igual a 0, la nueva vida del personaje atacado será esta, sino el personaje morirá.



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

    public void DesequiparLibro()
    {
        LibroDeHechizosEquipado = null;
    }


    public void UsarHechizoDefensa(IPersonaje personaje, HechizoDefensa hechizo)
    {
        if(LibroDeHechizosEquipado.Hechizos.Contains(hechizo))
        {
            personaje.Defensa += hechizo.Defensa;
        }
    }

    public void AtacarConHechizo(IPersonaje personaje, HechizoAtaque hechizo)
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
    // Para este método decidimos que el ataque total dependa de tres cosas, la fuerza del personaje, el daño del arma equipada (si es que tiene) y el daño de los hechizos que tiene el mago (si es que tiene).
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
    // Para este método decidimos que el personaje puede tener varias piezas de armadura, por lo tanto, la defensa total va a ser la suma de cada pieza de armadura que tiene y la defensa del arma equipada, si es que el personaje tiene un arma equipada.
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