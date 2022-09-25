namespace Library;
public class HechizoDefensa : IHechizo
{
    public string Descripcion { get; }
    public int Ataque { get; }
    public int Defensa { get; }

    public HechizoDefensa(string descripcion, int defensa)
    {
        if (TextoValido(descripcion))
        {
            this.Descripcion = descripcion;
        }
        else
        {
            this.Descripcion = null;
        }
        this.Ataque = 0;
        if (ValorMayorIgualCero(defensa))
        {
            this.Defensa = defensa;
        }
        else
        {
            this.Defensa = 0;
        }

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