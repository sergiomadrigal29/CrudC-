using System.ComponentModel.DataAnnotations;

namespace CrudNetMVC.Models
{
    public class Contacto
    {   
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo Celular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Correo no es un correo valido")]
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
