using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMerck.Modelos.Models.ViewModel
{
    public class AccesoViewModel
    {
        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        public bool Recordarme { get; set; }

    }
}
