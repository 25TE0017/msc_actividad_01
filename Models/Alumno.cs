
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace actividad01.Models
{
    public class Alumno
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string? Nombre { get; set; }
        [Unicode]
        [Required(ErrorMessage = "El No.Control es requerido")]
        [StringLength(10, ErrorMessage = "No puede ser más de 10 caracteres")]
        public string? NoControl { get; set; }
        public string? Carrera { get; set; }
        public string? Semestre { get; set; }
    }
}