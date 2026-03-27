using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace actividad01.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La marca es requerido")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "La Diagnostico es requerido")]
        public string? Diagnostico { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El tecnico es requerido")]
        public string? Tecnico { get; set; }
        public DateTime Registro { get; set; } = DateTime.UtcNow;
    }
}