using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace actividad01.Models
{
    public class Evidencia
    {
        // public int Id { get; set; }
        [Required(ErrorMessage = "La ruta es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La Extención es requerido")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El archivo es requerido")]
        public IFormFile? File { get; set; }
        public DateTime Registro { get; set; } = DateTime.UtcNow;
    }
}