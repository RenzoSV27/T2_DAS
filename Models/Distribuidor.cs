using System.ComponentModel.DataAnnotations;

namespace T2_Salazar_Renzo.Models
{
    public class Distribuidor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del distribuidor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del distribuidor no puede tener más de 100 caracteres.")]
        public string NombreDistribuidor { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria.")]
        [StringLength(200, ErrorMessage = "La razón social no puede tener más de 200 caracteres.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede tener más de 15 caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El año de inicio de operación es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "El año de inicio de operación debe estar entre 1900 y 3000.")]
        public int AnioInicioOperacion { get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El contacto no puede tener más de 100 caracteres.")]
        public string Contacto { get; set; }
    }
}
