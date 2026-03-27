using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using actividad01.Data;
using actividad01.Interface;
using actividad01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace actividad01.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly IAlmacenamiento _IAlmacenamiento;
        private readonly AppDbContext _db;

        public ArchivoController(IAlmacenamiento almacenamiento, AppDbContext db)
        {
            _IAlmacenamiento = almacenamiento;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Archivo> archivos = await _db.Archivos.ToListAsync();

            return View(archivos);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Evidencia evidencia)
        {
            if (!ModelState.IsValid) return View("Index", evidencia);

            string url = "";
            string ext = "";
            if (evidencia.File is not null && evidencia.File.Length > 0)
            {
                ext = Path.GetExtension(evidencia.File.FileName);
                url = await _IAlmacenamiento.AlmacenarImagen("files", evidencia.File);
            }

            Archivo file = new Archivo
            {
                Nombre = evidencia.Nombre,
                Descripcion = evidencia.Descripcion,
                Extension = ext,
                Url = url
            };

            await _db.Archivos.AddAsync(file);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Destroy(string id)
        {
            Archivo? file = await _db.Archivos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (file == null) return NotFound();

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> DestroyAction(string id)
        {
            Archivo? result = await _db.Archivos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (result == null) return NotFound();

            await _IAlmacenamiento.Eliminar("files", result.Url);

            _db.Archivos.Remove(result);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}