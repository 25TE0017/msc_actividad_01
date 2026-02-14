using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using actividad01.Interface;
using actividad01.Models;

namespace actividad01.Services
{
    public class AlumnoDireccionService: IAlumnoDireccion
    {   
        private readonly List<AlumnoDireccionViewModel> alumnos;

        public AlumnoDireccionService()
        {
            alumnos = new List<AlumnoDireccionViewModel>();

            Alumno a1 = new Alumno{NoControl = "25TE001", Nombre = "A1"};
            Alumno a2 = new Alumno{NoControl = "25TE002", Nombre = "A2"};
            Alumno a3 = new Alumno{NoControl = "25TE003", Nombre = "A3"};

            Direcciones d1 = new Direcciones{Calle = "Av. puerto", CP = 10001};
            Direcciones d2 = new Direcciones{Calle = "Av. muelle", CP = 10002};
            Direcciones d3 = new Direcciones{Calle = "Av. abismo", CP = 10003};

            AlumnoDireccionViewModel r1 = new AlumnoDireccionViewModel{Alumno = a1, Direccion = d1};
            AlumnoDireccionViewModel r2 = new AlumnoDireccionViewModel{Alumno = a2, Direccion = d2};
            AlumnoDireccionViewModel r3 = new AlumnoDireccionViewModel{Alumno = a3, Direccion = d3};

            alumnos.Add(r1);
            alumnos.Add(r2);
            alumnos.Add(r3);
        }

        public List<AlumnoDireccionViewModel> ConsultarRegistros()
        {
            return alumnos;
        }

        public void CrearRegistro(AlumnoDireccionViewModel alumno)
        {
            alumnos.Add(alumno);
        }
    }
}