using System;


public class Ball
{
    // Encapsulamiento
    private string color;
    private double radius;
    
    // Propiedades públicas para acceder a los datos encapsulados
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

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

    public void Bounce()
    {
        Console.WriteLine("La pelota está rebotando.");
    }
}

// Herencia
public class SoccerBall : Ball
{ 
    // Polimorfismo
    public new void Bounce()
    {
        Console.WriteLine("La pelota de fútbol está rebotando de manera diferente.");
    }
}

class Program
{
    static void Main()
    {
        
        Ball myBall = new Ball();

        myBall.Color = "Rojo";
        myBall.Radius = 10;

        myBall.Radius = -5;

        myBall.Bounce();

        // Crear una instancia de la clase SoccerBall (heredada de Ball)
        SoccerBall soccerBall = new SoccerBall();

        // Polimorfismo: Llamada al método Bounce de la clase derivada
        soccerBall.Bounce();
    }
}
