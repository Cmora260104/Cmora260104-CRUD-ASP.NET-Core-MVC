using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class DatosModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        public string? FechaNacimiento { get; set; }

    }
}
