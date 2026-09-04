using BibliotecaMVC.Models;

namespace BibliotecaMVC.Repositories
{
    public class RepositorioLibroEnMemoria : IRepositorioLibro
    {
        private List<Libro> _libros;

        public RepositorioLibroEnMemoria()
        {
            _libros = new List<Libro>
            {
                new Libro { ID = 1, Titulo = "El Señor de los Anillos" },
                new Libro { ID = 2, Titulo = "Cien años de soledad" }
            };
        }

        public IEnumerable<Libro> ObtenerTodos()
        {
            return _libros;
        }
    }
}