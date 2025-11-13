
using SistemaMusica.Modelos;
using SistemaMusica.Servicios; // Necesario para la clase a probar

namespace SistemaMusica.Tests
{
    // NOTA: Para instanciar ServicioMusica, se necesita un GestorCanciones (ver constructor anterior).
    public class ServicioMusicaTests
    {
        // Prueba 1: RegistrarUsuario(nombre)
        [Fact]
        public void RegistrarUsuario_UsuarioSeAñadeAListaUsuarios()
        {
            // Arrange
            var gestorFalso = new GestorCanciones(); // Dependencia dummy
            var servicio = new ServicioMusica(gestorFalso);
            string nombreUsuario = "TestUser";

            // Act
            servicio.RegistrarUsuario(nombreUsuario);

            // Assert
            // 1. Verificar que solo haya un usuario registrado.
            Assert.Single(servicio.Usuarios);

            // 2. Verificar que el nombre del primer usuario sea el esperado.
            Assert.Equal(nombreUsuario, servicio.Usuarios[0].Nombre);
        }

        // Prueba 2: BuscarUsuario(nombre) - Caso encontrado (case-insensitive)
        [Fact]
        public void BuscarUsuario_RetornaUsuarioExistenteIgnorandoMayusculas()
        {
            // Arrange
            var gestorFalso = new GestorCanciones();
            var servicio = new ServicioMusica(gestorFalso);
            // Se registra el usuario en minúsculas
            servicio.RegistrarUsuario("testuser");

            string busqueda = "TestUser"; // Se busca con mayúsculas

            // Act
            Usuario resultado = servicio.BuscarUsuario(busqueda);

            // Assert
            // 1. Verificar que el resultado no sea nulo.
            Assert.NotNull(resultado);

            // 2. Verificar que el nombre coincida (el método de búsqueda hizo el trabajo).
            Assert.Equal("testuser", resultado.Nombre);
        }

        // Prueba 3: BuscarUsuario(nombre) - Caso no encontrado
        [Fact]
        public void BuscarUsuario_RetornaNullSiUsuarioNoExiste()
        {
            // Arrange
            var gestorFalso = new GestorCanciones();
            var servicio = new ServicioMusica(gestorFalso);
            // Se registra un usuario, pero buscaremos otro.
            servicio.RegistrarUsuario("RealUser");

            string busqueda = "NoExistente";

            // Act
            Usuario resultado = servicio.BuscarUsuario(busqueda);

            // Assert
            // Debe retornar null.
            Assert.Null(resultado);
        }
    }
}
