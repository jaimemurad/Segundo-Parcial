using SistemaMusica.Modelos;

namespace SistemaMusica.Servicios
{
    public class GestorCanciones
    {
        public List<Cancion> CancionesDisponibles { get; set; } //Lista que almacena todas las canciones disponibles en el sistema.

        public GestorCanciones() //Constructor que inicializa la lista de canciones disponibles.
        {
            CancionesDisponibles = new List<Cancion>();
        }

        //Métodos
        public void AgregarCancion(Cancion cancion)   // Agrega una nueva canción a la lista de canciones disponibles
        {
            CancionesDisponibles.Add(cancion);
        }

        public List<Cancion> BuscarPorNombre(string nombre) //• Usa StringComparison.OrdinalIgnoreCase para búsqueda sin distincion entre mayúsculas y minúscula y retorna la lista de coincidencias parciales
        {
            return CancionesDisponibles
                .Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)) //encuentra coincidencias parciales en el nombre de la canción
                .ToList(); //retorna la lista de canciones que coinciden

        }

        public void QuickSort(List<Cancion> lista, int low, int high) //Implementa el algoritmo QuickSort para ordenar canciones por duración en segundos
        {
            // - Elegir el último elemento como pivote
            // - Crear listas 'menores' y 'mayores' según DuracionSegundos
            // - Ordenar recursivamente

            if (lista == null || lista.Count <= 1) // Lista vacía o con un solo elemento ya está ordenada
            {
                return;
            }

            // Seleccionar pivote (último elemento)
            Cancion pivote = lista[lista.Count - 1]; //Almacenamos el último elemento como pivote

            //Se reorganiza la lista con elementos menores a la izquierda y mayores a la derecha
            var menores = new List<Cancion>(); 
            var mayores = new List<Cancion>();

            
            for (int i = 0; i < lista.Count - 1; i++)
            {
                if (lista[i].DuracionSegundos <= pivote.DuracionSegundos)
                {
                    menores.Add(lista[i]);
                }
                else
                {
                    mayores.Add(lista[i]);
                }
            }

            // Aplicar QuickSort recursivamente a las sublistas formadas
            QuickSort(menores, 0, menores.Count - 1);
            QuickSort(mayores, 0, mayores.Count - 1);

            // Combinar resultados en la lista original
            lista.Clear();
            lista.AddRange(menores);
            lista.Add(pivote);
            lista.AddRange(mayores);
        }

        public void MostrarCancionesDisponibles() //Muestra todas las canciones disponibles en la consola
        {
            if (!CancionesDisponibles.Any()) 
            {
                Console.WriteLine("No hay canciones disponibles.");
                return;
            }

            int index = 1; //Contador para numerar las canciones
            foreach (var canción in CancionesDisponibles) //Itera sobre cada canción en la lista
            {
                Console.WriteLine($"{index++}. {canción}"); //Muestra el índice y la representación en cadena de la canción
            }
        }
    }
}

