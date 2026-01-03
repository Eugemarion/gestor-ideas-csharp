namespace GestorDeIdeas
{
    public class IdeaDeContenido
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
        public string Plataforma { get; set; }
        public string Tags { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Categoria { get; set; } = "General";

    }
}
