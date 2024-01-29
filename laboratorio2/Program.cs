using System;
using System.Collections.Generic;
using System.Linq;


public class Ball
{
    // Atributos de la pelota con getters y setters abreviados
    public string Color { get; set; }
    public double Hardness { get; set; }
    public double Volume { get; set; }
    public double Weight { get; set; }
    private double radius;

    // Propiedad Radius con validación
    public double Radius
    {
        get { return radius; }
        set
        {
            if (value >= 0)
                radius = value;
            else
                Console.WriteLine("Error: El radio no puede ser negativo.");
        }
    }

    // Constructor para inicializar atributos
    public Ball(string color, double hardness, double volume, double weight, double radius)
    {
        Color = color;
        Hardness = hardness;
        Volume = volume;
        Weight = weight;
        Radius = radius;
    }

    // Métodos que simulan acciones con la pelota
    public void Bounce() => Console.WriteLine("La pelota está rebotando.");
    public void Roll() => Console.WriteLine("La pelota está rodando.");
    public void Crush() => Console.WriteLine("La pelota ha sido aplastada.");
    public void Deflate() => Console.WriteLine("La pelota se ha desinflado.");

    // Método que calcula la densidad de la pelota
    public double CalculateDensity() => Weight / Volume;

    // Método que realiza una comparación de dureza con otra pelota
    public void CompareHardness(Ball otherBall)
    {
        string message = Hardness > otherBall.Hardness
            ? "Esta pelota es más dura que la otra."
            : Hardness < otherBall.Hardness
                ? "Esta pelota es menos dura que la otra."
                : "Ambas pelotas tienen la misma dureza.";

        Console.WriteLine(message);
    }
}


// Herencia

public class Robot2D
{
    public int PosicionX { get; set; }
    public int PosicionY { get; set; }
    public double Orientacion { get; set; }

    // Constructor
    public Robot2D(int x, int y, double orientacion)
    {
        PosicionX = x;
        PosicionY = y;
        Orientacion = orientacion;
    }

    // Mover el robot
    public void Mover(double distancia)
    {
        // Calcular las nuevas coordenadas basadas en la orientación y la distancia
        PosicionX += (int)(distancia * Math.Cos(Math.PI * Orientacion / 180));
        PosicionY += (int)(distancia * Math.Sin(Math.PI * Orientacion / 180));
    }

    // Girar el robot
    public void Girar(double angulo)
    {
        // Ajustar la orientación según el ángulo proporcionado
        Orientacion += angulo;
    }

    // Obtener la posición actual del robot
    public (int x, int y) ObtenerPosicion()
    {
        return (PosicionX, PosicionY);
    }

    // Obtener la orientación actual del robot
    public double ObtenerOrientacion()
    {
        return Orientacion;
    }
}

public class PracticaStrings
{
    private string cadena;

    public string Cadena
    {
        get { return cadena; }
        set { cadena = value; }
    }

    public PracticaStrings(string inputCadena)
    {
        Cadena = inputCadena;
    }

    public string EncontrarSubcadenaRepetida()
    {
        // Utilizar LINQ para encontrar la secuencia más larga de caracteres repetidos
        var subcadenaRepetida = Cadena.GroupBy(c => c)
                                       .OrderByDescending(group => group.Count())
                                       .First()
                                       .Key;

        return new string(subcadenaRepetida, Cadena.Count(c => c == subcadenaRepetida));
    }

    // Método para encontrar la subcadena más larga de caracteres no repetidos consecutivamente
    public string EncontrarSubcadenaNoRepetida()
    {
        int inicio = 0, longitudActual = 0;
        int inicioMejor = 0, longitudMejor = 0;

        Dictionary<char, int> ultimoIndice = new Dictionary<char, int>();

        for (int i = 0; i < Cadena.Length; i++)
        {
            if (ultimoIndice.ContainsKey(Cadena[i]) && ultimoIndice[Cadena[i]] >= inicio)
            {
                inicio = ultimoIndice[Cadena[i]] + 1;
                longitudActual = i - inicio + 1;
            }
            else
            {
                longitudActual++;
            }

            ultimoIndice[Cadena[i]] = i;

            if (longitudActual > longitudMejor)
            {
                longitudMejor = longitudActual;
                inicioMejor = inicio;
            }
        }

        return Cadena.Substring(inicioMejor, longitudMejor);
    }

    // Operador sobrecargado para concatenar dos instancias de la clase PracticaStrings
    public static PracticaStrings operator +(PracticaStrings a, PracticaStrings b)
    {
        return new PracticaStrings(a.Cadena + b.Cadena);
    }

    public override string ToString()
    {
        return $"Cadena actual: {Cadena}";
    }
}

public class CarritoDeCompras
{
    // Atributos
    private List<Producto> productos;

    // Constructor
    public CarritoDeCompras()
    {
        productos = new List<Producto>();
    }

    // Método para agregar un producto al carrito
    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
        Console.WriteLine($"Producto '{producto.Nombre}' agregado al carrito.");
    }

    // Sobrecarga del método para agregar múltiples productos al carrito
    public void AgregarProductos(params Producto[] productosArray)
    {
        foreach (Producto producto in productosArray)
        {
            AgregarProducto(producto);
        }
    }

    // Método para mostrar los productos en el carrito
    public void MostrarCarrito()
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("El carrito está vacío.");
        }
        else
        {
            Console.WriteLine("Productos en el carrito:");
            foreach (Producto producto in productos)
            {
                Console.WriteLine($"- {producto.Nombre} (${producto.Precio})");
            }
            Console.WriteLine($"Total en el carrito: ${CalcularTotal()}");
        }
    }

    // Método para calcular el total de la compra
    public double CalcularTotal()
    {
        return productos.Sum(producto => producto.Precio);
    }

    // Sobrecarga del método para calcular el total con descuento
    public double CalcularTotal(double porcentajeDescuento)
    {
        double descuento = porcentajeDescuento / 100.0;
        return CalcularTotal() * (1 - descuento);
    }
}

// Clase Producto para modelar los productos en el carrito
public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public string Categoria { get; set; }

    // Constructor
    public Producto(string nombre, double precio, string categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
    }
}

public class BlackFridayPromocion
{
    public double Descuento { get; private set; }

    public BlackFridayPromocion()
    {
        Descuento = 20; 
    }

    public double AplicarDescuento(double total)
    {
        double descuento = total * (Descuento / 100.0);
        return total - descuento;
    }
}
class Program
{
    static void Main()
    {
        
        // PracticaStrings practica = new PracticaStrings("abcaabccc");

        // string subcadenaRepetida = practica.EncontrarSubcadenaRepetida();
        // Console.WriteLine($"Subcadena más larga de caracteres repetidos: {subcadenaRepetida}");

        // string subcadenaNoRepetida = practica.EncontrarSubcadenaNoRepetida();
        // Console.WriteLine($"Subcadena más larga de caracteres no repetidos: {subcadenaNoRepetida}");

        // PracticaStrings otraPractica = new PracticaStrings("xyz");

        // PracticaStrings resultado = practica + otraPractica;
        // Console.WriteLine($"Resultado de la concatenación: {resultado}");

        // Console.WriteLine(resultado);

        // // Crear una instancia de CarritoDeCompras
        // CarritoDeCompras carrito = new CarritoDeCompras();

        // // Agregar productos al carrito
        // Producto producto1 = new Producto("Laptop", 1200);
        // Producto producto2 = new Producto("Mouse", 20);
        // carrito.AgregarProductos(producto1, producto2);

        // // Mostrar el contenido del carrito
        // carrito.MostrarCarrito();

        // // Calcular y mostrar el total con descuento
        // double totalConDescuento = carrito.CalcularTotal(10);
        // Console.WriteLine($"Total con 10% de descuento: ${totalConDescuento}");

        // Crear una instancia de CarritoDeCompras
        CarritoDeCompras carrito = new CarritoDeCompras();

        // Agregar productos al carrito
        Producto producto1 = new Producto("Laptop", 1200, "Electrónicos");
        Producto producto2 = new Producto("Mouse", 20, "Electrónicos");
        Producto producto3 = new Producto("Libro", 15, "Libros");
        carrito.AgregarProductos(producto1, producto2, producto3);

        // Mostrar el contenido del carrito
        carrito.MostrarCarrito();

    }
}
