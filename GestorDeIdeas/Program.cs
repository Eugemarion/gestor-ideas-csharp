using GestorDeIdeas;

IdeaRepository repositorio = new IdeaRepository();

bool continuar = true;

while (continuar)
{
    Console.WriteLine(" Gestor de Ideas ");
    Console.WriteLine("1. Agregar nueva idea");
    Console.WriteLine("2. Listar ideas");
    Console.WriteLine("3. Salir");
    Console.WriteLine("4. Editar una idea");
    Console.WriteLine("5. Eliminar una idea");
    Console.WriteLine("6. Buscar");
    Console.WriteLine("7. Filtrar por categoría");
    Console.WriteLine("Elige una opcion");

string opcion = Console.ReadLine();

   switch (opcion)
    {
        case "1": 
            AgregarIdea(repositorio);
            break;

        case "2":
            ListarIdeas(repositorio);
            break;

        case "3":
            continuar = false;
            break;

        case "4":
            EditarIdea(repositorio);
            break;

        case "5":
            EliminarIdea(repositorio);
            break;

        case "6":
            BuscarIdeas(repositorio);
            break;

        case "7":
            FiltrarCategoria(repositorio);
            break;

        default:
            Console.WriteLine("Opcion inválida. Probá de nuevo.");
            break;
    }
    Console.WriteLine();
}

void FiltrarCategoria(IdeaRepository repositorio)
{
    throw new NotImplementedException();
}

void AgregarIdea(IdeaRepository repo)
{
    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Descripción: ");
    string descripcion = Console.ReadLine();

    Console.Write("Platafomra: ");
    string plataforma = Console.ReadLine();

    Console.Write("Tags: ");
    string tags = Console.ReadLine();

    Console.Write("Categoría: ");
    string categoria = Console.ReadLine();

    IdeaDeContenido nueva = new IdeaDeContenido()
    {
       
        Titulo = titulo,
        Descripcion = descripcion,
        Plataforma = plataforma,
        Tags = tags,
        FechaCreacion = DateTime.Now,
        Categoria = categoria
    };

    repo.AgregarIdea(nueva);

    Console.WriteLine("Idea agregada con éxito");
}

void ListarIdeas (IdeaRepository repo)
{
    var ideas = repo.ObtenerTodas();

    if (ideas.Count == 0 )
    {
        Console.WriteLine("No hay ideas cargadas.");
        return;
    }

    foreach (var idea in ideas)
    {
        ImprimirIdea(idea);
    }
}

void ImprimirIdea(IdeaDeContenido idea)
{
    throw new NotImplementedException();
}

void EditarIdea(IdeaRepository repo)
{
    Console.Write("Ingresa el ID de la idea a editar: ");
    string idTexto = Console.ReadLine();

    if (!int.TryParse(idTexto, out int id))
    {
        Console.WriteLine("ID inválido. Intentalo de nuevo.");
        return;
    }

     //Pedir nuevos datos
    Console.Write("Nuevo titulo (deja vacío para no cambiar): ");
    string nuevoTitulo = Console.ReadLine();

    Console.Write("Nueva descripcion (deja vacio para no cambiar): ");
    string nuevaDescripcion = Console.ReadLine();

    // Actualizamos solo cuando se escribe algo
    if (string.IsNullOrWhiteSpace(nuevoTitulo)) nuevoTitulo = null;

    if (string.IsNullOrWhiteSpace(nuevaDescripcion)) nuevaDescripcion = null;

    bool resultado = repo.EditarIdea(id, nuevoTitulo, nuevaDescripcion);

    Console.WriteLine(resultado? "Idea editada con éxito" : "No se encontró ese ID.");
}

void EliminarIdea (IdeaRepository repo)
{
    Console.Write("Ingresá el ID de la idea a eliminar: ");
    string idTexto = Console.ReadLine();

    if (!int.TryParse(idTexto, out int id))
    {
        Console.WriteLine("ID Invalido");
        return;
    }


    Console.Write($"Seguro que quieres eliminarla ? (s / n): ");
    string confirm = Console.ReadLine();

    if (confirm?.ToLower() != "s")
    {
        Console.WriteLine("Operacion cancelada");
        return;
    }

    bool resultado = repo.EliminarIdea(id);

    Console.WriteLine(resultado ? "Idea eliminada con éxito" : "No existe ninguna idea con ese ID");
 
}

void BuscarIdeas(IdeaRepository repo)
{
    Console.Write("Ingresá texto a buscar: ");
    string texto = Console.ReadLine();

    var resultados = repo.Buscar(texto);

    if (resultados.Count == 0)
    {
        Console.WriteLine("No hay coincidencias.");
        return;
    }

    Console.WriteLine($"Resultados: {resultados.Count}");
    foreach (var idea in resultados)
    {
        ImprimirIdea(idea);
    }

    void FiltrarCategoria(IdeaRepository repo)
    {
        var categorias = repo.ObtenerCategorias();

        if (categorias.Count == 0)
        {
            Console.WriteLine("No hay ideas cargadas.");
            return;
        }

        // 🔹 FOREACH #1 → mostrar categorías
        Console.WriteLine("Categorías disponibles:");
        foreach (var c in categorias)
        {
            Console.WriteLine($"- {c}");
        }

        Console.Write("\nIngresá la categoría exacta: ");
        string categoria = Console.ReadLine();

        var resultados = repo.FiltrarPorCategoria(categoria);

        if (resultados.Count == 0)
        {
            Console.WriteLine("No hay ideas para esa categoría.");
            return;
        }

        // 🔹 FOREACH #2 → mostrar ideas filtradas
        foreach (var idea in resultados)
        {
            ImprimirIdea(idea);
        }
    }

void ImprimirIdea(IdeaDeContenido idea)
{
    Console.WriteLine($"[{idea.Id}] {idea.Titulo}");
    Console.WriteLine($"Categoría: {idea.Categoria}");
    Console.WriteLine($"Plataforma: {idea.Plataforma}");
    Console.WriteLine($"Tags: {idea.Tags}");
    Console.WriteLine($"Creado: {idea.FechaCreacion:dd/MM/yyyy HH:mm}");
    Console.WriteLine($"Descripción: {idea.Descripcion}");
    Console.WriteLine(new string('-', 40));
}
