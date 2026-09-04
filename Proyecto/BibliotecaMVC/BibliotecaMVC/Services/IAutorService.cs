using BibliotecaMVC.Models;

namespace BibliotecaMVC.Services
{
    public interface IAutorService
    {
        IEnumerable<Autor> ObtenerTodos();
        Autor? ObtenerPorId(int id);
        void Agregar(Autor autor);
        bool Actualizar(int id, Autor autor);
        bool Eliminar(int id);
    }
}
