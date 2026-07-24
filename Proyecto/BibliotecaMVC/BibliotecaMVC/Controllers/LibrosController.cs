using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            List<Libro> libros = new List<Libro>()
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
                },

            };

            //ViewBag.Libros = libros;

            return View(libros);
        }
    }
}
