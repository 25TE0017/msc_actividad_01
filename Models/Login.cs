using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace actividad01.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El Usuario es requerido")]
        public string? Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es requerido")]
        public string? Password { get; set; }
    }
}