using SistemaMusica.Modelos;
using SistemaMusica.Servicios;

var gestor = new GestorCanciones();
var servicio = new ServicioMusica(gestor);

// Canciones base
gestor.AgregarCancion(new Cancion("Numb", "Linkin Park", 185));
gestor.AgregarCancion(new Cancion("Hysteria", "Muse", 210));
gestor.AgregarCancion(new Cancion("One", "Metallica", 290));
gestor.AgregarCancion(new Cancion("Hey Jude", "The Beatles", 431));
gestor.AgregarCancion(new Cancion("Lose Yourself", "Eminem", 326));
gestor.AgregarCancion(new Cancion("Billie Jean", "Michael Jackson", 290));
gestor.AgregarCancion(new Cancion("Clocks", "Coldplay", 307));
gestor.AgregarCancion(new Cancion("Starboy", "The Weeknd", 230));

Console.WriteLine("Bienvenido al Sistema de Música Simple\n");

Console.WriteLine("--- REGISTRO DE USUARIO ---");
Console.Write("Por favor, ingrese su nombre de usuario: ");
var nombre = Console.ReadLine() ?? string.Empty;
var usuario = servicio.RegistrarUsuario(nombre);

Console.WriteLine();
// Mostrar la oración explícita requerida sin borrar lo anterior
Console.WriteLine($"¡Bienvenido, {usuario.Nombre}!\n");

Console.WriteLine("--- CREACIÓN DE LISTA DE REPRODUCCIÓN ---");
Console.Write("Ingrese un nombre para su primera lista de reproducción: ");
var primeraLista = Console.ReadLine() ?? "Lista";
usuario.CrearListaReproduccion(primeraLista);
Console.WriteLine($"Lista '{primeraLista}' creada.\n");

string listaActual = primeraLista;

while (true)
{
    Console.WriteLine("--- MENÚ PRINCIPAL ---");
    Console.WriteLine($"Usuario actual: {usuario.Nombre}");
    if (usuario.ListasReproduccion.ContainsKey(listaActual))
    {
        var cuenta = usuario.ListasReproduccion[listaActual].Count;
        Console.WriteLine($"Lista actual: '{listaActual}' ({cuenta} canciones)");
    }
    else
    {
        Console.WriteLine($"Lista actual: '{listaActual}' (no encontrada)");
    }

    Console.WriteLine();
    Console.WriteLine("1. Buscar canciones para agregar a mi lista");
    Console.WriteLine("2. Ver mi lista de reproducción (ordenada por duración)");
    Console.WriteLine("3. Ver todas las canciones disponibles");
    Console.WriteLine("4. Crear nueva lista de reproducción");
    Console.WriteLine("5. Cambiar de lista actual");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    var entrada = Console.ReadLine() ?? string.Empty;
    if (!int.TryParse(entrada, out int op)) op = -1;

    switch (op)
    {
        case 1:
            Console.Write("\nBuscar: ");
            var q = Console.ReadLine() ?? string.Empty;
            var res = gestor.BuscarPorNombre(q);
            if (!res.Any())
            {
                Console.WriteLine("No se encontró ninguna canción.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                break;
            }

            for (int i = 0; i < res.Count; i++)
                Console.WriteLine($"{i + 1}. {res[i]}");

            Console.Write("\ncuál deseas agregar? (número, 0 para cancelar): ");
            int.TryParse(Console.ReadLine(), out int n);
            if (n > 0 && n <= res.Count)
            {
                if (usuario.AgregarCancionALista(listaActual, res[n - 1])) ;

                else
                    Console.WriteLine($"No se pudo agregar");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 2:
            if (!usuario.ListasReproduccion.ContainsKey(listaActual))
            {
                Console.WriteLine("\nLa lista actual no existe. Cree o seleccione otra lista.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                break;
            }
            var l = usuario.ListasReproduccion[listaActual];
            if (l.Count == 0)
            {
                Console.WriteLine("\nLa lista está vacía.");
            }
            else
            {
                gestor.QuickSort(l, 0, l.Count - 1);
                Console.WriteLine("\nLista ordenada por duración:");
                for (int i = 0; i < l.Count; i++)
                    Console.WriteLine($"{i + 1}. {l[i]}");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 3:
            Console.WriteLine();
            gestor.MostrarCancionesDisponibles();
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 4:
            Console.Write("\nNombre lista: ");
            var nombreLista = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombreLista))
            {
                Console.WriteLine("Nombre inválido.");
            }
            else
            {
                usuario.CrearListaReproduccion(nombreLista);
                Console.WriteLine($"Lista '{nombreLista}' creada.");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 5:
            Console.Write("\nLista a usar: ");
            var nueva = Console.ReadLine() ?? string.Empty;
            if (usuario.ListasReproduccion.ContainsKey(nueva))
            {
                listaActual = nueva;
                Console.WriteLine($"Lista actual cambiada a '{listaActual}'.");
            }
            else
            {
                Console.WriteLine("La lista indicada no existe.");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 6:
            return;

        default:
            Console.WriteLine("\nOpción no válida. Presione Enter para continuar...");
            Console.ReadLine();
            break;
    }
}