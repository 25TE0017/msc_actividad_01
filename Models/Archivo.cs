using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace actividad01.Models
{
    public class Archivo
    {
        public Archivo()
        {
            var mexicoZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            Registro = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, mexicoZone);
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "La Nombre del archivo es requerido")]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Extension { get; set; }
        public string? Url { get; set; }
        public DateTime Registro { get; set; } = DateTime.UtcNow; 
    }
}