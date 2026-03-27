using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace actividad01.Models
{
    public class Direcciones
    {
        [Required(ErrorMessage = "La dirección es requerido")]
        public string? Calle { get; set; }
        [Required(ErrorMessage = "El código postal es requerido")]
        public int? CP { get; set; }
    }
}