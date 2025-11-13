using SistemaMusica.Modelos;

namespace SistemaMusica.Modelos
{
    public class Usuario
    {
        //Propiedades
        public string Nombre { get; set; }
        public Dictionary<string, List<Cancion>> ListasReproduccion { get; set; } //Crea la propiedad ListasReproduccion como un diccionario donde la clave es el nombre de la lista y el valor es una lista de canciones.

        //Constructor
        public Usuario(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío");
            }
            Nombre = nombre;
            //La lista de reproducción se inicializa como un diccionario vacío.
            ListasReproduccion = new Dictionary<string, List<Cancion>>(StringComparer.OrdinalIgnoreCase); //StringComparer.OrdinalIgnoreCase para que las claves no sean sensibles a mayúsculas/minúsculas.
        }

        //Métodos

        public bool CrearListaReproduccion(string nombreLista) //• Verifica si no existe la lista antes de crearla • Muestra mensaje de éxito/error //Listas duplicadas: Evitar nombres repetidos en las listas de reproducción.
        {
            if (ListasReproduccion.ContainsKey(nombreLista))//Verifica si ya existe una lista con ese nombre
            {
                Console.WriteLine("Ya existe una lista con ese nombre.");
                return false;
            }
            else
            {
                ListasReproduccion[nombreLista] = new List<Cancion>(); //Crea una nueva lista vacía para ese nombre de lista
                return true;
            }

        }

        public bool AgregarCancionALista(string nombreLista, Cancion cancion) //Añade canción solo si la lista existe // Validar si la Lista no existe
        {
            if (!ListasReproduccion.ContainsKey(nombreLista))
            {
                Console.WriteLine("La lista no existe.");
                return false;
            }

            ListasReproduccion[nombreLista].Add(cancion); //Agrega la canción a la lista correspondiente
            Console.WriteLine("Canción agregada correctamente.");
            return true;
        }

        public void MostrarListasReproduccion() //Imprime cada lista con sus canciones(usar ToString() de Cancion)
        {
            if (!ListasReproduccion.Any()) //Verifica si hay listas creadas
            {
                Console.WriteLine("No tienes listas creadas.");
                return;
            }

            //Imprimir cada lista con sus canciones usando el metodo ToString() de la clase Cancion
            foreach (var lista in ListasReproduccion) //Itera sobre cada par clave-valor en el diccionario
            {
                Console.WriteLine($"Lista: {lista.Key} ({lista.Value.Count} canciones)"); //Imprime el nombre de la lista y la cantidad de canciones que tiene
                //lista.key es el nombre de la lista
                //lista.value es la lista de canciones
                //lista.value.count es la cantidad de canciones en la lista
                if (!lista.Value.Any()) //Verifica si la lista está vacía
                {
                    Console.WriteLine("  (Lista vacía)");
                }
                else
                {
                    foreach (var cancion in lista.Value) //Imprime cada canción en la lista
                    {
                        Console.WriteLine($"  - {cancion}");
                    }
                }
                Console.WriteLine(); //Línea en blanco para separar listas
            }
        }
    }
}


