using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using actividad01.Models;

namespace actividad01.Interface
{
    public interface IAlumnoDireccion
    {
        List<AlumnoDireccionViewModel> ConsultarRegistros();
        void CrearRegistro(AlumnoDireccionViewModel alumno);
    }
}