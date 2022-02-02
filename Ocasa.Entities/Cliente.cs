using System.ComponentModel.DataAnnotations;

namespace Ocasa.Entities
{
    public class Cliente
    {
  
        [Key]
        [Required]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "RazonSocial longitud  maxima 50 caracteres")]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Direccion longitud maxima 200 caracteres")]
        public string Direccion { get; set; }
    }
}
