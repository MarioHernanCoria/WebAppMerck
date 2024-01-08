using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Modelos.Models.Entities
{
    public class Usuario : IdentityUser
    {
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
    