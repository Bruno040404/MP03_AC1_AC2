using System;
using System.Collections.Generic;
using System.Collections;

class Program
{
    static void Main()
    {
        Random random = new Random();

        string[] robots = new string[20];

        for (int i = 0; i < robots.Length; i++)
        {
            char letra1 = (char)random.Next('A', 'Z' + 1);
            char letra2 = (char)random.Next('A', 'Z' + 1);

            int numero1 = random.Next(0, 10);
            int numero2 = random.Next(0, 10);
            int numero3 = random.Next(0, 10);
            string nombreRobot = $"{letra1}{letra2}{numero1}{numero2}{numero3}";
            robots[i] = nombreRobot;
        }

        List<string> almacen1 = new List<string>(); 
        Stack<string> almacen2 = new Stack<string>(); 
        Queue<string> almacen3 = new Queue<string>(); 

    
        foreach (string robot in robots)
        {
            if (robot.StartsWith("RD2D"))
            {
                almacen1.Add(robot);
            }
            else if (robot.StartsWith("C3PO"))
            {
                almacen2.Push(robot);
            }
            else if (robot.StartsWith("BBB"))
            {
                almacen3.Enqueue(robot);
            }
        }

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Mostrar todos los almacenes");
            Console.WriteLine("2. Mostrar el último robot de cada almacén");
            Console.WriteLine("3. Mostrar robot de una posición específica de cada almacén");
            Console.WriteLine("4. Borrar todos los robots de un almacén específico");
            Console.WriteLine("5. Borrar todos los robots de todos los almacenes");
            Console.WriteLine("6. Contar los robots de cada almacén");
            Console.WriteLine("7. Salir");
            Console.Write("Ingrese su opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarAlmacenes(almacen1, almacen2, almacen3);
                    break;
                case "2":
                    MostrarUltimosRobots(almacen1, almacen2, almacen3);
                    break;
                case "3":
                    MostrarRobotPosicion(almacen1, almacen2, almacen3);
                    break;
                case "4":
                    BorrarAlmacenEspecifico(almacen1, almacen2, almacen3);
                    break;
                case "5":
                    BorrarTodosAlmacenes(almacen1, almacen2, almacen3);
                    break;
                case "6":
                    ContarRobots(almacen1, almacen2, almacen3);
                    break;
                case "7":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void MostrarAlmacenes(List<string> almacen1, Stack<string> almacen2, Queue<string> almacen3)
    {
        Console.WriteLine("\nRobots almacenados en RD2D (Lista):");
        foreach (string elemento in almacen1)
        {
            Console.Write(elemento + " ");
        }

        Console.WriteLine("\nRobots almacenados en C3PO (Pila):");
        foreach (string elemento in almacen2)
        {
            Console.Write(elemento + " ");
        }

        Console.WriteLine("\nRobots almacenados en BBB (Cola):");
        foreach (string elemento in almacen3)
        {
            Console.Write(elemento + " ");
        }
    }

    static void MostrarUltimosRobots(List<string> almacen1, Stack<string> almacen2, Queue<string> almacen3)
    {
        Console.WriteLine("\nÚltimo robot en RD2D: " + (almacen1.Count > 0 ? almacen1[almacen1.Count - 1] : "No hay robots"));
        Console.WriteLine("Último robot en C3PO: " + (almacen2.Count > 0 ? almacen2.Peek() : "No hay robots"));
        Console.WriteLine("Último robot en BBB: " + (almacen3.Count > 0 ? almacen3.Peek() : "No hay robots"));
    }

    static void MostrarRobotPosicion(List<string> almacen1, Stack<string> almacen2, Queue<string> almacen3)
    {
        Console.Write("Ingrese la posición del robot en RD2D: ");
        int posicion1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Robot en la posición " + posicion1 + " en RD2D: " + (posicion1 >= 0 && posicion1 < almacen1.Count ? almacen1[posicion1] : "No hay robot en esa posición"));

        Console.Write("Ingrese la posición del robot en C3PO: ");
        int posicion2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Robot en la posición " + posicion2 + " en C3PO: " + (posicion2 >= 0 && posicion2 < almacen2.Count ? almacen2.ToArray()[posicion2] : "No hay robot en esa posición"));

        Console.Write("Ingrese la posición del robot en BBB: ");
        int posicion3 = int.Parse(Console.ReadLine());
        Console.WriteLine("Robot en la posición " + posicion3 + " en BBB: " + (posicion3 >= 0 && posicion3 < almacen3.Count ? almacen3.ToArray()[posicion3] : "No hay robot en esa posición"));
    }

    static void BorrarAlmacenEspecifico(List<string> almacen1, Stack<string> almacen2, Queue<string> almacen3)
    {
        Console.Write("Ingrese el número del almacén a borrar (1 - RD2D, 2 - C3PO, 3 - BBB): ");
        int numeroAlmacen = int.Parse(Console.ReadLine());

        switch (numeroAlmacen)
        {
            case 1:
                almacen1.Clear();
                Console.WriteLine("Se han borrado todos los robots de RD2D.");
                break;
            case 2:
                almacen2.Clear();
                Console.WriteLine("Se han borrado todos los robots de C3PO.");
                break;
            case 3:
                almacen3.Clear();
                Console.WriteLine("Se han borrado todos los robots de BBB.");
                break;
            default:
                Console.WriteLine("Almacén no válido.");
                break;
        }
    }

    static void BorrarTodosAlmacenes(List<string> almacen1, Stack<string> almacen2, Queue<string> almacen3)
    {
        almacen1.Clear();
        almacen2.Clear();
        almacen3.Clear();
        Console.WriteLine("Se han borrado todos los robots de todos los almacenes.");
    }

    static void ContarRobots(List<string> almacen1, Stack<string> almacen2, Queue<string> almacen3)
    {
        Console.WriteLine("Cantidad de robots en RD2D: " + almacen1.Count);
        Console.WriteLine("Cantidad de robots en C3PO: " + almacen2.Count);
        Console.WriteLine("Cantidad de robots en BBB: " + almacen3.Count);
    }
}
