using SistemaMusica.Modelos;


namespace SistemaMusica.Tests
{
    public class UsuarioTests
    {
        // Prueba 1: CrearListaReproduccion(nombre)
        [Fact]
        public void CrearListaReproduccion_AgregaListaVaciaAlDiccionario()
        {
            // Arrange
            // La clase Usuario necesita un constructor que tome un nombre.
            var usuario = new Usuario("TestUser");
            string nombreLista = "Favoritas";

            // Act
            usuario.CrearListaReproduccion(nombreLista);

            // Assert
            // 1. El diccionario debe contener la clave "Favoritas".
            Assert.True(usuario.ListasReproduccion.ContainsKey(nombreLista));

            // 2. La lista debe estar vacía (Count == 0).
            Assert.Empty(usuario.ListasReproduccion[nombreLista]);
        }

        // Prueba 2: AgregarCancionALista(nombreLista, cancion)
        [Fact]
        public void AgregarCancionALista_CancionSeAñadeAListaEspecificada()
        {
            // Arrange
            var usuario = new Usuario("TestUser");
            string nombreLista = "Mis Hits";
            var cancion = new Cancion("Shape of You", "Ed Sheeran", 233);

            // Se debe crear la lista primero.
            usuario.CrearListaReproduccion(nombreLista);

            // Act
            usuario.AgregarCancionALista(nombreLista, cancion);

            // Assert
            // 1. Verificar que solo haya una canción en la lista "Mis Hits".
            Assert.Single(usuario.ListasReproduccion[nombreLista]);

            // 2. Verificar que la canción añadida sea la correcta.
            Assert.Equal(cancion, usuario.ListasReproduccion[nombreLista].First());
        }
    }
}