using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using actividad01.Data;
using actividad01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace actividad01.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly AppDbContext _db;
        public AlumnoController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Alumno> alumnos = await _db.Alumnos.ToListAsync();
            return View(alumnos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Alumno alumno)
        {
            Alumno? al = await _db.Alumnos.FirstOrDefaultAsync(x => x.NoControl == alumno.NoControl);
            if (!ModelState.IsValid) return View(alumno);
            if (al != null) {
                ModelState.AddModelError("NoControl", "El número de control ya existe");
                return View(alumno);
            };

            await _db.Alumnos.AddAsync(alumno);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string NoControl)
        {
            Alumno? alumno = await _db.Alumnos.FirstOrDefaultAsync(x => x.NoControl == NoControl);
            if (alumno == null) return NotFound();

            return View(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Alumno alumno)
        {
            if (!ModelState.IsValid) return View(alumno);
            Alumno? al = await _db.Alumnos.FirstOrDefaultAsync(x => x.NoControl == alumno.NoControl);
            if (al == null) return View(alumno);

            al.Nombre = alumno.Nombre;
            al.Carrera = alumno.Carrera;
            al.Semestre = alumno.Semestre;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Destroy(string NoControl)
        {
            Alumno? alumno = await _db.Alumnos.FirstOrDefaultAsync(x => x.NoControl == NoControl);
            if (alumno == null) return View(alumno);
            return View(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> DestroyAction(Alumno alumno)
        {
            Alumno? al = await _db.Alumnos.FirstOrDefaultAsync(x => x.NoControl == alumno.NoControl);
            _db.Alumnos.Remove(al!);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}