using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libro> _libros = new List<Libro>()
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

        public IActionResult Index()
        {
            return View(_libros);
        }

        public IActionResult Details(int id)
        {
            var libro = _libros.FirstOrDefault(x => x.ID == id);
            if(libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            if (_libros.Any())
            {
                libro.ID = _libros.Max(x => x.ID) + 1;
            }
            else
            {
                libro.ID = 1;
            }

            _libros.Add(libro);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var libro = _libros.FirstOrDefault(x => x.ID == id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Libro libro)
        {
            if (id != libro.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            var existingLibro = _libros.FirstOrDefault(x => x.ID == id);
            if (existingLibro == null)
            {
                return NotFound();
            }

            existingLibro.Titulo = libro.Titulo;
            existingLibro.Autor = libro.Autor;
            existingLibro.Categoria = libro.Categoria;
            existingLibro.Precio = libro.Precio;
            existingLibro.Disponible = libro.Disponible;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var libro = _libros.FirstOrDefault(x => x.ID == id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var libro = _libros.FirstOrDefault(x => x.ID == id);
            if (libro != null)
            {
                _libros.Remove(libro);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
