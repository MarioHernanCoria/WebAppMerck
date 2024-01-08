using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Modelos.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo de correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo de correo electrónico no tiene un formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo de contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
