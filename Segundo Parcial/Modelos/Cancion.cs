namespace SistemaMusica.Modelos
{
    
    
    public class Cancion
    {
      //Parametros
        public string Nombre { get; set; }

        public string Artista { get; set; }


        public int DuracionSegundos { get; set; }

        //Constructor
        public Cancion(string nombre, string artista, int duracionSegundos) //Constructor que inicializa las propiedades de la canción.
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la canción no puede estar vacío");
            }
            if (string.IsNullOrWhiteSpace(artista))
            {
                throw new ArgumentException("El nombre del artista no puede estar vacío");
            }
            if (duracionSegundos < 0)
            {
                throw new ArgumentException("La duración de la canción no puede ser negativa");
            }
        
            Nombre = nombre;
            Artista = artista;
            DuracionSegundos = duracionSegundos;
        }

        public override string ToString() //ToString() sirve para devolver una representación en texto de una instancia.
        {
            int mm = DuracionSegundos / 60; //Minutos
            int ss = DuracionSegundos % 60; //Segundos
            return $"{Nombre} - {Artista} ({mm}:{ss:D2})"; //:D2 asegura que los segundos siempre tengan dos dígitos.
        }
    }
}
