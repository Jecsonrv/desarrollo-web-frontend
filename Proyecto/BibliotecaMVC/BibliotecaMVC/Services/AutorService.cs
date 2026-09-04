using BibliotecaMVC.Models;

namespace BibliotecaMVC.Services
{
    public class AutorService : IAutorService
    {
        private static readonly List<Autor> _autores = new()
        {
            new Autor
            {
                ID = 1,
                Nombre = "Robert",
                Apellido = "Martin",
                Nacionalidad = "Estadounidense",
                FechaNacimiento = new DateTime(1952, 12, 5),
                Activo = true
            },
            new Autor
            {
                ID = 2,
                Nombre = "Martin",
                Apellido = "Fowler",
                Nacionalidad = "Británico",
                FechaNacimiento = new DateTime(1963, 12, 18),
                Activo = true
            },
            new Autor
            {
                ID = 3,
                Nombre = "Andrew",
                Apellido = "Hunt",
                Nacionalidad = "Estadounidense",
                FechaNacimiento = new DateTime(1964, 1, 1),
                Activo = true
            },
            new Autor
            {
                ID = 4,
                Nombre = "David",
                Apellido = "Thomas",
                Nacionalidad = "Británico",
                FechaNacimiento = new DateTime(1956, 1, 1),
                Activo = true
            },
            new Autor
            {
                ID = 5,
                Nombre = "R. J.",
                Apellido = "Palacio",
                Nacionalidad = "Estadounidense",
                FechaNacimiento = new DateTime(1963, 7, 13),
                Activo = false
            }
        };

        public IEnumerable<Autor> ObtenerTodos()
        {
            return _autores;
        }

        public Autor? ObtenerPorId(int id)
        {
            return _autores.FirstOrDefault(x => x.ID == id);
        }

        public void Agregar(Autor autor)
        {
            autor.ID = _autores.Any() ? _autores.Max(x => x.ID) + 1 : 1;
            _autores.Add(autor);
        }

        public bool Actualizar(int id, Autor autor)
        {
            var autorExistente = ObtenerPorId(id);
            if (autorExistente == null)
            {
                return false;
            }

            autorExistente.Nombre = autor.Nombre;
            autorExistente.Apellido = autor.Apellido;
            autorExistente.Nacionalidad = autor.Nacionalidad;
            autorExistente.FechaNacimiento = autor.FechaNacimiento;

            return true;
        }

        public bool Eliminar(int id)
        {
            var autor = ObtenerPorId(id);
            return autor != null && _autores.Remove(autor);
        }
    }
}
