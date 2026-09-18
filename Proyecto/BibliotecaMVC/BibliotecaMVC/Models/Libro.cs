namespace BibliotecaMVC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Libro
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        public string Autor { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }

        [Range(0.01, 100000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        public bool Disponible { get; set; }
    }
}

