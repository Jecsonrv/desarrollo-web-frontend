using BibliotecaMVC.Models;
namespace BibliotecaMVC.Repositories
{
    public class RespositorioEnMemoria : IRepositorioLibro
    {
        public IEnumerable<Libro> ObtenerTodos()
        {
            return new List<Libro>()
            {
                 new Libro
            {
                ID = 1,
                Titulo = "Clean Code",
                Autor = "Robert C. Martin",
                Categoria = "Programación",
                Precio = 29.99m,
                Disponible = true
            },
            new Libro{
                ID = 2,
                Titulo = "The Pragmatic Programmer",
                Autor = "Andrew Hunt, David Thomas",
                Categoria = "Programación",
                Precio = 34.99m,
                Disponible = false
            }
            };
        }
    }
}
