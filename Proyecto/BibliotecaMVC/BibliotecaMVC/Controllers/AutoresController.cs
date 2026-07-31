using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class AutoresController : Controller
    {
      
            private static List<Autor> _autores = new List<Autor>()
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
        public IActionResult Index()
        {
            return View(_autores);
        }

        public IActionResult Details(int id)
        {
            var autor = _autores.FirstOrDefault(x => x.ID == id);
            if(autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            if (_autores.Any())
            {
                autor.ID = _autores.Max(x => x.ID) + 1;

            }
            else
            {
                autor.ID = 1;

            }

            _autores.Add(autor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var autor = _autores.FirstOrDefault(x => x.ID == id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Autor autor)
        {
            if (id != autor.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            var existingAutor = _autores.FirstOrDefault(x => x.ID == id);
            if (existingAutor == null)
            {
                return NotFound();
            }

            existingAutor.Nombre = autor.Nombre;
            existingAutor.Apellido = autor.Apellido;
            existingAutor.Nacionalidad = autor.Nacionalidad;
            existingAutor.FechaNacimiento = autor.FechaNacimiento;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var autor = _autores.FirstOrDefault(x => x.ID == id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _autores.FirstOrDefault(x => x.ID == id);
            if (autor != null)
            {
                _autores.Remove(autor);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
