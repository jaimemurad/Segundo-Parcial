using SistemaMusica.Modelos;

namespace SistemaMusica.Servicios
{
    public class ServicioMusica
    {
        // Propiedades
        public List<Usuario> Usuarios { get; set; } // Lista que almacena todos los usuarios registrados en el sistema.
        public GestorCanciones Gestor { get; set; } // Referencia al gestor de canciones que maneja las canciones disponibles.

        // Constructor
        public ServicioMusica(GestorCanciones gestor)
        {
            Usuarios = new List<Usuario>();
            Gestor = gestor;
        }

        // Método: RegistrarUsuario(string nombre)
        public Usuario RegistrarUsuario(string nombre) //Crea usuario, lo añade a la lista y muestra mensaje
        {
            Usuario usuario = new Usuario(nombre); // Crea un nuevo objeto Usuario con el nombre proporcionado
            Usuarios.Add(usuario);
            Console.WriteLine($"Usuario '{usuario.Nombre}' registrado.");
            return usuario;
        }

        // Método: BuscarUsuario(string nombre)
        public Usuario BuscarUsuario(string nombre) //Busca usuario ignorando mayúsculas/minúsculas
        {
            // Busca el primer Usuario cuyo Nombre coincide con el parámetro 'nombre' (ignorando mayúsculas/minúsculas)
            Usuario usuarioEncontrado = Usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)); // Si no lo encuentra, devuelve null
            return usuarioEncontrado; // Retorna el objeto Usuario (o null si no lo encuentra)
        }
    }
}