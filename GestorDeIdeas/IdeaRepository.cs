using System.IO;
using System.Text.Json;
using System.Linq;


namespace GestorDeIdeas
{
    public class IdeaRepository
    {
        private readonly string _rutaArchivo = "ideas.json";
        private int _ultimoId = 0;
        private List<IdeaDeContenido> _ideas = new List<IdeaDeContenido>();
       
        public IdeaRepository ()
        {
            CargaDesdeArchivo();
        }
        public void AgregarIdea (IdeaDeContenido idea)
        {
            _ultimoId++;
            idea.Id = _ultimoId;
            _ideas.Add (idea);
            GuardarEnArchivo();
        }

        public bool EditarIdea (int id, string nuevoTitulo, string nuevaDescripcion)
        {
            var idea = _ideas.FirstOrDefault (i => i.Id == id);

            if (idea == null)   
                return false;

            idea.Titulo = nuevoTitulo;
            idea.Descripcion = nuevaDescripcion;

            GuardarEnArchivo ();
            return true;
        }

        public bool EliminarIdea (int id)
        {
            var idea = _ideas.FirstOrDefault (i => i.Id == id);
            if (idea == null) return false;

            _ideas.Remove (idea);
            GuardarEnArchivo();
            return true;
        }

        public List<IdeaDeContenido> ObtenerTodas()
        {
            return _ideas;  
        }

        public List<IdeaDeContenido> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return new List<IdeaDeContenido>();

            texto = texto.Trim();

            return _ideas
                .Where(i =>
                    (i.Titulo ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (i.Descripcion ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (i.Tags ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (i.Plataforma ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (i.Categoria ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
        }

        public List<IdeaDeContenido> FiltrarPorCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                return new List<IdeaDeContenido>();

            categoria = categoria.Trim();

            return _ideas
                .Where(i => (i.Categoria ?? "").Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();

        
        }

        private void GuardarEnArchivo ()
        {
            var json = JsonSerializer.Serialize(_ideas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_rutaArchivo, json);
        }

        private void CargaDesdeArchivo ()
        {
            if (File.Exists(_rutaArchivo))
            {
                var json = File.ReadAllText (_rutaArchivo);
                _ideas = JsonSerializer.Deserialize<List<IdeaDeContenido>>(json) ?? new List<IdeaDeContenido>();
                if (_ideas.Count > 0)
                {
                   _ultimoId = _ideas.Max (i=> i.Id);
                }
            }
        }

        public List<string> ObtenerCategorias()
        {
            return _ideas
                .Select(i => i.Categoria ?? "General")
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(c => c)
                .ToList();
        }
    }
}
