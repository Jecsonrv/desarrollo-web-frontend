using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class AutoresController : Controller
    {
        public IActionResult Index()
        {
            List<Autor> autores = new List<Autor>()
            {
                new Autor
                {
                    ID = 1,
                    Nombre = "Robert",
                    Apellido = "Martin",
                    Nacionalidad = "Estadounidense",
                    FechaNacimiento = new DateOnly(1952, 12, 5),
                    Activo = true
                },
                new Autor
                {
                    ID = 2,
                    Nombre = "Martin",
                    Apellido = "Fowler",
                    Nacionalidad = "Británico",
                    FechaNacimiento = new DateOnly(1963, 12, 18),
                    Activo = true
                },
                new Autor
                {
                    ID = 3,
                    Nombre = "Andrew",
                    Apellido = "Hunt",
                    Nacionalidad = "Estadounidense",
                    FechaNacimiento = new DateOnly(1964, 1, 1), // Fecha aproximada (día/mes no ampliamente documentados)
                    Activo = true
                },
                new Autor
                {
                    ID = 4,
                    Nombre = "David",
                    Apellido = "Thomas",
                    Nacionalidad = "Británico",
                    FechaNacimiento = new DateOnly(1956, 1, 1), // Fecha aproximada (día/mes no ampliamente documentados)
                    Activo = true
                },
                new Autor
                {
                    ID = 5,
                    Nombre = "R. J.",
                    Apellido = "Palacio",
                    Nacionalidad = "Estadounidense",
                    FechaNacimiento = new DateOnly(1963, 7, 13),
                    Activo = false
                }
            };
            return View(autores);
        }
    }
}
