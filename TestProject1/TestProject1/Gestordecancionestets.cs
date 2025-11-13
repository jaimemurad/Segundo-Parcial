using SistemaMusica.Modelos;
using SistemaMusica.Servicios;


namespace SistemaMusica.Tests
{
    public class GestorCancionesTests
    {
        // Prueba 1: AgregarCancion(cancion)
        [Fact]
        public void AgregarCancion_AumentaElCatalogoDisponible()
        {
            // Arrange
            var gestor = new GestorCanciones();
            var cancion1 = new Cancion("Hotel California", "Eagles", 390);

            // Act
            gestor.AgregarCancion(cancion1);

            // Assert
            // 1. Verificar que la lista de CancionesDisponibles contenga la canción.
            Assert.Contains(cancion1, gestor.CancionesDisponibles);

            // 2. Verificar que el conteo haya aumentado (opcional, pero buena práctica).
            Assert.Single(gestor.CancionesDisponibles);
        }

        // Prueba 2: BuscarPorNombre(nombre)
        [Fact]
        public void BuscarPorNombre_RetornaCoincidenciasParcialesCaseInsensitive()
        {
            // Arrange
            var gestor = new GestorCanciones();
            gestor.AgregarCancion(new Cancion("Bohemian Rhapsody", "Queen", 354));
            gestor.AgregarCancion(new Cancion("Radio Ga Ga", "Queen", 348));
            gestor.AgregarCancion(new Cancion("Like a Rolling Stone", "Bob Dylan", 373));

            string terminoBusqueda = "like"; // Búsqueda en minúsculas

            // Act
            List<Cancion> resultados = gestor.BuscarPorNombre(terminoBusqueda);

            // Assert
            // 1. Debe encontrar solo 1 coincidencia.
            Assert.Single(resultados);

            // 2. La canción encontrada debe ser "Like a Rolling Stone" (verificación parcial).
            Assert.Equal("Like a Rolling Stone", resultados[0].Nombre);
        }

        // Prueba 3: QuickSort() (Ordenar por DuracionSegundos)
        [Fact]
        public void QuickSort_OrdenaCancionesPorDuracionAscendente()
        {
            // Arrange
            var gestor = new GestorCanciones();
            // Duración: 200 (Corta)
            gestor.AgregarCancion(new Cancion("Corta", "Artista1", 200));
            // Duración: 400 (Larga)
            gestor.AgregarCancion(new Cancion("Larga", "Artista3", 400));
            // Duración: 300 (Media)
            gestor.AgregarCancion(new Cancion("Media", "Artista2", 300));

            // Act
            // Se llama al QuickSort con los 3 argumentos requeridos:
            gestor.QuickSort(gestor.CancionesDisponibles, 0, gestor.CancionesDisponibles.Count - 1);

            // Assert
            // Verifica el orden ascendente (200, 300, 400).
            Assert.Equal("Corta", gestor.CancionesDisponibles[0].Nombre); // Menor duración
            Assert.Equal("Media", gestor.CancionesDisponibles[1].Nombre); // Duración media
            Assert.Equal("Larga", gestor.CancionesDisponibles[2].Nombre); // Mayor duración
        }
    }
}
