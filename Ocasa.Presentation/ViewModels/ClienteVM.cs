using Ocasa.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ocasa.Presentation.ViewModels
{
    public class ClienteVM
    {
        public ClienteVM()
        {

        }

        public ClienteVM(Cliente obj)
        {
            IdCliente = obj.IdCliente;
            RazonSocial = obj.RazonSocial;
            Direccion = obj.Direccion;
        }

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
