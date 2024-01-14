using System;

class Program
{
    static void Main(string[] args) {
       // Conversiones
        int intValue = 42;

        // Conversiones directas y mostrar resultados
        short shortValue = (short)intValue;
        Console.WriteLine($"int a short: {intValue} -> {shortValue}");

        long longValue = intValue;
        Console.WriteLine($"int a long: {intValue} -> {longValue}");

        float floatValue = intValue;
        Console.WriteLine($"float a int: {floatValue} -> {(int)floatValue}");

        double doubleValue = intValue;
        Console.WriteLine($"int a double: {intValue} -> {doubleValue}");

        bool boolValue = intValue != 0;
        Console.WriteLine($"bool a string: {boolValue} -> {boolValue.ToString()}");

        string stringValue = intValue.ToString();
        Console.WriteLine($"int a string: {intValue} -> {stringValue}");

        // Boxing y Unboxing
        object boxedObject = intValue; // Boxing: int a object
        Console.WriteLine($"Boxing (int a object): {boxedObject}");

        int unboxedValue = (int)boxedObject; // Unboxing: object a int
        Console.WriteLine($"Unboxing (object a int): {unboxedValue}");
    }

    static void PrintArguments(string[] args) {
         Console.WriteLine("¡Hola desde mi aplicación de consola!");

        if (args.Length > 0)
        {
            Console.WriteLine("Parámetros de línea de comandos:");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }
        else
        {
            Console.WriteLine("No se proporcionaron parámetros de línea de comandos.");
        }
    }
}
