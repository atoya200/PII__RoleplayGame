namespace Library;
public class HechizoAtaque : IHechizo
{
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get; }
    /* 
     El constructor esta diseñado para que verifique si el valor ingresado es correcto.
     En caso de serlo asigna el valor recibido a la propiedad correspondiente.
     En el caso contrario le asigna null a la propiedad como forma de no dejar pasar datos erroneos.
    */ 
    public HechizoAtaque(string descripcion, int ataque)
    {
        if (TextoValido(descripcion))
        {
            this.Descripcion = descripcion.Trim();
        }
        else
        {
            this.Descripcion = null;
        }
        this.Defensa = 0;
        if (ValorMayorIgualCero(ataque))
        {
            this.Ataque = ataque;
        }
        else
        {
            this.Ataque = 0;
        }

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