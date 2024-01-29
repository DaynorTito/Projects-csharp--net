using System;
using System.Collections.Generic;

// Declaración de un delegado que representa la firma de métodos para manejar notificaciones.
public delegate void NotificationHandler(object sender, NotificationEventArgs e);

// Clase que define el objeto de notificación y dispara eventos cuando ocurren eventos específicos.
public class Notifier
{
    // Declaración de eventos utilizando el delegado de notificación.
    public event NotificationHandler NotifyUserLoggedIn;
    public event NotificationHandler NotifyDataUpdated;

    // Método que simula la acción de inicio de sesión.
    public void SimulateUserLogin(string username)
    {
        Console.WriteLine($"Usuario {username} ha iniciado sesión.");

        // Verificar si hay suscriptores al evento y, en caso afirmativo, notificar.
        NotifyUserLoggedIn?.Invoke(this, new NotificationEventArgs("Inicio de sesión exitoso"));
    }

    // Método que simula la actualización de datos.
    public void SimulateDataUpdate()
    {
        Console.WriteLine("Actualización de datos realizada.");

        // Verificar si hay suscriptores al evento y, en caso afirmativo, notificar.
        NotifyDataUpdated?.Invoke(this, new NotificationEventArgs("Datos actualizados"));
    }
}

// Clase que define argumentos personalizados para las notificaciones.
public class NotificationEventArgs : EventArgs
{
    public string Message { get; }

    public NotificationEventArgs(string message)
    {
        Message = message;
    }
}

// Clase que representa un suscriptor que reacciona a las notificaciones.
public class NotificationSubscriber
{
    public string Name { get; }

    // Constructor que recibe el nombre del suscriptor.
    public NotificationSubscriber(string name)
    {
        Name = name;
    }

    // Método que maneja las notificaciones de inicio de sesión.
    public void HandleUserLoggedIn(object sender, NotificationEventArgs e)
    {
        Console.WriteLine($"[{Name}] Recibida notificación: {e.Message}");
    }

    // Método que maneja las notificaciones de actualización de datos.
    public void HandleDataUpdated(object sender, NotificationEventArgs e)
    {
        Console.WriteLine($"[{Name}] Recibida notificación: {e.Message}");
    }
}

// Clase principal que contiene el punto de entrada del programa.
class Program
{
    static void Main()
    {
        // Crear instancia del objeto de notificación.
        Notifier notifier = new Notifier();

        // Crear instancias de varios suscriptores.
        NotificationSubscriber subscriber1 = new NotificationSubscriber("Suscriptor1");
        NotificationSubscriber subscriber2 = new NotificationSubscriber("Suscriptor2");

        // Suscribir los métodos de los suscriptores a los eventos del objeto de notificación.
        notifier.NotifyUserLoggedIn += subscriber1.HandleUserLoggedIn;
        notifier.NotifyUserLoggedIn += subscriber2.HandleUserLoggedIn;
        notifier.NotifyDataUpdated += subscriber1.HandleDataUpdated;
        notifier.NotifyDataUpdated += subscriber2.HandleDataUpdated;

        // Simular eventos de inicio de sesión y actualización de datos.
        notifier.SimulateUserLogin("Usuario123");
        Console.WriteLine(); // Separador para mayor claridad
        notifier.SimulateDataUpdate();

        Console.ReadLine();
    }
}
