using SistemaMusica.Modelos;

namespace SistemaMusica.Tests
{
    public class CancionTests
    {
        // 1. Prueba de asignación de valores del constructor
        [Fact]
        public void Constructor_AsignaValoresCorrectamente()
        {
            // Arrange
            string nombre = "Imagine";
            string artista = "John Lennon";
            int duracion = 183;

            // Act
            var cancion = new Cancion(nombre, artista, duracion);

            // Assert
            Assert.Equal(nombre, cancion.Nombre);
            Assert.Equal(artista, cancion.Artista);
            Assert.Equal(duracion, cancion.DuracionSegundos);
        }

        // 2. Pruebas de excepciones del constructor (Nombre vacío)
        [Fact]
        public void Constructor_LanzaExcepcion_SiNombreEsVacio()
        {
            // Arrange: No se requiere configuración previa.

            // Act & Assert
            // Verifica que se lance ArgumentException al intentar crear Cancion con nombre vacío.
            Assert.Throws<ArgumentException>(() => new Cancion("", "Artista", 200));
        }

        // 3. Pruebas de excepciones del constructor (Artista vacío)
        [Fact]
        public void Constructor_LanzaExcepcion_SiArtistaEsVacio()
        {
            // Arrange: No se requiere configuración previa.

            // Act & Assert
            // Verifica que se lance ArgumentException al intentar crear Cancion con artista vacío.
            Assert.Throws<ArgumentException>(() => new Cancion("Nombre", "", 200));
        }

        // 4. Pruebas de excepciones del constructor (Duración negativa)
        [Fact]
        public void Constructor_LanzaExcepcion_SiDuracionNegativa()
        {
            // Arrange: No se requiere configuración previa.

            // Act & Assert
            // Verifica que se lance ArgumentException al intentar crear Cancion con duración negativa.
            Assert.Throws<ArgumentException>(() => new Cancion("Nombre", "Artista", -1));
        }

        // 5. Prueba del método ToString()
        [Fact]
        public void ToString_DevuelveFormatoEsperado()
        {
            // Arrange (183 segundos = 3 minutos y 3 segundos)
            var cancion = new Cancion("Imagine", "John Lennon", 183);

            // Act
            string resultado = cancion.ToString();

            // Assert: Verifica el formato "Nombre - Artista (MM:SS)"
            // Asumiendo que se usa el formato 03:03. Si no, ajustar a "3:03".
            Assert.Equal("Imagine - John Lennon (3:03)", resultado);
        }

        // 6. Prueba del método ToString() (Ajuste de dos dígitos para segundos)
        [Fact]
        public void ToString_AjustaSegundosConDosDigitos()
        {
            // Arrange (190 segundos = 3 minutos y 10 segundos)
            var cancion = new Cancion("SongTest", "Artist", 190);

            // Act
            string resultado = cancion.ToString();

            // Assert
            // Verifica que los segundos se muestren con dos dígitos (10).
            Assert.Equal("SongTest - Artist (3:10)", resultado);
        }
    }
}